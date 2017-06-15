using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    public class PersonRepository
    {
        public async Task<List<Person>> GetAsync()
        {
            await Task.Delay(3000); //Pause for 3 secs
            return new List<Person>()
            {
                new Person("Majid","Hussain",new DateTime(1995,12,11)),
                new Person("Bob","Martin",new DateTime(1970,10,11)),
                new Person("Pina", "Martin", new DateTime(1996, 12, 11))
            };
        }
    }
}
