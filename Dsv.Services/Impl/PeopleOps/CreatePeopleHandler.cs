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
    internal class CreatePeopleHandler
    {
        private readonly IDsvServiceDbContext _dbContext;
        public CreatePeopleHandler(IDsvServiceDbContext apiContext)
        {
            _dbContext = apiContext;
        }
        internal async Task<CreatePeople.Response> HandleAsync(CreatePeople.Request request)
        {
            CreatePeopleValidator validator = new CreatePeopleValidator();

            var results = validator.Validate(request);

            if (results.IsValid == false)
            {
                //TODO
                //Throw some custom status code and meaningfull error message to user
                throw new Exception("Bad request");
            }

            var peopleToAdd = new People
            {
                Id = Guid.NewGuid().ToString(),
                Name = request.Name,
                Dob = request.BirthYear,
                Gender = request.Gender,
                Email = request.Height,
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow,
            };

            _dbContext.Peoples.Add(peopleToAdd);
            await _dbContext.SaveChangesAsync();

            await Task.CompletedTask;

            return new CreatePeople.Response
            {
                Id = peopleToAdd.Id,
                IsSuccess = true
            };
        }

        public class CreatePeopleValidator : AbstractValidator<CreatePeople.Request>
        {
            public CreatePeopleValidator()
            {
                RuleFor(t => t.Name).NotEmpty();
            }
        }
    }
}
