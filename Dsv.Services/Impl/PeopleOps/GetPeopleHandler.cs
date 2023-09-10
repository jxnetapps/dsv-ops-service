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
using static Dsv.Services.Impl.PeopleOps.CreatePeopleHandler;

namespace Dsv.Services.Impl.PeopleOps
{
    internal class GetPeopleHandler
    {
        private readonly IDsvServiceDbContext _dbContext;
        public GetPeopleHandler(IDsvServiceDbContext apiContext)
        {
            _dbContext = apiContext;
        }
        internal async Task<GetPeople.Response> HandleAsync(GetPeople.Request request)
        {
            GetPeopleValidator validator = new GetPeopleValidator();

            var results = validator.Validate(request);

            if (results.IsValid == false)
            {
                //TODO
                //Create some frame work to return response in standard way
                //throw some custom status code and meaningfull error message to client
                throw new Exception("Bad request");
            }

            var response =
                await _dbContext.Peoples.Select(p => new GetPeople.Response
                {
                    Id = p.Id,
                    Name = p.Name,
                    Email = p.Email,
                    Gender = p.Gender,
                    Dob = p.Dob,
                    Created = DateTime.UtcNow,
                    Edited = DateTime.UtcNow
                })
                .FirstOrDefaultAsync(x => x.Id == request.Id);

            if (response != null)
            {
                var query = from character in _dbContext.Characters
                            join film in _dbContext.Films
                            on character.FilmId equals film.Id
                            select new CharacterOps
                            {
                                FilmId = film.Id,
                                Id = character.Id,
                                PeopleId = character.PeopleId,
                                Title = film.Title
                            };

                var characters =
                    await query
                    .Where(p => response.Id == p.PeopleId)
                    .ToListAsync();

                if (characters.Any())
                {
                    response.Films = characters
                        .Where(c => c.PeopleId == response.Id)
                        .Select(x => new GetPeople.FilmOut
                        {
                            Id = x.FilmId,
                            Title = x.Title
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
            public string Title { get; set; }
            public string PeopleId { get; set; }
        }

        public class GetPeopleValidator : AbstractValidator<GetPeople.Request>
        {
            public GetPeopleValidator()
            {
                RuleFor(t => t.Id).NotEmpty();
            }
        }
    }
}
