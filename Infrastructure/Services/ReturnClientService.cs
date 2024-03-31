using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Class
{

    public class ReturnClientService 
    {
        public ReturnClientService() { }

        public static ReturnObj ReturnSuccessData(Object data) {
            return new ReturnObj(true,data);
        }

        public static ReturnObj ReturnErrorMsg(string msg)
        {
            return new ReturnObj(false, null,msg);
        }
    }


    public class ReturnObj
    {
        public ReturnObj(bool status,Object data,string message="") {
            this.Status = status;
            this.Data = data;
            this.Message = message;
        }

        public bool Status { get; set; }
        public string Message { get; set; }
        public Object Data { get; set; } 


    }
}
