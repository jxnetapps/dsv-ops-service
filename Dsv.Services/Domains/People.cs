using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Domains
{
    public class People
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Dob { get; set; }
        public string Gender { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
