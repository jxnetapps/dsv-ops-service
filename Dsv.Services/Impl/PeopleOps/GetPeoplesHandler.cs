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
    internal class GetPeoplesHandler
    {
        private readonly IDsvServiceDbContext _dbContext;
        public GetPeoplesHandler(IDsvServiceDbContext apiContext)
        {
            _dbContext = apiContext;
        }
        internal async Task<GetPeoples.Response> HandleAsync(GetPeoples.Request request)
        {
            GetPeoplesValidator validator = new GetPeoplesValidator();

            var results = validator.Validate(request);

            if (results.IsValid == false)
            {
                //TODO
                //Create some frame work to return response in standard way
                //throw some custom status code and meaningfull error message to client
                throw new Exception("Bad request");
            }

            var items =
                await _dbContext.Peoples.Select(p => new GetPeoples.PeopleOut
                {
                    Id = p.Id,
                    Name = p.Name,
                    Email = p.Email,
                    Gender = p.Gender,
                    Dob = p.Dob,
                    Created = DateTime.UtcNow
                })
                .ToListAsync();

            if (items.Any())
            {
                var users =
                    items
                    .Select(x => x.Id)
                    .ToList();

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
                    .Where(p => users.Contains(p.PeopleId))
                    .ToListAsync();

                if (characters.Any())
                {
                    items.ForEach(p =>
                    {
                        p.Films = characters
                        .Where(c => c.PeopleId == p.Id)
                        .Select(x => new GetPeoples.FilmOut
                        {
                            Id = x.FilmId,
                            Title = x.Title
                        })
                        .ToList();
                    });
                }
            }

            return new GetPeoples.Response
            {
                Items = items
            };
        }

        public class CharacterOps
        {
            public string Id { get; set; }
            public string FilmId { get; set; }
            public string Title { get; set; }
            public string PeopleId { get; set; }
        }

        public class GetPeoplesValidator : AbstractValidator<GetPeoples.Request>
        {
            public GetPeoplesValidator()
            {
                //Add validations if required
            }
        }
    }
}
