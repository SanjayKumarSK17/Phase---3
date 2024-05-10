using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CafeteriaManagement
{
    public enum Gender {Select, Male, Female, Transgender} 
    public class PersonalDetails
    {
        public string  Name { get; set; }
        public string FatherName { get; set; }
        public Gender Gender { get; set; }
        public long MobileNumber { get; set; }
        public string MailID { get; set; }

        public PersonalDetails(string name, string fatherName, Gender gender, long mobileNumber, string mailID)
        {
            Name=name;
            FatherName=fatherName;
            Gender=gender;
            MobileNumber=mobileNumber;
            MailID=mailID;
        }
        public PersonalDetails()
        {
            
        }
    }
}