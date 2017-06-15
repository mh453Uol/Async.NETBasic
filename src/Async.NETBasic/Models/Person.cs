using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    public class Person
    {
        public Person(string FirstName, string LastName, DateTime DOB)
        {
            this.Firstname = Firstname;
            this.Lastname = Lastname;
            this.DateOfBirth = DOB;
        }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime DateOfBirth { get; set; }
        public override string ToString()
        {
            return String.Format("{0} {1} {2}", Firstname, Lastname, DateOfBirth);
        }
    }
}
