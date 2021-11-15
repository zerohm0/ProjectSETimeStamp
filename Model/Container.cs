using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
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
}
