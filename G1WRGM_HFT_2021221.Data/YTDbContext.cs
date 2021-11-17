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
                new YTContentCreator { CreatorID = 1, CreatorName = "Zsdav", Creation = 2008, SubscriberCount = 540000 },
                new YTContentCreator { CreatorID = 2, CreatorName = "JustVidman", Creation = 2013, SubscriberCount = 695000 },
                new YTContentCreator { CreatorID = 3, CreatorName = "Andras Horvath", Creation = 2006, SubscriberCount = 166000 },
                new YTContentCreator { CreatorID = 4, CreatorName = "Pottyondy Edina", Creation = 2013, SubscriberCount = 151000 },
                new YTContentCreator { CreatorID = 5, CreatorName = "Chenge-chan", Creation = 2020, SubscriberCount = 1730 },
                new YTContentCreator { CreatorID = 6, CreatorName = "StrawberrySana", Creation = 2011, SubscriberCount = 89700 }
            };
            

            //Video Database default rows
            List<Video> VideoList = new List<Video>()
            {
                new Video { Title = "Így lesz pénzed az álmaid megvalósításához! | Katasztrofális Termékek #8",
                    CreatorID = CreatorList[1].CreatorID, VideoID = 1, ViewCount = 495203 },
                new Video { Title = "A reddit mélyén #1 - Búzától a szektáig", 
                    CreatorID = CreatorList[1].CreatorID, VideoID = 2, ViewCount = 1131025 },
                new Video { Title = "Autós kisokos", 
                    CreatorID = CreatorList[3].CreatorID, VideoID = 3, ViewCount = 211211 },
                new Video { Title = "Egri Csillagok Röviden",
                    CreatorID = CreatorList[4].CreatorID, VideoID = 4, ViewCount = 6054 },
                new Video { Title = "Natsuki ASMR - Beating You Unconscious Until You Fall Asleep",
                    CreatorID = CreatorList[7].CreatorID, VideoID = 5, ViewCount = 38571 },
                new Video { Title = "You Natsuki'd In The Wrong Literature Club",
                    CreatorID = CreatorList[7].CreatorID, VideoID = 6, ViewCount = 35752 },
                new Video { Title = "Elektromos autóval KÜLFÖLDÖN tölteni? Hát...",
                    CreatorID = CreatorList[2].CreatorID, VideoID = 7, ViewCount = 79159 },
                new Video { Title = "KAKI GOLYÓ!",
                    CreatorID = CreatorList[0].CreatorID, VideoID = 8, ViewCount = 38436 },
                new Video { Title = "VTuber Chenge-chan bemutatja: A Csillagharcos Szemű Juhász",
                    CreatorID = CreatorList[4].CreatorID, VideoID = 9, ViewCount = 3696 },
                new Video { Title = "ZsDav adventures: Rókák a pincémben",
                    CreatorID = CreatorList[0].CreatorID, VideoID = 10, ViewCount = 2546764 },
                new Video { Title = "Chenge-chan betyáros gulyáslevese",
                    CreatorID = CreatorList[4].CreatorID, VideoID = 11, ViewCount = 7308 },
                new Video { Title = "Ezért nem fogsz tudni autót venni. Meg mást sem…",
                    CreatorID = CreatorList[2].CreatorID, VideoID = 12, ViewCount = 255726 },
            };
            

            //Comment Database default rows
            List<Comment> CommentList = new List<Comment>()
            {
                new Comment { CommentID = 1, VideoID = VideoList[10].VideoID, Username = "Chenge simp",  
                    Content = "CHENGE-CHANT KORMÁNYZÓNAK", Likes = 99999 },
                new Comment { CommentID = 2, VideoID = VideoList[1].VideoID, Username = "Emília[She/They]", 
                    Content = "JustVidman best UwU", Likes = 234 },
                new Comment { CommentID = 3, VideoID = VideoList[5].VideoID, Username = "BasedDude", 
                    Content = "Littest song cover ever heard ngl", Likes = 67 },
                new Comment { CommentID = 4, VideoID = VideoList[5].VideoID, Username = "Chungus Bungus",
                    Content = "Strawberry more like Strawman", Likes = 234 },
                new Comment { CommentID = 5, VideoID = VideoList[8].VideoID, Username = "Edit",
                    Content = "Nálunk drágább volt a töltés", Likes = 15 },
                new Comment { CommentID = 6, VideoID = VideoList[2].VideoID, Username = "Yasuomain",
                    Content = "r/hungary-t kihagytad XDDDD", Likes = -46 },
                new Comment { CommentID = 7, VideoID = VideoList[10].VideoID, Username = "Lósétáló",
                    Content = "Kövi videó mikor lesz?", Likes = 35452 },
                new Comment { CommentID = 8, VideoID = VideoList[9].VideoID, Username = "McGamerSquidGame",
                    Content = "Peak Zsdav videó volt ez", Likes = 329 },
                new Comment { CommentID = 9, VideoID = VideoList[5].VideoID, Username = "YukoRetina",
                    Content = "When the Impostor is NOT SUS", Likes = 26 }
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
