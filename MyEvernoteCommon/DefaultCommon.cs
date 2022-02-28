using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEvernoteCommon
{
    class DefaultCommon : ICommon
    {
        public string GetCurrentUserName()
        {
            return "system";
        }
    }
}
