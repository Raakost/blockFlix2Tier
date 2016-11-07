using BlockFlixDLL.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlockFlixDLL.Contexts
{
    public class MovieShopContext : DbContext
    {
        public MovieShopContext() : base("BlockFlix")
        {
            Database.SetInitializer(new MovieShopDbInitializer());
        }

        public virtual DbSet<Genre> Genres { get; set; }
        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<Address> Addreses { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Customer> Customers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>()
                .HasMany(t => t.Genres)
                .WithMany(t => t.Movies)
                .Map(t => t.MapLeftKey("MovieID").MapRightKey("GenreID").ToTable("MovieGenre"));

            modelBuilder.Entity<Order>().HasMany(x => x.Movies).WithMany();
            base.OnModelCreating(modelBuilder);
        }
    }
}
