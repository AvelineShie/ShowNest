using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public class OperationResult
    {
        public OperationResult(bool status, Object data, string message = "")
        {
            this.Status = status;
            this.Data = data;
            this.Message = message;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; }


    }

}
