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
    internal class GetFilmsHandler
    {
        private readonly IDsvServiceDbContext _dbContext;
        public GetFilmsHandler(IDsvServiceDbContext apiContext)
        {
            _dbContext = apiContext;
        }
        internal async Task<GetFilms.Response> HandleAsync(GetFilms.Request request)
        {
            GetFilmsValidator validator = new GetFilmsValidator();

            var results = validator.Validate(request);

            if (results.IsValid == false)
            {
                //TODO
                //Create some frame work to return response in standard way
                //throw some custom status code and meaningfull error message to client
                throw new Exception("Bad request");
            }

            var items =
                await _dbContext.Films.Select(p => new GetFilms.FilmOut
                {
                    Id = p.Id,
                    PosterPath = p.PosterPath,
                    Title = p.Title,
                    Created = DateTime.UtcNow,
                })
                .ToListAsync();

            return new GetFilms.Response
            {
                Items = items
            };
        }        

        public class GetFilmsValidator : AbstractValidator<GetFilms.Request>
        {
            public GetFilmsValidator()
            {
                //Add validations if required
            }
        }
    }
}
