using FirebaseCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.Domain
{
    public interface IFirebaseDomain
    {
        public Task<bool> ExistStudent(string name);
        public Task<bool> AddStudent(Student student);
        public Task<bool> RemoveStudent(string name);
        public Task<bool> UpdateStudent(Student student);
        public Task<Student> GetStudent(string name);
        public Task<Student> GetStudent(Student student);
        public Task<List<Student>> GetListStudents();
    }
}
