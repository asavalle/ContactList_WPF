using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBAccessDemo
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int User_ID { get; set; }


            /*public methods for Person class*/
        public String FullInfo
        {
            get
            {   //   "02: Anthony Avalle: (anthonyavalle@hotmail.com)-(555-555-5555)"
                return $"{User_ID}| { FirstName }| { LastName }| ({Email})| ({PhoneNumber})"; 
            }

        }

        public String FName
        {
            get
            {   
                return $"{ FirstName }";
            }

        }
        public String LName
        {
            get
            {   
                return $"{ LastName }";
            }

        }
        public String email
        {
            get
            {   
                return $"{ Email }";
            }

        }
        public String PhoneNum
        {
            get
            {   
                return $"{ PhoneNumber }";
            }

        }
    }
}
