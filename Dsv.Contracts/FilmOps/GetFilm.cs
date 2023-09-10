using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Contracts.PeopleOps
{
    public class GetFilm
    {
        public class Request
        {
            public string Id { get; set; }
        }

        public class Response
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string EpisodeId { get; set; }
            public string OpeningCrawl { get; set; }
            public string Director { get; set; }
            public string Producer { get; set; }
            public DateTime ReleaseDate { get; set; }
            public DateTime Created { get; set; }
            public DateTime Edited { get; set; }
            public string PosterPath { get; set; }

            public List<PeopleOut> Peoples { get; set; }
        }

        public class PeopleOut
        {
            public string Id { get; set; }
            public string Name { get; set; }
        }
    }
}
