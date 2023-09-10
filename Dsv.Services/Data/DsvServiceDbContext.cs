using Dsv.Services.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Data
{
    public class DsvServiceDbContext : DbContext, IDsvServiceDbContext
    {
        public DsvServiceDbContext()
        {

            Initialize();
        }

        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "DsvDb");
        }
        public DbSet<Film> Films { get; set; }
        public DbSet<People> Peoples { get; set; }
        public DbSet<Character> Characters { get; set; }

        public void Initialize()
        {
            string filmId1 = Guid.NewGuid().ToString();
            string filmId2 = Guid.NewGuid().ToString();
            string filmId3 = Guid.NewGuid().ToString();

            string peopleId1 = Guid.NewGuid().ToString();
            string peopleId2 = Guid.NewGuid().ToString();
            string peopleId3 = Guid.NewGuid().ToString();

            if (!Films.Any())
            {

                Films.AddRange(
                    new Film
                    {
                        Id = filmId1,
                        Title = "MEG2",
                        Director = "James Cameron",
                        EpisodeId = "01",
                        OpeningCrawl = "It is a dark time for the\r\nRebellion. Although the Death\r\nStar has been destroyed,\r\nImperial troops have driven the\r\nRebel forces from their hidden\r\nbase and pursued them across\r\nthe galaxy.\r\n\r\nEvading the dreaded Imperial\r\nStarfleet, a group of freedom\r\nfighters led by Luke Skywalker\r\nhas established a new secret\r\nbase on the remote ice world\r\nof Hoth.\r\n\r\nThe evil lord Darth Vader,\r\nobsessed with finding young\r\nSkywalker, has dispatched\r\nthousands of remote probes into\r\nthe far reaches of space....",
                        Producer = "Gary James Cameron",
                        ReleaseDate = DateTime.UtcNow,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow,
                        PosterPath= "m-1.jpg"
                    },
                    new Film
                    {
                        Id = filmId2,
                        Title = "Strays",
                        Director = "Wolfgang Petersen",
                        EpisodeId = "02",
                        OpeningCrawl = "It is a dark time for the\r\nRebellion. Although the Death\r\nStar has been destroyed,\r\nImperial troops have driven the\r\nRebel forces from their hidden\r\nbase and pursued them across\r\nthe galaxy.\r\n\r\nEvading the dreaded Imperial\r\nStarfleet, a group of freedom\r\nfighters led by Luke Skywalker\r\nhas established a new secret\r\nbase on the remote ice world\r\nof Hoth.\r\n\r\nThe evil lord Darth Vader,\r\nobsessed with finding young\r\nSkywalker, has dispatched\r\nthousands of remote probes into\r\nthe far reaches of space....",
                        Producer = "David Benioff",
                        ReleaseDate = DateTime.UtcNow,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow,
                        PosterPath = "m-2.jpg"

                    },
                    new Film
                    {
                        Id = filmId3,
                        Title = "The Super Mario BROS ",
                        Director = "Andrew Adamson",
                        EpisodeId = "15",
                        OpeningCrawl = "It is a dark time for the\r\nRebellion. Although the Death\r\nStar has been destroyed,\r\nImperial troops have driven the\r\nRebel forces from their hidden\r\nbase and pursued them across\r\nthe galaxy.\r\n\r\nEvading the dreaded Imperial\r\nStarfleet, a group of freedom\r\nfighters led by Luke Skywalker\r\nhas established a new secret\r\nbase on the remote ice world\r\nof Hoth.\r\n\r\nThe evil lord Darth Vader,\r\nobsessed with finding young\r\nSkywalker, has dispatched\r\nthousands of remote probes into\r\nthe far reaches of space....",
                        Producer = "Mark Johnson",
                        ReleaseDate = DateTime.UtcNow,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow,
                        PosterPath = "m-3.jpg"

                    },
                    new Film
                    {
                        Id = Guid.NewGuid().ToString(),
                        Title = "The Lion King",
                        Director = "Anand",
                        EpisodeId = "5",
                        OpeningCrawl = "It is a dark time for the\r\nRebellion. Although the Death\r\nStar has been destroyed,\r\nImperial troops have driven the\r\nRebel forces from their hidden\r\nbase and pursued them across\r\nthe galaxy.\r\n\r\nEvading the dreaded Imperial\r\nStarfleet, a group of freedom\r\nfighters led by Luke Skywalker\r\nhas established a new secret\r\nbase on the remote ice world\r\nof Hoth.\r\n\r\nThe evil lord Darth Vader,\r\nobsessed with finding young\r\nSkywalker, has dispatched\r\nthousands of remote probes into\r\nthe far reaches of space....",
                        Producer = "SHarukh",
                        ReleaseDate = DateTime.UtcNow,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow,
                        PosterPath = "m-4.jpg"
                    });
            }

            if (!Peoples.Any())
            {

                Peoples.AddRange(
                    new People
                    {
                        Id = peopleId1,
                        Name = "Leonardo Dec",
                        Dob = "30-08-1987",
                        Gender = "Male",
                        Email = "leo@esh.com",
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow,
                    },
                     new People
                     {
                         Id = peopleId2,
                         Name = "Peter Hain",
                         Dob = "01-02-1987",
                         Gender = "Male",
                         Email = "peter@gmail.com",
                         Created = DateTime.UtcNow,
                         Edited = DateTime.UtcNow,
                     },
                      new People
                      {
                          Id = peopleId3,
                          Name = "Ket Winslet",
                          Dob = "05-08-1987",
                          Gender = "Female",
                          Email = "Winslet@esh.com",
                          Created = DateTime.UtcNow,
                          Edited = DateTime.UtcNow,
                      },
                       new People
                       {
                           Id = Guid.NewGuid().ToString(),
                           Name = "Jayakumar",
                           Dob = "05-08-1987",
                           Gender = "Male",
                           Email = "jaya@esh.com",
                           Created = DateTime.UtcNow,
                           Edited = DateTime.UtcNow,
                       }
                    );
            }

            if (!Characters.Any())
            {
                Characters.AddRange(

                    new Character
                    {
                        Id = Guid.NewGuid().ToString(),
                        FilmId = filmId1,
                        PeopleId = peopleId1,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow
                    },
                    new Character
                    {
                        Id = Guid.NewGuid().ToString(),
                        FilmId = filmId1,
                        PeopleId = peopleId2,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow
                    },
                    new Character
                    {
                        Id = Guid.NewGuid().ToString(),
                        FilmId = filmId3,
                        PeopleId = peopleId1,
                        Created = DateTime.UtcNow,
                        Edited = DateTime.UtcNow
                    }
                );
            }

            this.SaveChangesAsync();
        }
    }
}
