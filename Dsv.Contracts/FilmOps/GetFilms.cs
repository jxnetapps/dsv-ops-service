namespace Dsv.Contracts.PeopleOps
{
    public class GetFilms
    {
        public class Request
        {

        }

        public class Response
        {
            public List<FilmOut> Items { get; set; }
        }

        public class FilmOut
        {
            public string Id { get; set; }
            public string Title { get; set; }
            public string PosterPath { get; set; }
            public DateTime Created { get; set; }
        }
    }
}
