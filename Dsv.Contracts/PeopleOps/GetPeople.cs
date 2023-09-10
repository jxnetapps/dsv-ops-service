using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Contracts.PeopleOps
{
    public class GetPeople
    {
        public class Request
        {
            public string Id { get; set; }
        }

        public class Response
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Email { get; set; }
            public string Dob { get; set; }
            public string Gender { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public List<FilmOut> Films { get; set; }
        }

        public class FilmOut
        {
            public string Id { get; set; }
            public string Title { get; set; }
        }
    }
}
