using Dsv.Contracts.PeopleOps;
using Dsv.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Impl.PeopleOps
{
    internal class PeopleOps : IPeopleOps
    {

        private readonly IDsvServiceDbContext _dbContext;

        public PeopleOps (IDsvServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<CreatePeople.Response> CreatePeopleAsync(CreatePeople.Request request)
            => await new CreatePeopleHandler(_dbContext).HandleAsync(request);        

        public async Task<GetPeoples.Response> GetPeoplesAsync(GetPeoples.Request request)
            => await new GetPeoplesHandler(_dbContext).HandleAsync(request);

        public async Task<GetPeople.Response> GetPeopleAsync(GetPeople.Request request)
            => await new GetPeopleHandler(_dbContext).HandleAsync(request);

        public Task<UpdatePeople.Response> UpdateAsync(UpdatePeople.Request request)
        {
            throw new NotImplementedException();
        }

        public Task<DeletePeople.Response> DeletePeopleAsync(DeletePeople.Request request)
        {
            throw new NotImplementedException();
        }
    }
}
