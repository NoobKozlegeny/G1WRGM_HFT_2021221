using G1WRGM_HFT_2021221.Logic.Classes;
using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Models;
using G1WRGM_HFT_2021221.Repository.Interfaces;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Test
{
    [TestFixture]
    public class Tester
    {
        YTContentCreatorLogic ytccLogic;
        Mock<IYTContentCreatorRepository> mockYtccRepo;
        VideoLogic videoLogic;
        Mock<IVideoRepository> mockVideoRepo;
        CommentLogic commentLogic;
        Mock<ICommentRepository> mockCommentRepo;

        List<YTContentCreator> ytccsList;
        List<Video> videosList;
        List<Comment> commentsList;

        [SetUp]
        public void Init()
        {
            //Mock init
            mockYtccRepo = new Mock<IYTContentCreatorRepository>();
            mockVideoRepo = new Mock<IVideoRepository>();
            mockCommentRepo = new Mock<ICommentRepository>();

            //Datas
            var ytccs = new List<YTContentCreator>();
            YTContentCreator ytcc1 = new YTContentCreator()
            {
                Creation = 2009,
                CreatorID = 1,
                CreatorName = "Test 1",
                SubscriberCount = 43456
                //Videos = 
            };
            YTContentCreator ytcc2 = new YTContentCreator()
            {
                Creation = 2011,
                CreatorID = 2,
                CreatorName = "Test 2",
                SubscriberCount = 438
            };
            YTContentCreator ytcc3 = new YTContentCreator()
            {
                Creation = 2019,
                CreatorID = 3,
                CreatorName = "Test 3",
                SubscriberCount = 9234921
            };

            var videos = new List<Video>();
            Video v1 = new Video()
            {
                Title = "Video 1",
                VideoID = 1,
                CreatorID = 1,
                ViewCount = 33023,
                YTContentCreator = ytcc1
            }; //0
            Video v2 = new Video()
            {
                Title = "Video 2",
                VideoID = 2,
                CreatorID = 1,
                ViewCount = 4542,
                YTContentCreator = ytcc1
            }; //1
            Video v3 = new Video()
            {
                Title = "Video 3",
                VideoID = 3,
                CreatorID = 3,
                ViewCount = 122,
                YTContentCreator = ytcc3
            }; //2
            Video v4 = new Video()
            {
                Title = "Video 4",
                VideoID = 4,
                CreatorID = 3,
                ViewCount = 567655,
                YTContentCreator = ytcc3
            }; //3
            Video v5 = new Video()
            {
                Title = "Video 5",
                VideoID = 5,
                CreatorID = 3,
                ViewCount = 3123,
                YTContentCreator = ytcc3
            }; //4

            var comments = new List<Comment>()
            {
                new Comment()
                {
                    CommentID = 1,
                    VideoID = 1,
                    Content = "I'd just like to interject for a moment. What you're referring to as Linux, is in fact, GNU/Linux, or as I've recently taken to calling it, GNU plus Linux. Linux is not an operating system unto itself, but rather another free component of a fully functioning GNU system made useful by the GNU corelibs, shell utilities and vital system components comprising a full OS as defined by POSIX. " +
                    "Many computer users run a modified version of the GNU system every day, without realizing it. Through a peculiar turn of events, the version of GNU which is widely used today is often called Linux, and many of its users are not aware that it is basically the GNU system, developed by the GNU Project." +
                    "There really is a Linux, and these people are using it, but it is just a part of the system they use. Linux is the kernel: the program in the system that allocates the machine's resources to the other programs that you run. The kernel is an essential part of an operating system, but useless by itself; it can only function in the context of a complete operating system. Linux is normally used in combination with the GNU operating system: the whole system is basically GNU with Linux added, or GNU/Linux. All the so-called Linux distributions are really distributions of GNU/Linux.",
                    Likes = 236,
                    Username = "Sanyi",
                    Video = v1
                }, //0
                new Comment()
                {
                    CommentID = 2,
                    VideoID = 1,
                    Content = "Comment 2",
                    Likes = -11,
                    Username = "Róbert",
                    Video = v1
                }, //1
                new Comment()
                {
                    CommentID = 3,
                    VideoID = 2,
                    Content = "Comment 3",
                    Likes = 0,
                    Username = "Lali",
                    Video = v2
                }, //2
                new Comment()
                {
                    CommentID = 4,
                    VideoID = 1,
                    Content = "Comment 4",
                    Likes = -234,
                    Username = "LOLCAT",
                    Video = v1
                }, //3
                new Comment()
                {
                    CommentID = 5,
                    VideoID = 1,
                    Content = "Comment 5",
                    Likes = 99438,
                    Username = "BillyHairRefresher",
                    Video = v1
                }, //4
                new Comment()
                {
                    CommentID = 6,
                    VideoID = 4,
                    Content = "Comment 6",
                    Likes = -22,
                    Username = "Tororo",
                    Video = v4
                }, //5
                new Comment()
                {
                    CommentID = 7,
                    VideoID = 4,
                    Content = "Comment 7",
                    Likes = 2232,
                    Username = "Kirby",
                    Video = v4
                }, //6
                new Comment()
                {
                    CommentID = 8,
                    VideoID = 5,
                    Content = "Comment 8",
                    Likes = 111,
                    Username = "KittyKattyWarCrimesHappenedHere",
                    Video = v5
                }, //7
                new Comment()
                {
                    CommentID = 9,
                    VideoID = 5,
                    Content = "Comment 9",
                    Likes = 0,
                    Username = "RattataBoom",
                    Video = v5
                }  //8
            }.AsQueryable();

            //Connecting Comment entities to Video entities
            v1.Comments.Add(comments.ToList()[0]);
            v1.Comments.Add(comments.ToList()[1]);
            v1.Comments.Add(comments.ToList()[3]);
            v1.Comments.Add(comments.ToList()[4]);
            v2.Comments.Add(comments.ToList()[2]);
            v4.Comments.Add(comments.ToList()[5]);
            v4.Comments.Add(comments.ToList()[6]);
            v5.Comments.Add(comments.ToList()[7]);
            v5.Comments.Add(comments.ToList()[8]);

            //Adding Video entities to videos
            videos.Add(v1);
            videos.Add(v2);
            videos.Add(v3);
            videos.Add(v4);
            videos.Add(v5);

            //Connecting Video entities to YTContentCreator entities
            ytcc1.Videos.Add(v1);
            ytcc1.Videos.Add(v2);
            ytcc3.Videos.Add(v3);
            ytcc3.Videos.Add(v4);
            ytcc3.Videos.Add(v5);

            //Adding YTContentCreator entities to ytccs
            ytccs.Add(ytcc1);
            ytccs.Add(ytcc2);
            ytccs.Add(ytcc3);

            mockYtccRepo.Setup((t) => t.ReadAll()).Returns(ytccs.AsQueryable());
            mockVideoRepo.Setup((t) => t.ReadAll()).Returns(videos.AsQueryable());
            mockCommentRepo.Setup((t) => t.ReadAll()).Returns(comments);

            mockYtccRepo.Setup((t) => t.Read(1)).Returns(ytcc1);
            
            ytccLogic = new YTContentCreatorLogic(mockYtccRepo.Object);
            videoLogic = new VideoLogic(mockVideoRepo.Object);
            commentLogic = new CommentLogic(mockCommentRepo.Object);

            //Testing workaround
            ytccsList = ytccs.ToList();
            videosList = videos.ToList();
            commentsList = comments.ToList();
        }

        //YTContentCreator

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-2, Description = "GetAllNegativeCommentsFromYoutuberWhenIdIsNegative")]
        public void GetAllNegativeCommentsFromYoutuberTest(int id)
        {
            //ARRANGE
            
            //ACT
            List<Comment> expected1 = new List<Comment>() { commentsList[1], commentsList[3] };
            IEnumerable<Comment> expected2 = Enumerable.Empty<Comment>(); //Kinda hesitant if this belongs in ARRANGE or ACT
            List<Comment> expected3 = new List<Comment>() { commentsList[5] };
            //ASSERT
            switch (id)
            {
                case -2:
                    Assert.Throws<IndexOutOfRangeException>(() => ytccLogic.GetAllNegativeCommentsFromYoutuber(id));
                    break;
                case 1:
                    Assert.AreEqual(ytccLogic.GetAllNegativeCommentsFromYoutuber(id).ToList(), expected1); 
                    break;
                case 2:
                    Assert.AreEqual(ytccLogic.GetAllNegativeCommentsFromYoutuber(id).ToList(), expected2);
                    break;
                case 3:
                    Assert.AreEqual(ytccLogic.GetAllNegativeCommentsFromYoutuber(id).ToList(), expected3);
                    break;
                default:
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-2, Description = "VideosWithMoreThan30KViewsFromYoutuberWhenIdIsNegative")]
        public void VideosWithMoreThan30KViewsFromYoutuberTest(int id)
        {
            //ARRANGE

            //ACT
            List<Video> expected1 = new List<Video>() { videosList[0] };
            IEnumerable<Video> expected2 = Enumerable.Empty<Video>();
            List<Video> expected3 = new List<Video>() { videosList[3] };
            //ASSERT
            switch (id)
            {
                case -2:
                    Assert.Throws<IndexOutOfRangeException>(() => ytccLogic.VideosWithMoreThan30KViewsFromYoutuber(id));
                    break;
                case 1:
                    Assert.AreEqual(ytccLogic.VideosWithMoreThan30KViewsFromYoutuber(id).ToList(), expected1);
                    break;
                case 2:
                    Assert.AreEqual(ytccLogic.VideosWithMoreThan30KViewsFromYoutuber(id).ToList(), expected2);
                    break;
                case 3:
                    Assert.AreEqual(ytccLogic.VideosWithMoreThan30KViewsFromYoutuber(id).ToList(), expected3);
                    break;
                default:
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(-2)]
        public void GetVideosWithCommentsFromYoutuberTest(int id)
        {
            //ARRANGE

            //ACT
            List<Video> expected1 = new List<Video>() { videosList[0], videosList[1] };
            IEnumerable<Video> expected2 = Enumerable.Empty<Video>();
            List<Video> expected3 = new List<Video>() { videosList[3], videosList[4] };
            //ASSERT
            switch (id)
            {
                case -2:
                    Assert.Throws<IndexOutOfRangeException>(() => ytccLogic.GetVideosWithCommentsFromYoutuber(id));
                    break;
                case 1:
                    Assert.AreEqual(ytccLogic.GetVideosWithCommentsFromYoutuber(id).ToList(), expected1);
                    break;
                case 2:
                    Assert.AreEqual(ytccLogic.GetVideosWithCommentsFromYoutuber(id).ToList(), expected2);
                    break;
                case 3:
                    Assert.AreEqual(ytccLogic.GetVideosWithCommentsFromYoutuber(id).ToList(), expected3);
                    break;
                default:
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void CreateForYTContentCreatorLogicTest(int helper)
        {
            //ARRANGE
            YTContentCreator ytcc1 = null; //TestCase(1)
            YTContentCreator ytcc2 = new YTContentCreator() //TestCase(2)
            {
                Creation = 2019,
                CreatorID = 4,
                CreatorName = "LolBoi",
                SubscriberCount = 9943543
                //Videos = 
            };
            //ACT
            //ASSERT
            switch (helper)
            {
                case 1:
                    Assert.Throws<ArgumentNullException>(() => ytccLogic.Create(ytcc1));
                    break;
                case 2:
                    Assert.That(() => ytccLogic.Create(ytcc2), Throws.Nothing);
                    break;
                default:
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void UpdateForYTContentCreatorLogicTest(int helper)
        {
            //ARRANGE
            YTContentCreator ytcc1 = null; //TestCase(1)
            YTContentCreator ytcc2 = new YTContentCreator() //TestCase(2)
            {
                Creation = 2019,
                CreatorID = 4,
                CreatorName = "LolBoi",
                SubscriberCount = 9943543
                //Videos = 
            };
            //ACT
            //ASSERT
            switch (helper)
            {
                case 1:
                    Assert.Throws<ArgumentNullException>(() => ytccLogic.Update(ytcc1));
                    break;
                case 2:
                    Assert.That(() => ytccLogic.Update(ytcc2), Throws.Nothing);
                    break;
                default:
                    break;
            }
        }

        //Video
        [TestCase(1)]
        [TestCase(2)]
        [TestCase(3)]
        [TestCase(4)]
        [TestCase(5)]
        [TestCase(-2)]
        public void First3MostLikedCommentFromVideo(int id)
        {
            //ARRANGE
            //ACT
            List<Comment> expected1 = new List<Comment>() { commentsList[4], commentsList[0], commentsList[1] };
            List<Comment> expected2 = new List<Comment>() { commentsList[2] };
            IEnumerable<Comment> expected3 = Enumerable.Empty<Comment>();
            List<Comment> expected4 = new List<Comment>() { commentsList[6], commentsList[5] };
            List<Comment> expected5 = new List<Comment>() { commentsList[7], commentsList[8] };
            //ASSERT
            switch (id)
            {
                case -2:
                    Assert.Throws<IndexOutOfRangeException>(() => videoLogic.First3MostLikedCommentFromVideo(id));
                    break;
                case 1:
                    Assert.AreEqual(videoLogic.First3MostLikedCommentFromVideo(id).ToList(), expected1);
                    break;
                case 2:
                    Assert.AreEqual(videoLogic.First3MostLikedCommentFromVideo(id).ToList(), expected2);
                    break;
                case 3:
                    Assert.AreEqual(videoLogic.First3MostLikedCommentFromVideo(id).ToList(), expected3);
                    break;
                case 4:
                    Assert.AreEqual(videoLogic.First3MostLikedCommentFromVideo(id).ToList(), expected4);
                    break;
                case 5:
                    Assert.AreEqual(videoLogic.First3MostLikedCommentFromVideo(id).ToList(), expected5);
                    break;
                default:
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void CreateForVideoLogicTest(int helper)
        {
            //ARRANGE
            Video v1 = null;
            Video v2 = new Video()
            {
                Title = "Video LOLLLLLL",
                VideoID = 6,
                //CreatorID = null,
                ViewCount = 33023,
                //YTContentCreator = null
            };
            //ACT
            //ASSERT
            switch (helper)
            {
                case 1:
                    Assert.Throws<ArgumentNullException>(() => videoLogic.Create(v1));
                    break;
                case 2:
                    Assert.That(() => videoLogic.Create(v2), Throws.Nothing);
                    break;
                default:
                    break;
            }
        }

        [TestCase(1)]
        [TestCase(2)]
        public void UpdateForVideoLogicTest(int helper)
        {
            //ARRANGE
            Video v1 = null;
            Video v2 = new Video()
            {
                Title = "Video LOLLLLLL",
                VideoID = 6,
                //CreatorID = null,
                ViewCount = 33023,
                //YTContentCreator = null
            };
            //ACT
            //ASSERT
            switch (helper)
            {
                case 1:
                    Assert.Throws<ArgumentNullException>(() => videoLogic.Update(v1));
                    break;
                case 2:
                    Assert.That(() => videoLogic.Update(v2), Throws.Nothing);
                    break;
                default:
                    break;
            }
            
        }

        //Comment
        [TestCase(1)]
        [TestCase(2)]
        public void CreateForCommentLogicTest(int helper)
        {
            //ARRANGE
            Comment c1 = null;
            Comment c2 = new Comment()
            {
                CommentID = 10,
                Username = "XDDGamer",
                Content = "SWAG YOLO SHREK",
                //CreatorID = null,
                Likes = 111
                //YTContentCreator = null
            };
            //ACT
            //ASSERT
            switch (helper)
            {
                case 1:
                    Assert.Throws<ArgumentNullException>(() => commentLogic.Create(c1));
                    break;
                case 2:
                    Assert.That(() => commentLogic.Create(c2), Throws.Nothing);
                    break;
                default:
                    break;
            }         
        }

        [TestCase(1)]
        [TestCase(2)]
        public void UpdateForCommentLogicTest(int helper)
        {
            //ARRANGE
            Comment c1 = null;
            Comment c2 = new Comment()
            {
                CommentID = 10,
                Username = "XDDGamer",
                Content = "SWAG YOLO SHREK",
                //CreatorID = null,
                Likes = 111
                //YTContentCreator = null
            };
            //ACT
            //ASSERT
            switch (helper)
            {
                case 1:
                    Assert.Throws<ArgumentNullException>(() => commentLogic.Update(c1));
                    break;
                case 2:
                    Assert.That(() => commentLogic.Update(c2), Throws.Nothing);
                    break;
                default:
                    break;
            }
        }

        [Test]
        public void GetMostLikedCommentsPerVideosTest()
        {
            //ARRANGE
            //ACT
            IEnumerable<KeyValuePair<string, Comment>> result = videoLogic.GetMostLikesCommentsFromVideos();
            List<KeyValuePair<string, Comment>> expected = new List<KeyValuePair<string, Comment>>()
            { 
                new KeyValuePair<string, Comment>("Video 1", commentsList[4]),
                new KeyValuePair<string, Comment>("Video 2", commentsList[2]),
                new KeyValuePair<string, Comment>("Video 3", null),
                new KeyValuePair<string, Comment>("Video 4", commentsList[6]),
                new KeyValuePair<string, Comment>("Video 5", commentsList[7])
            };
            //ASSERT
            Assert.AreEqual(result.ToList(), expected);
        }
    }
}
