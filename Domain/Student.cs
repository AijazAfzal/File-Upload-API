using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Student
    {
        [Key]
        public int Id { get; set; } 

        public string First_Name { get; set; } 

        public string Last_Name { get; set; }

        public string Email_address { get; set; } 
    }
}
