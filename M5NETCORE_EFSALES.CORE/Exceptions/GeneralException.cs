using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace M5NETCORE_EFSALES.CORE.Exceptions
{
    public class GeneralException: Exception
    {
        public GeneralException(string message): base(message)
        {

        }
    }
}
