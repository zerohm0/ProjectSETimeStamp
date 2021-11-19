using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSETimeStamp
{
    public class Container
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ExceptMessage { get; set; }
        public dynamic ResultObj { get; set; }

        public dynamic ResultID { get; set; }

        public dynamic ResultAnotherOneBiteTheDust { get; set; }

        public Filter Filter { get; set; }
    }
    public class Container<T>
    {
        public bool Status { get; set; }
        public string Message { get; set; }
        public string ExceptionMessage { get; set; }
        public T ResultObj { get; set; }
        public dynamic ResultObj2 { get; set; }
        public dynamic ResultID { get; set; }
        public string STR_ID { get; set; }
        public int INT_ID { get; set; }
        public Filter Filter { get; set; }

    }
}
