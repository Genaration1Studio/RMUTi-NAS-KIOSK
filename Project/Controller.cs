using Emgu.CV;
using Emgu.CV.Structure;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ThaiNationalIDCard;
using System.Security.Cryptography;

namespace Project
{
    class Controller
    {
        
        //public static byte[] iv = new byte[16] { 0x72, 0x6D, 0x75, 0x74, 0x69, 0x72, 0x6D, 0x75, 0x74, 0x69, 0x72, 0x6D, 0x75, 0x74, 0x69, 0x72 };
        public static byte[] iv = new byte[16] { 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0, 0x0 };
        public static byte[] key { get; set; }
        public static string app_token { get; set; }
        public static string member_type {get; set; }
        public static string query_type { get; set; }
        public static string query_value { get; set; }
        public static string mode { get; set; }
        public static string searchValue { get; set; }
        public static string cardCitizen { get; set; }
        public static string cardFName_th { get; set; }
        public static string cardLName_th { get; set; }
        public static string cardFName_en { get; set; }
        public static string cardLName_en { get; set; }
        public static string cardBdate { get; set; }
        public static string errMeg { get; set; }
        public static Member member { get; set; }
        public static EssStaff essStaff { get; set; }
        public static EssStudent essStudent { get; set; }
        public static Key objKey { get; set; }
        public static ReqEdit edit { get; set; }
        public static ReqRegister register { get; set; }

        public static string path = @"C:\Program Files\Kiosk For RMUTI Internet Account Service\Kiosk For RMUTI Internet Account Service";
        public static string pathImg_Slide = path + @"\Images\";
        public Controller()
        {

        }

        public static bool getMember()
        {
            string url = "";
            query_type = "citizen";
            query_value = cardCitizen;
            url = "https://account.rmuti.ac.th/api/v1/account/" + "student" + "/" + query_type + "/" + query_value + "?token=" + app_token;

            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    member = JsonConvert.DeserializeObject<Member>(json);
                }
                
            }
            catch (Exception)
            {
                //Error ไม่สามารถติดต่อระบบได้
               errMeg = "Server Error";
               return false;
            }

