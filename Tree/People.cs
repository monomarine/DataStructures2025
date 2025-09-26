using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
 
namespace Tree
{
    
    internal class People
    {
        public string Name { get; set; }
        public DateOnly BirthDay { get; set; }
        public int Age { get; set; }
        
        public People(string name, DateOnly birthDay)
        {
            Name = name;
            BirthDay = birthDay;
            
            DateOnly a = DateOnly.FromDateTime(DateTime.Now);
            Age = a.Year - birthDay.Year;
            
        }
        public override string ToString()
        {
            return Name +" "+ BirthDay;
           
        }
    }
}
