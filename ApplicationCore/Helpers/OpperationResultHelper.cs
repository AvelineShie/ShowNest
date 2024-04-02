using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Helpers
{
    public static class OpperationResultHelper
    {
        public static OperationResult ReturnSuccessData(Object data)
        {
            return new OperationResult(true, data);
        }

        public static OperationResult ReturnErrorMsg(string msg)
        {
            return new OperationResult(false, null, msg);
        }
    }
}
