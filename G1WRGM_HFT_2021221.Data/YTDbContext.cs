using G1WRGM_HFT_2021221.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Data
{
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
                entity.HasMany(ytcc => ytcc.Videos).WithOne(video => video.YTContentCreator)
                .HasForeignKey(video => video.CreatorID).OnDelete(DeleteBehavior.Restrict);
            });
            //One-Many Foreign Key reliationship between Videos and Comments
            modelBuilder.Entity<Video>(entity =>
            {
                entity.HasMany(video => video.Comments).WithOne(comment => comment.Video)
                .HasForeignKey(comment => comment.VideoID).OnDelete(DeleteBehavior.Restrict);
            });


            //YTContentCreator Database default rows
            List<YTContentCreator> CreatorList = new List<YTContentCreator>()
            {
                new YTContentCreator { CreatorID = 1, CreatorName = "Zsdav", Creation = 2008, SubscriberCount = 538000 },
                new YTContentCreator { CreatorID = 2, CreatorName = "JustVidman", Creation = 2013, SubscriberCount = 692000 },
                new YTContentCreator { CreatorID = 3, CreatorName = "Andras Horvath", Creation = 2006, SubscriberCount = 166000 }
            };
            

            //Video Database default rows
            List<Video> VideoList = new List<Video>()
            {
                new Video { Title = "AAA", CreatorID = CreatorList[0].CreatorID, VideoID = 1,
                    ViewCount = 312234 },
                new Video { Title = "BBB", CreatorID = CreatorList[1].CreatorID, VideoID = 2,
                    ViewCount = 993231 },
                new Video { Title = "CCC", CreatorID = CreatorList[2].CreatorID, VideoID = 3,
                    ViewCount = 23144 }
            };
            

            //Comment Database default rows
            List<Comment> CommentList = new List<Comment>()
            {
                new Comment { CommentID = 1, VideoID = VideoList[0].VideoID, Username = "Joe Bob",  
                    Content = "HELLO JULIE ARE YOU RIGHT AND SAY PAUL BROTHER  PHILLIP NEWS SEPARATE MAY AGO FINISH OK TELL", Likes = 1 },
                new Comment { CommentID = 2, VideoID = VideoList[1].VideoID, Username = "Emily[She/They]", 
                    Content = "Yeah communism never worked, then explain this: http://arts.u-szeged.hu/tortenelem-180701/bevezetes-oskor", Likes = 234 },
                new Comment { CommentID = 3, VideoID = VideoList[2].VideoID, Username = "BasedDude", 
                    Content = "China raises concerns over male characters with feminine traits in Videogames and uses Venti as an example of a character that is problematic.", Likes = 2782 }
            };


            //Adding Lists
            //for (int i = 0; i < VideoList.Count; i++)
            //{
            //    VideoList[i].Comments.Add(CommentList[i]);
            //}
            //for (int i = 0; i < CreatorList.Count; i++)
            //{
            //    CreatorList[i].Videos.Add(VideoList[i]);
            //}


            //Seeding (WHY DO I NEED TO MAKE "new ClassName{...}"???)
            foreach (var item in CreatorList)
            {
                //modelBuilder.Entity<YTContentCreator>().HasData(new YTContentCreator { CreatorID = item.CreatorID, CreatorName = item.CreatorName, Creation = item.Creation, SubscriberCount = item.SubscriberCount });
                modelBuilder.Entity<YTContentCreator>().HasData(item);
            }
            foreach (var item in VideoList)
            {
                //modelBuilder.Entity<Video>().HasData(new Video { Title = item.Title, CreatorID = item.CreatorID, VideoID = item.VideoID });
                modelBuilder.Entity<Video>().HasData(item);
            }
            foreach (var item in CommentList)
            {
                //modelBuilder.Entity<Comment>().HasData(new Comment { CommentID = item.CommentID, VideoID = item.VideoID, Content = item.Content, Likes = item.Likes });
                modelBuilder.Entity<Comment>().HasData(item);
            }
        }
    }
}
