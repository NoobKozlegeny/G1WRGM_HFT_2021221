using G1WRGM_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Data
{
    public class SocialMediaDbContext : DbContext
    {
        public virtual DbSet<SocialMedia> SocialMedias { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public SocialMediaDbContext()
        {
            this.Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\SocialMediaDatabase.mdf;Integrated Security=True");



            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-Many Foreign Key reliationship between SocialMedia and Users
            modelBuilder.Entity<SocialMedia>(entity =>
            {
                entity.HasMany(media => media.Users).WithOne(user => user.SocialMedia);
            });
            //One-Many Foreign Key reliationship between Users and Posts
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasMany(users => users.AllPosts).WithOne(post => post.User);
            });
            //SocialMedia Database default rows
            modelBuilder.Entity<SocialMedia>().HasData(new SocialMedia { SocialMediaName = "Facebook", Creation = 2004, Users = null });
            modelBuilder.Entity<SocialMedia>().HasData(new SocialMedia { SocialMediaName = "Twitter", Creation = 2006, Users = null });
            modelBuilder.Entity<SocialMedia>().HasData(new SocialMedia { SocialMediaName = "Reddit", Creation = 2005, Users = null });
            //Users Database default rows
            modelBuilder.Entity<User>().HasData(new User { UserName = "David Smith", SocialMediaName = "Facebook", UserID = 4323213, AllPosts = null });
            modelBuilder.Entity<User>().HasData(new User { UserName = "Emily Commie(She/They)", SocialMediaName = "Twitter", UserID = 8956232, AllPosts = null });
            modelBuilder.Entity<User>().HasData(new User { UserName = "LivingASlothsLife", SocialMediaName = "Reddit", UserID = 1213464, AllPosts = null });
            //Posts Database default rows
            modelBuilder.Entity<Post>().HasData(new Post { PostID = 31243, UserID = 4323213, Content = "HELLO JULIE ARE YOU RIGHT AND SAY PAUL BROTHER  PHILLIP NEWS SEPARATE MAY AGO FINISH OK TELL", Likes = 1, Dislikes = 0 });
            modelBuilder.Entity<Post>().HasData(new Post { PostID = 89755, UserID = 8956232, Content = "Yeah communism never worked, then explain this: http://arts.u-szeged.hu/tortenelem-180701/bevezetes-oskor", Likes = 234, Dislikes = 0 });
            modelBuilder.Entity<Post>().HasData(new Post { PostID = 24785, UserID = 1213464, Content = "China raises concerns over male characters with feminine traits in Videogames and uses Venti as an example of a character that is problematic.", Likes = 2782, Dislikes = 285 });
        }
    }
}
