using Dsv.Services.Domains;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dsv.Services.Data
{
    public interface IDsvServiceDbContext
    {
        DbSet<Film> Films { get; set; }
        DbSet<People> Peoples { get; set; }
        DbSet<Character> Characters { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());
    }
}
