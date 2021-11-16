using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSETimeStamp
{
    public class Filter
    {
        public string ID { get; set; }

        public string Password { get; set; }

        public string Username { get; set; }

        public string Name { get; set; }
        public string LName { get; set; }

        public string Department { get; set; }

        public string Level { get; set; }

        public DateTime dtF { get; set; }

        public DateTime dtL { get; set; }

        public DateTime dtK { get; set; }

        public string Type { get; set; }

        public string Detial { get; set; }

        public DateTime TimeIn { get; set; }

        public DateTime TimeOut { get; set; }
    }
}
