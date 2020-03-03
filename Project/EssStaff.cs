using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project
{
    public class EssStaffProfile
    {
        public string cn { get; set; }
        public string sn { get; set; }
        public string personalId { get; set; }
        public string studentId { get; set; }
        public string employeeId { get; set; }
        public string prename { get; set; }
        public string firstNameThai { get; set; }
        public string lastNameThai { get; set; }
        public string campusID { get; set; }
        public string campus { get; set; }
        public string faculty { get; set; }
        public string department { get; set; }
        public string program { get; set; }
        public string curriculum { get; set; }
        public string section { get; set; }
        public string status { get; set; }
    }

    public class EssStaff
    {
        public string status { get; set; }
        public string message { get; set; }
        public EssStaffProfile result { get; set; }
    }
}
