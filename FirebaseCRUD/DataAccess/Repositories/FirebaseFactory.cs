using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.DataAccess.Repositories
{
    public class FirebaseFactory
    {
        public static IFirebaseRepository GetFirebaseRepository()
        {
            return new FirebaseRepository();
        }
    }
}
