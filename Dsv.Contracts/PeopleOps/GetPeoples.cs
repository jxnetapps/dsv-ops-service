using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Contracts.PeopleOps
{
    public class GetPeoples
    {
        public class Request
        {

        }

        public class Response
        {
            public List<PeopleOut> Items { get; set; }
        }

        public class PeopleOut
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Dob { get; set; }
            public string Gender { get; set; }
            public DateTime Created { get; set; }
            public List<FilmOut> Films { get; set; }
        }

        public class FilmOut
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }
    }
}
