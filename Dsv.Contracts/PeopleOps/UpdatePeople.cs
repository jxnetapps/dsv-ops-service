namespace Dsv.Contracts.PeopleOps
{
    public class UpdatePeople
    {
        public class Request
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public string Height { get; set; }
            public string BirthYear { get; set; }
            public string Gender { get; set; }
        }

        public class Response
        {
            public bool IsSuccess { get; set; }
        }
    }
}
