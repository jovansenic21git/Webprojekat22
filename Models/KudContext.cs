using Microsoft.EntityFrameworkCore;

namespace Models
{
    public class KudContext: DbContext
    {
        public DbSet<Ansambl> ansambls{ get; set;}
        public DbSet<Clan> clans{get; set;}
        public DbSet<Kud> kuds{get; set;}

        public DbSet<Rukovodilac> rukovodilacs{get; set;}

        public DbSet<Spoj> spojs{ get; set;}

        public DbSet<Clanarina> clanarinas{get; set;}


        public KudContext(DbContextOptions options):base(options)
        {}

        /*protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rukovodilac>()
                        .HasOne<Ansambl>()
                        .WithOne(p => p.rukovodilac);
        }*/
    
    } 
}