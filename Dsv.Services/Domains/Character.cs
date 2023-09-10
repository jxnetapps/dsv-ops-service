using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Domains
{
    public class Character
    {
        public string Id { get; set; }
        public string FilmId { get; set; }
        public string PeopleId { get; set; }
        public DateTime Created { get; set; }
        public DateTime Edited { get; set; }
    }
}
