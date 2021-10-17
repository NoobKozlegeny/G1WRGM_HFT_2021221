using G1WRGM_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Data
{
    //Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="|DataDirectory|\YTDatabase.mdf";Integrated Security=True
    //F:\Egyetemi dolgok\3. Félév\HFT\Projektek\G1WRGM_HFT_2021221\G1WRGM_HFT_2021221.Data\YTDatabase.mdf
    public class YTDbContext : DbContext
    {
        public virtual DbSet<YTContentCreator> YTContentCreators { get; set; }
        public virtual DbSet<Video> Videos { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
        public YTDbContext()
        {
            this.Database.EnsureCreated();
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseLazyLoadingProxies().UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\YTDatabase.mdf;Integrated Security=True");



            }
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //One-Many Foreign Key reliationship between YTContentCreators and Videos
            modelBuilder.Entity<YTContentCreator>(entity =>
            {
                entity.HasMany(ytcc => ytcc.Videos).WithOne(video => video.YTContentCreator);
            });
            //One-Many Foreign Key reliationship between Videos and Comments
            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasMany(video => video.Comments).WithOne(comment => comment.Video);
            });
            //YTContentCreator Database default rows
            List<YTContentCreator> CreatorList = new List<YTContentCreator>()
            {
                new YTContentCreator { CreatorName = "Zsdav", Creation = 2004, SubscriberCount = 10, Videos = null },
                new YTContentCreator { CreatorName = "JustVidman", Creation = 2004, SubscriberCount = 10, Videos = null },
                new YTContentCreator { CreatorName = "Andras Horvath", Creation = 2004, SubscriberCount = 10, Videos = null }
            };
            modelBuilder.Entity<YTContentCreator>().HasData(new YTContentCreator { CreatorName = "Zsdav", Creation = 2004, SubscriberCount = 222 });
            modelBuilder.Entity<YTContentCreator>().HasData(new YTContentCreator { CreatorName = "JustVidman", Creation = 2006 });
            modelBuilder.Entity<YTContentCreator>().HasData(new YTContentCreator { CreatorName = "Andras Horvath", Creation = 2005 });
            //Video Database default rows
            modelBuilder.Entity<Video>().HasData(new Video { Title = "AAA", CreatorName = "Zsdav", VideoID = 4323213 });
            modelBuilder.Entity<Video>().HasData(new Video { Title = "BBB", CreatorName = "JustVidman", VideoID = 8956232 });
            modelBuilder.Entity<Video>().HasData(new Video { Title = "CCC", CreatorName = "Andras Horvath", VideoID = 1213464 });
            //Comment Database default rows
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentID = 31243, VideoID = 4323213, Content = "HELLO JULIE ARE YOU RIGHT AND SAY PAUL BROTHER  PHILLIP NEWS SEPARATE MAY AGO FINISH OK TELL", Likes = 1 });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentID = 89755, VideoID = 8956232, Content = "Yeah communism never worked, then explain this: http://arts.u-szeged.hu/tortenelem-180701/bevezetes-oskor", Likes = 234 });
            modelBuilder.Entity<Comment>().HasData(new Comment { CommentID = 24785, VideoID = 1213464, Content = "China raises concerns over male characters with feminine traits in Videogames and uses Venti as an example of a character that is problematic.", Likes = 2782 });
        }
    }
}
