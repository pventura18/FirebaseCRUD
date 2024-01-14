using Firebase.Database;
using Firebase.Database.Query;
using FirebaseCRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.DataAccess.Repositories
{
    public class FirebaseRepository : IFirebaseRepository
    {
        private readonly FirebaseClient firebaseClient;
        public FirebaseRepository()
        {
            firebaseClient = FirebaseConnection.GetFireBaseClient("https://provadam-f54b4-default-rtdb.europe-west1.firebasedatabase.app/", "2dNetsgFQk5mGlNAHjE0j0tEYbvm36RZEwypGpwE");
        }

        public async Task<bool> ExistsStudent(string name)
        {
            return await firebaseClient
                .Child("Students")
                .Child($"{name}")
                .OnceSingleAsync<Student>() != null;
        }

        public async Task<bool> RemoveStudent(string student)
        {
            bool removed = true;
            try
            {
                await firebaseClient
                    .Child("Students")
                    .Child($"{student}")
                    .DeleteAsync();
            }
            catch (Exception)
            {
                removed = false;
            }
            return removed;
        }

        public async Task<bool> AddStudent(Student student)
        {
            bool added = true;
            try
            {
                await firebaseClient
                    .Child("Students")
                    .Child($"{student.Name}")
                    .PutAsync(student);
            }
            catch (Exception)
            {
                added = false;
            }

            return added;
        }

        public async Task<Student> GetStudent(string name)
        {
            KeyValuePair<string, Student> student = await firebaseClient
                .Child("Students")
                .Child($"{name}")
                .OnceSingleAsync<KeyValuePair<string, Student>>();
            student.Value.Name = student.Key;

            return student.Value;
        }

        public async Task<IReadOnlyCollection<FirebaseObject<Student>>> GetStudents()
        {
            return await firebaseClient
                .Child("Students")
                .OnceAsync<Student>();
        }

        public async Task<bool> UpdateStudent(Student student)
        {
            bool updated = true;
            try
            {
                if(await ExistsStudent(student.Name))
                {
                    await firebaseClient
                    .Child("Students")
                    .Child($"{student.Name}")
                    .PutAsync(student);
                }
                else updated = false;
            }
            catch (Exception)
            {
                updated = false;
            }
            return updated;
        }
    }
}
