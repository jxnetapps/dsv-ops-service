using Dsv.Contracts.PeopleOps;
using Dsv.Services.Data;
using Dsv.Services.Domains;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Impl.PeopleOps
{
    internal class GetFilmHandler
    {
        private readonly IDsvServiceDbContext _dbContext;
        public GetFilmHandler(IDsvServiceDbContext apiContext)
        {
            _dbContext = apiContext;
        }
        internal async Task<GetFilm.Response> HandleAsync(GetFilm.Request request)
        {
            GetFilmValidator validator = new GetFilmValidator();

            var results = validator.Validate(request);

            if (results.IsValid == false)
            {
                //TODO
                //Create some frame work to return response in standard way
                //throw some custom status code and meaningfull error message to client
                throw new Exception("Bad request");
            }

            var response =
                await _dbContext.Films.Select(p => new GetFilm.Response
                {
                    Id = p.Id,
                    Director = p.Director,
                    EpisodeId = p.EpisodeId,
                    OpeningCrawl = p.OpeningCrawl,
                    Producer = p.Producer,
                    Title = p.Title,
                    ReleaseDate = p.ReleaseDate,
                    Created = DateTime.UtcNow,
                    Edited = DateTime.UtcNow,
                    PosterPath = p.PosterPath
                })
                .FirstOrDefaultAsync(x=> x.Id == request.Id);

            if (response != null)
            {
                var query = from character in _dbContext.Characters
                            join people in _dbContext.Peoples
                            on character.PeopleId equals people.Id
                            select new CharacterOps
                            {
                                FilmId = character.FilmId,
                                Id = character.Id,
                                PeopleId = character.PeopleId,
                                Name = people.Name
                            };

                var characters =
                    await query
                    .Where(p => response.Id  == p.FilmId)
                    .ToListAsync();

                if (characters.Any())
                {
                    response.Peoples = characters
                        .Where(c => c.FilmId == response.Id)
                        .Select(x => new GetFilm.PeopleOut
                        {
                            Id = x.PeopleId,
                            Name = x.Name
                        })
                        .ToList();
                }
            }

            return response;
        }

        public class CharacterOps
        {
            public string Id { get; set; }
            public string FilmId { get; set; }
            public string Name { get; set; }
            public string PeopleId { get; set; }
        }

        public class GetFilmValidator : AbstractValidator<GetFilm.Request>
        {
            public GetFilmValidator()
            {
                RuleFor(t => t.Id).NotEmpty();
            }
        }
    }
}
