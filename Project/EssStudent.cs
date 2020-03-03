using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class EssStudentResult
    {
        public string cn { get; set; }
        public string sn { get; set; }
        public string personalId { get; set; }
        public string type { get; set; }
        public string studentId { get; set; }
        public string title { get; set; }
        public string prenameId { get; set; }
        public string prename { get; set; }
        public string firstNameThai { get; set; }
        public string lastNameThai { get; set; }
        public string birthDate { get; set; }
        public string campusID { get; set; }
        public string campus { get; set; }
        public string faculty { get; set; }
        public string facultyId { get; set; }
        public string department { get; set; }
        public string departmentId { get; set; }
        public string program { get; set; }
        public string programId { get; set; }
        public string curriculum { get; set; }
        public string curriculumId { get; set; }
        public string section { get; set; }
        public string regularYear { get; set; }
        public string statusId { get; set; }
        public string status { get; set; }
    }

    public class EssStudent
    {
        public string status { get; set; }
        public string message { get; set; }
        public EssStudentResult result { get; set; }
    }
}
