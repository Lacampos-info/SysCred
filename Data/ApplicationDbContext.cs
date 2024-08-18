using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SysCred.Models;

namespace SysCred.Data {
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) {
        }

        // Defina os DbSets para as suas entidades aqui, por exemplo:
        // public DbSet<Event> Events { get; set; }
    }
}
