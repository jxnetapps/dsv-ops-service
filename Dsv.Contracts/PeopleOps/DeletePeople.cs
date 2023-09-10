namespace Dsv.Contracts.PeopleOps
{
    public class DeletePeople
    {
        public class Request
        {
            public string Id { get; set; }
        }

        public class Response
        {
            public bool IsSuccess { get; set; }
        }
    }
}
