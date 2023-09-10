namespace Dsv.Contracts.PeopleOps
{
    public class CreatePeople
    {
        public class Request
        {
            public string Name { get; set; }
            public string Height { get; set; }
            public string BirthYear { get; set; }
            public string Gender { get; set; }
        }

        public class Response
        {
            public string Id { get; set; }
            public bool IsSuccess { get; set; }
        }
    }
}
