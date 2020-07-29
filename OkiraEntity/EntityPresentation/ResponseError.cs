using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OkiraEntity.EntityPresentation
{
    public class ResponseError
    {
        public string Message { get; set; }
        public string Detail { get; set; }

        public ResponseError(string Message, string Detail = null)
        {
            this.Message = Message;
            this.Detail = Detail;
        }
    }
}
