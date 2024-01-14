using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.DataAccess
{
    public class FirebaseConnection
    {
        public static FirebaseClient GetFireBaseClient(string url, string secret = null)
        {
            return new FirebaseClient(url, new FirebaseOptions
            {
                AuthTokenAsyncFactory = () => Task.FromResult(secret)
            });
        }
    }
}
