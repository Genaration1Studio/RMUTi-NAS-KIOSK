using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class ReqRegisterResult
    {
        public string login { get; set; }
        public string uid { get; set; }
        public string cn { get; set; }
        public string sn { get; set; }
        public string personalId { get; set; }
        public string studentId { get; set; }
        public string employeeId { get; set; }
        public string prename { get; set; }
        public string firstNameThai { get; set; }
        public string lastNameThai { get; set; }
        public string title { get; set; }
        public string campusID { get; set; }
        public string campus { get; set; }
        public string faculty { get; set; }
        public string department { get; set; }
        public string program { get; set; }
        public string curriculum { get; set; }
        public string uidNumber { get; set; }
        public string gidNumber { get; set; }
        public string mail { get; set; }
        public string phoneNumber { get; set; }
        public string accountStatus { get; set; }
        public string internetStatus { get; set; }
        public string sambaStatus { get; set; }
        public string remark { get; set; }
    }

    public class ReqRegister
    {
        public string status { get; set; }
        public string message { get; set; }
        public ReqRegisterResult result { get; set; }
    }
}
