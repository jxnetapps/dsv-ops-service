using Dsv.Contracts.PeopleOps;
using HybridModelBinding;

namespace Dsv.WebAPI.Controllers.Models
{
    public class UpdatePeopleReq
    {
        [HybridBindProperty(new[] { Source.Route })]
        public string Id { get; set; }

        [HybridBindProperty(new[] { Source.Body })]
        public string Name { get; set; }

        [HybridBindProperty(new[] { Source.Body })]
        public string Height { get; set; }

        [HybridBindProperty(new[] { Source.Body })]
        public string BirthYear { get; set; }

        [HybridBindProperty(new[] { Source.Body })]
        public string Gender { get; set; }

        public UpdatePeople.Request GetRequest()
        {
            return new UpdatePeople.Request
            {
                Id = Id,
                BirthYear = BirthYear,
                Gender = Gender,
                Height = Height,
                Name = Name
            };
        }
    }
}
