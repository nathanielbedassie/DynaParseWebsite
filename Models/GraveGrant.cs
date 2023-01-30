using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DynaParseWebsite.Models
{
    public class GraveGrant
    {
        public int Id { get; set; }
        public string Applicant { get; set; }
        public string Date { get; set; }
        public string Cemetery { get; set; }
        public int No { get; set; }
        public string Address { get; set; }
        public int Receipt { get; set; }

        public GraveGrant()
        {

        }
    }
}
