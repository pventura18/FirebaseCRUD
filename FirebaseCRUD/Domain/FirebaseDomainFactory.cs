using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirebaseCRUD.Domain
{
    public class FirebaseDomainFactory
    {
        public static IFirebaseDomain GetFirebaseDomain()
        {
            return new FirebaseDomain();
        }
    }
}