            if (member.status.Equals("success"))
            {
                member_type = member.result.title;
                return true;
            }
            else
            {
                //ไม่สามารถติดต่อระบบได้
                return false;
            }

        }

        public static bool getEss(string campusID,string value)
        {
            string url = "";

            if (member_type.Equals("student"))
            {
                query_type = "code";
                query_value = value;
                url = "https://account.rmuti.ac.th/api/v1/ess/" + member_type + "/" + campusID + "/"+ query_type + "/" + query_value + "?token=" + app_token;

                try
                {
                    using (var client = new WebClient())
                    {
                        var json = client.DownloadString(url);
                        essStudent = JsonConvert.DeserializeObject<EssStudent>(json);
                    }
                }
                catch (Exception)
                {
                    //Error ไม่สามารถติดต่อระบบได้
                   errMeg = "Server Error";
                   return false;
                }              

                if (essStudent.status.Equals("success"))
                {
                    return true;
                }
                else
                {
                    //ไม่สามารถติดต่อระบบได้
                    return false;
                }
            }
            else
            {
                query_type = "citizen";
                query_value = cardCitizen;
                url = "https://account.rmuti.ac.th/api/v1/ess/" + member_type + "/" + campusID + "/" + query_type + "/" + query_value + "?token=" + app_token;

                try
                {
                    using (var client = new WebClient())
                    {
                        var json = client.DownloadString(url);
                        essStaff = JsonConvert.DeserializeObject<EssStaff>(json);
                    }
                }
                catch (Exception)
                {
                    //Error ไม่สามารถติดต่อระบบได้
                    errMeg = "Server Error";
                    return false;
                }              

                if (essStaff.status.Equals("success"))
                {
                    return true;
                }
                else
                {
                    //ไม่สามารถติดต่อระบบได้
                    return false;
                }
            }          
        }

        public static bool getKey()
        {
            string url = "https://account.rmuti.ac.th/api/v1/request/key/new?token=" + app_token;
          
            try
            {
                using (var client = new WebClient())
                {
                    var json = client.DownloadString(url);
                    objKey = JsonConvert.DeserializeObject<Key>(json);
                }
            }
            catch (Exception)
            {
                //Error ไม่สามารถติดต่อระบบได้
                errMeg = "Server Error";
                return false;
            }          

            if (objKey.status.Equals("success"))
            {
                key = Encoding.ASCII.GetBytes(objKey.result.key);
                return true;
            }
            else
            {
                //ไม่สามารถติดต่อระบบได้
                return false;
            }
        }

         public static bool putEdit(string value, string attribute)
         {
            if (attribute.Equals("password"))
            {
                value = EncryptString(value);
            }
            
            string url = "https://account.rmuti.ac.th/api/v1/account/" + member_type + "/" + "citizen" + "/" + cardCitizen + "?token=" + app_token;      

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "PUT";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    string json = "{\"key\":\"" + objKey.result.key + "\"," +
                                    "\"do\":\"" + "set" + "\"," +
                                    "\"attribute\":\"" + attribute + "\"," +
                                    "\"value\":\"" + value + "\"}";
                    streamWriter.Write(json);
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();               
                    edit = JsonConvert.DeserializeObject<ReqEdit>(result);
                }
            }
            catch (Exception)
            {
                //Error ไม่สามารถติดต่อระบบได้
                errMeg = "Server Error";
                return false;
            }

            if (edit.status.Equals("success"))
            {
                return true;
            }
            else
            {
                //ไม่สามารถติดต่อระบบได้
                return false;
            }

        }

        public static bool postRegister(string code, string campus)
        {

            string url = "https://account.rmuti.ac.th/api/v1/account?token=" + app_token;

            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.ContentType = "application/json";
                httpWebRequest.Method = "POST";

                using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
                {
                    if (member_type.Equals("student"))
                    {
                        string json = "{\"key\":\"" + objKey.result.key + "\"," +
                                    "\"type\":\"" + member_type + "\"," +
                                    "\"campus\":\"" + campus + "\"," +
                                    "\"citizen\":\"" + cardCitizen + "\"," +
                                    "\"code\":\"" + code + "\"," +
                                    "\"cn\":\"" + cardFName_en + "\"," +
                                    "\"sn\":\"" + cardLName_en + "\"}";
                        streamWriter.Write(json);
                    }
                    else
                    {
                        string json = "{\"key\":\"" + objKey.result.key + "\"," +
                                    "\"type\":\"" + member_type + "\"," +
                                    "\"campus\":\"" + campus + "\"," +
                                    "\"citizen\":\"" + cardCitizen + "\"," +
                                    "\"cn\":\"" + cardFName_en + "\"," +
                                    "\"sn\":\"" + cardLName_en + "\"}";
                        streamWriter.Write(json);
                    }                           
                }

                var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
                using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                    register = JsonConvert.DeserializeObject<ReqRegister>(result);
                }
            }
            catch (Exception)
            {
                //Error ไม่สามารถติดต่อระบบได้
                errMeg = "Server Error";
                return false;
            }

            if (register.status.Equals("success"))
            {
                return true;
            }
            else
            {
                //ไม่สามารถติดต่อระบบได้
                return false;
            }

        }

        public static void cearEdit()
        {
            edit.status = null;
            edit.message = null;
            edit.result.login = null;
            edit.result.uid = null;
            edit.result.cn = null;
            edit.result.sn = null;
            edit.result.personalId = null;
            edit.result.studentId = null;
            edit.result.employeeId = null;
            edit.result.prename = null;
            edit.result.firstNameThai = null;
            edit.result.lastNameThai = null;
            edit.result.title = null;
            edit.result.campusID = null;
            edit.result.campus = null;
            edit.result.faculty = null;
            edit.result.department = null;
            edit.result.program = null;
            edit.result.curriculum = null;
            edit.result.uidNumber = null;
            edit.result.gidNumber = null;
            edit.result.mail = null;
            edit.result.phoneNumber = null;
            edit.result.accountStatus = null;
            edit.result.internetStatus = null;
            edit.result.sambaStatus = null;
            edit.result.remark = null;      
        }

        public static void cearRegister()
        {
            register.status = null;
            register.message = null;
            register.result.login = null;
            register.result.uid = null;
            register.result.cn = null;
            register.result.sn = null;
            register.result.personalId = null;
            register.result.studentId = null;
            register.result.employeeId = null;
            register.result.prename = null;
            register.result.firstNameThai = null;
            register.result.lastNameThai = null;
            register.result.title = null;
            register.result.campusID = null;
            register.result.campus = null;
            register.result.faculty = null;
            register.result.department = null;
            register.result.program = null;
            register.result.curriculum = null;
            register.result.uidNumber = null;
            register.result.gidNumber = null;
            register.result.mail = null;
            register.result.phoneNumber = null;
            register.result.accountStatus = null;
            register.result.internetStatus = null;
            register.result.sambaStatus = null;
            register.result.remark = null;
        }

        public static void cearMember()
        {
            member.status = null;
            member.message = null ;
            member.result.uid = null;
            member.result.cn = null;
            member.result.sn = null;
            member.result.personalId = null;
            member.result.studentId = null;
            member.result.employeeId = null;
            member.result.prename = null;
            member.result.firstNameThai = null;
            member.result.lastNameThai = null;
            member.result.title = null;
            member.result.campusID = null;
            member.result.campus = null;
            member.result.faculty = null;
            member.result.department = null;
            member.result.program = null;
            member.result.curriculum = null;
            member.result.uidNumber = null;
            member.result.gidNumber = null;
            member.result.mail = null;
            member.result.accountStatus = null;
            member.result.internetStatus = null;
            member.result.sambaStatus = null;
        }

        public static void cearEssStd()
        {
            essStudent.status = null;
            essStudent.message = null;
            essStudent.result.cn = null;
            essStudent.result.sn = null;
            essStudent.result.personalId = null;
            essStudent.result.type = null;
            essStudent.result.studentId = null;
            essStudent.result.title = null;
            essStudent.result.prenameId = null;
            essStudent.result.prename = null;
            essStudent.result.firstNameThai = null;
            essStudent.result.lastNameThai = null;
            essStudent.result.birthDate = null;
            essStudent.result.campusID = null;
            essStudent.result.campus = null;
            essStudent.result.faculty = null;
            essStudent.result.facultyId = null;
            essStudent.result.department = null;
            essStudent.result.departmentId = null;
            essStudent.result.program = null;
            essStudent.result.programId = null;
            essStudent.result.curriculum = null;
            essStudent.result.curriculumId = null;
            essStudent.result.section = null;
            essStudent.result.regularYear = null;
            essStudent.result.statusId = null;
            essStudent.result.status = null;
        }

        public static void cearEssSff()
        {
            essStaff.status = null;
            essStaff.message = null;
            essStaff.result.cn = null;
            essStaff.result.sn = null;
            essStaff.result.personalId = null;
            essStaff.result.studentId = null;
            essStaff.result.employeeId = null;
            essStaff.result.prename = null;
            essStaff.result.firstNameThai = null;
            essStaff.result.lastNameThai = null;
            essStaff.result.campusID = null;
            essStaff.result.campus = null;
            essStaff.result.faculty = null;
            essStaff.result.department = null;
            essStaff.result.program = null;
            essStaff.result.curriculum = null;
            essStaff.result.section = null;
            essStaff.result.status = null;
        }

        public static void cearKey()
        {
            objKey.status = null;
            objKey.message = null;
            objKey.result.token = null;
            objKey.result.key = null;
            objKey.result.ts = null;
        }

        public static void cearController()
        {
            member_type = null;
            query_type = null;
            query_value = null;
            mode = null;
            searchValue = null;
            cardCitizen = null;
            cardFName_th = null;
            cardLName_th = null;
            cardFName_en = null;
            cardLName_en = null;
            cardBdate = null;
            errMeg = "";
        }

        public static bool readCard()
        {
            try
            {

                ThaiIDCard card = new ThaiIDCard();
                Personal personal = card.readAll();

                if (personal != null)
                {
                    cardCitizen = personal.Citizenid;
                    cardFName_th = personal.Th_Firstname;
                    cardLName_th = personal.Th_Lastname;
                    cardFName_en = personal.En_Firstname;
                    cardLName_en = personal.En_Lastname;
                    cardBdate = personal.Birthday.ToString("dd/MM/yyyy");
                    return true;
                }
                else if (card.ErrorCode() > 0)
                {
                    return false;
                }
                else
                {
                    MessageBox.Show("Catch all");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                return false;
            }
        }

        public static bool checkCitizenESS()
        {
            if (member_type.Equals("student"))
            {
                if (cardCitizen.Equals(essStudent.result.personalId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (cardCitizen.Equals(essStaff.result.personalId))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            
        }

        public static bool checkCitizen()
        {

            if (member.result.personalId.Equals(cardCitizen))
            {
                return true;
            }
            else
            {
                return false;
            }      
        }

        public static string nameFailCode()
        {
            if (checkFname() == false && checkLname() == true)
            {
                return "ชื่อ(ภาษาอังกฤษ) ไม่ตรงกัน ! , กรุณาติดต่องานทะเบียนเพื่อแก้ไขข้อมูลให้ถูกต้อง";
            }
            else if (checkLname() == false && checkFname() == true)
            {
                return "นามสกุล(ภาษาอังกฤษ) ไม่ตรงกัน ! , กรุณาติดต่องานทะเบียนเพื่อแก้ไขข้อมูลให้ถูกต้อง";
            }
            else
            {
                return "ชื่อ-นามสกุล(ภาษาอังกฤษ) ไม่ตรงกัน ! , กรุณาติดต่องานทะเบียนเพื่อแก้ไขข้อมูลให้ถูกต้อง";
            }
        }

        public static bool checkFname()
        {
            if (cardFName_en.Equals(member.result.cn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool checkLname()
        {
            if (cardLName_en.Equals(member.result.sn))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static void capImages(string round)
        {             
            VideoCapture capture = new VideoCapture();
            string fullPathLog_Images = path + @"\log\" + DateTime.Now.ToString("MM-yyyy") + @"\Images";
            string fileName = fullPathLog_Images + @"\" + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss") + " Step_" + round + ".jpg";
            var img = capture.QueryFrame().ToImage<Bgr, byte>();
            var bmp = img.Bitmap;
            bmp.Save(fileName, System.Drawing.Imaging.ImageFormat.Jpeg);
            capture.Dispose();
        }

        public static void writeLog(string step, string status, string detail)
        {
            string fullPathLog_Text = path + @"\log\" + DateTime.Now.ToString("MM-yyyy") + @"\log.txt";
            string log = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss") + " {Step : " + step +"} " + "{Status : " + status + "} " + "{Detail : " + detail + "}";
            using (StreamWriter f = new StreamWriter(fullPathLog_Text, true))
            {
                f.WriteLine(log);
            }
        }

        public static void createDir()
        {
            string fullPathLog_Images = path + @"\log\" + DateTime.Now.ToString("MM-yyyy") + @"\Images";
            Directory.CreateDirectory(fullPathLog_Images);
        }
        public static int countImgSlide()
        {
            return Directory.GetFiles(pathImg_Slide, "*", SearchOption.TopDirectoryOnly).Length;
        }

        public static bool checkInsertCard()
        {
            bool status = false;
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity where Name like '%Unknown Smart Card%'"))
            {
                collection = searcher.Get();
            }
            foreach (var device in collection)
            {
                try
                {
                    var deviceName = (string)device.GetPropertyValue("Name");
                    if (deviceName.Contains("Unknown Smart Card"))
                    {
                        //เมื่อ detect เจอว่ามี Smart Card เสียบอยู่
                        status =  true;
                    }
                    else
                    {
                        status = false;
                    }
                }
                catch (Exception ex) { }
            }
            collection.Dispose();
            return status;
        }

        public static bool checkRemoveCard()
        {
            bool status = true;
            ManagementObjectCollection collection;
            using (var searcher = new ManagementObjectSearcher(@"Select * From Win32_PnPEntity where Name like '%Unknown Smart Card%'"))
            {
                collection = searcher.Get();
            }
            foreach (var device in collection)
            {
                try
                {
                    var deviceName = (string)device.GetPropertyValue("Name");
                    if (deviceName.Contains("Unknown Smart Card"))
                    {
                        //เมื่อ detect เจอว่ามี Smart Card เสียบอยู่
                        status = false;
                    }
                    else
                    {
                        status = true;
                    }
                }
                catch (Exception ex) { }
            }
            collection.Dispose();
            return status;
        }
        public static string EncryptString(string plainText)
        {
            Aes encryptor = Aes.Create();
            encryptor.Mode = CipherMode.CBC;

            byte[] aesKey = new byte[16];
            Array.Copy(key, 0, aesKey, 0, 16);
            encryptor.Key = aesKey;
            encryptor.IV = iv;

            MemoryStream memoryStream = new MemoryStream();

            ICryptoTransform aesEncryptor = encryptor.CreateEncryptor();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesEncryptor, CryptoStreamMode.Write);

            byte[] plainBytes = Encoding.ASCII.GetBytes(plainText);

            cryptoStream.Write(plainBytes, 0, plainBytes.Length);

            cryptoStream.FlushFinalBlock();

            byte[] cipherBytes = memoryStream.ToArray();

            memoryStream.Close();
            cryptoStream.Close();

            string cipherText = Convert.ToBase64String(cipherBytes, 0, cipherBytes.Length);

            return cipherText;
        }

        public static string DecryptString(string cipherText)
        {
            Aes encryptor = Aes.Create();

            encryptor.Mode = CipherMode.CBC;

            byte[] aesKey = new byte[16];
            Array.Copy(key, 0, aesKey, 0, 16);
            encryptor.Key = aesKey;
            encryptor.IV = iv;

            MemoryStream memoryStream = new MemoryStream();

            ICryptoTransform aesDecryptor = encryptor.CreateDecryptor();

            CryptoStream cryptoStream = new CryptoStream(memoryStream, aesDecryptor, CryptoStreamMode.Write);

            string plainText = String.Empty;

            try
            {
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                cryptoStream.Write(cipherBytes, 0, cipherBytes.Length);

                cryptoStream.FlushFinalBlock();

                byte[] plainBytes = memoryStream.ToArray();

                plainText = Encoding.ASCII.GetString(plainBytes, 0, plainBytes.Length);
            }
            finally
            {
                memoryStream.Close();
                cryptoStream.Close();
            }

            return plainText;
        }

    }
}
