using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Helpers
{
    public static class OpperationResultHelper
    {
        public static OperrionResult ReturnSuccessData(Object data)
        {
            return new OperrionResult(true, data);
        }

        public static OperrionResult ReturnErrorMsg(string msg)
        {
            return new OperrionResult(false, null, msg);
        }
    }
}
