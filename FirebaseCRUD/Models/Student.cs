using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.Models
{
    public class Student
    {
        private Cicle cicle = new Cicle();
        public string Name { get; set; }
        public string Id { get; set; }
        public string BirthDate { get; set; }
        public string Email { get; set; }
        public List<string> Hobbies { get; set; }
        public int AverageScore { get; set; }
        public bool Dual { get; set; }
        public Cicle CicleCursat
        {
            get
            {
                return cicle;
            }
            set
            {
                cicle = value;
            }
        }
    }
}
