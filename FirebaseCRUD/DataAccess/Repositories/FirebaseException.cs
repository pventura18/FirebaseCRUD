using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.DataAccess.Repositories
{
    public class FirebaseException : Exception
    {         
        public FirebaseException(string message) : base(message)
        {
        }
    }
    
}
