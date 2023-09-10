using Dsv.Contracts.FilmOps;
using Dsv.Contracts.PeopleOps;
using Dsv.Services.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Impl.PeopleOps
{
    internal class FilmOps : IFilmOps
    {

        private readonly IDsvServiceDbContext _dbContext;

        public FilmOps(IDsvServiceDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<GetFilms.Response> GetFilmsAsync(GetFilms.Request request)
       => await new GetFilmsHandler(_dbContext).HandleAsync(request);

        public async Task<GetFilm.Response> GetFilmAsync(GetFilm.Request request)
            => await new GetFilmHandler(_dbContext).HandleAsync(request);
    }
}
