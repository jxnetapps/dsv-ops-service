using Dsv.Contracts.FilmOps;
using Dsv.Contracts.PeopleOps;
using Microsoft.AspNetCore.Mvc;

namespace Dsv.WebAPI.Controllers
{
    [ApiController]
    public class FilmOpsController : ControllerBase
    {
        readonly IFilmOps _coreService;
        public FilmOpsController(IFilmOps filmOps)
        {
            _coreService = filmOps;
        }

        [Route("/v1/films")]
        [HttpGet]
        public async Task<ActionResult<GetFilms.Response>> GetFilmsAsync([FromQuery] GetFilms.Request request)
        {
            var response = await _coreService.GetFilmsAsync(request);

            return Ok(response);
        }

        [Route("/v1/films/{id}")]
        [HttpGet]
        public async Task<ActionResult<GetFilm.Response>> GetFilmAsync([FromRoute] GetFilm.Request request)
        {
            var response = await _coreService.GetFilmAsync(request);

            return Ok(response);
        }        
    }
}
