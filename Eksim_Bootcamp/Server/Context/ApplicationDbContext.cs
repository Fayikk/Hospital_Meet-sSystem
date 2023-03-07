using Eksim_Bootcamp.Shared;
using Eksim_Bootcamp.Shared.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace Eksim_Bootcamp.Server.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        //protected override void OnModelBuilder(ModelBuilder builder)
        //{
        //    builder.Entity<User>().HasData(
        //        new User
        //        {
                    
        //        }
        //        );
        //}



        public DbSet<User> Users { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Policlinic> Policlinics { get; set; }
        public DbSet<Meet> Meets { get; set; }
    }
}
