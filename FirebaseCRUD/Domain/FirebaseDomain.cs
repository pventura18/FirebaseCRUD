using FirebaseCRUD.DataAccess.Repositories;
using FirebaseCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.Domain
{
    public class FirebaseDomain : IFirebaseDomain
    {
        public IFirebaseRepository FirebaseRepository { get; set; }
        public FirebaseDomain()
        {
            FirebaseRepository = FirebaseFactory.GetFirebaseRepository();
        }
        public async Task<bool> AddStudent(Student student)
        {
            return await FirebaseRepository.AddStudent(student);
        }

        public async Task<bool> ExistStudent(string name)
        {
            return await FirebaseRepository.ExistsStudent(name);
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            bool updated = true;
            return await FirebaseRepository.UpdateStudent(student);
        }

        public async Task<Student> GetStudent(string name)
        {
            return await FirebaseRepository.GetStudent(name);
        }

        public async Task<Student> GetStudent(Student student)
        {
            return await FirebaseRepository.GetStudent(student.Name);
        }

        public async Task<bool> RemoveStudent(string name)
        {
            return await FirebaseRepository.RemoveStudent(name);
        }

        public async Task<bool> RemoveStudent(Student student)
        {
            return await FirebaseRepository.RemoveStudent(student.Name);
        }

        public async Task<List<Student>> GetListStudents()
        {
            var firebaseObjects = await FirebaseRepository.GetStudents();
            foreach (var firebaseObject in firebaseObjects)
            {
                firebaseObject.Object.Name = firebaseObject.Key;
            }
            return firebaseObjects.Select(firebaseObject => firebaseObject.Object).ToList();
        }
    }
}
