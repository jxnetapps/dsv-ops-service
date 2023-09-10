using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dsv.Contracts.PeopleOps;

namespace Dsv.Contracts.FilmOps
{
    public interface IFilmOps
    {
        Task<GetFilms.Response> GetFilmsAsync(GetFilms.Request request);
        Task<GetFilm.Response> GetFilmAsync(GetFilm.Request request);

    }
}
