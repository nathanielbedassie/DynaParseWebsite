using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynaParseWebsite.Models
{
    public class Correspondence
    {
        public int Id { get; set; }
        public string Ref { get; set; }
        public string To { get; set; }
        public string Re { get; set; }
        public string Date { get; set; }

        public Correspondence()
        {

        }
    }

}
