using Microsoft.EntityFrameworkCore;
 
namespace ProfileManagement.Models
{
    public class ProfileDetailsContext : DbContext
    {
          public ProfileDetailsContext(DbContextOptions<ProfileDetailsContext> options)
            : base(options) 
        {
            
        }
 

        public DbSet<ProfileDetails> ProfileDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Seed();
        }
    
    }

}