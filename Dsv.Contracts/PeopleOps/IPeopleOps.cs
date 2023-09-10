namespace Dsv.Contracts.PeopleOps
{
    public interface IPeopleOps
    {
        Task<CreatePeople.Response> CreatePeopleAsync(CreatePeople.Request request);
        Task<GetPeoples.Response> GetPeoplesAsync(GetPeoples.Request request);
        Task<GetPeople.Response> GetPeopleAsync(GetPeople.Request request);
        Task<UpdatePeople.Response> UpdateAsync(UpdatePeople.Request request);
        Task<DeletePeople.Response> DeletePeopleAsync(DeletePeople.Request request);
    }
}
