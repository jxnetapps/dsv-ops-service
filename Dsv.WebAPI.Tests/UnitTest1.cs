using Dsv.Services.Data;
using Dsv.Services.Domains;

namespace Dsv.WebAPI.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CreatePeopleTest()
        {
            var user = new People
            {
                Id = Guid.NewGuid().ToString(),
                Dob = "2020",
                Created = DateTime.UtcNow,
                Edited = DateTime.UtcNow,
                Gender = "Gender",
                Email = "",
                Name = "Sampath"
            };

            using (var context = new DsvServiceDbContext())
            {
                context.Peoples.Add(user);
                context.SaveChanges();
            }

            People obj;

            using (var context = new DsvServiceDbContext())
            {
                obj = context.Peoples.FirstOrDefault(x => x.Id == user.Id);
            }

            Assert.AreEqual(user.Name, obj.Name);
        }
    }
}