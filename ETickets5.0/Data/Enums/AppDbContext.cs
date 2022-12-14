
using ETickets5._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ETickets5._0.Data
{
    public class AppDbContext :IdentityDbContext <ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext>options): base(options)   
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Actor_Movie>().HasKey(am => new
            {
                am.ActotId,
                am.MovieId

            });

            modelBuilder.Entity< Actor_Movie>().HasOne(m => m.Movie).WithMany(am =>am.Actor_Movies).HasForeignKey(m => m.MovieId);
            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Actor).WithMany(am => am.Actor_Movies).HasForeignKey(m => m.ActotId);

            base.OnModelCreating(modelBuilder);

        }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Actor_Movie> Actor_Movies { get; set; }
        public DbSet<Cinima> Cinimas { get; set; }
        public DbSet<Producer> Producers { get; set; }
        public DbSet<Drinks> Drinks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<ShoppingCartItem> ShoppingCartItems { get; set; }

    }
}
