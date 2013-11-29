using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBtce
{
    public class NonceProvider : INonceProvider
    {
        private long _seed = UnixTime.Now;

        public long GetNext()
        {
            return _seed++;
        }
    }
}
