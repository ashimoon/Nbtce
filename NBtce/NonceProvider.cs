using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBtce
{
    public class NonceProvider
    {
        private static long _seed = UnixTime.Now;

        public static long GetNext()
        {
            return _seed++;
        }
    }
}
