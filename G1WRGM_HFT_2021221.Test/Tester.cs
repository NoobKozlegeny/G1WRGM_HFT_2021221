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
            

            var videos = new List<Video>();
            Video v1 = new Video()
            {
                Title = "Video 1",
                VideoID = 1,
                CreatorID = 1,
                ViewCount = 33023,
                YTContentCreator = ytcc1
            };
            Video v2 = new Video()
            {
                Title = "Video 2",
                VideoID = 2,
                CreatorID = 1,
                ViewCount = 4542,
                YTContentCreator = ytcc1
            };

            

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
                },
                new Comment()
                {
                    CommentID = 2,
                    VideoID = 1,
                    Content = "Comment 2",
                    Likes = -11,
                    Username = "Róbert",
                    Video = v1
                },
                new Comment()
                {
                    CommentID = 3,
                    VideoID = 2,
                    Content = "Comment 3",
                    Likes = 0,
                    Username = "Lali",
                    Video = v2
                }
            }.AsQueryable();

            v1.Comments.Add(comments.ToList()[0]);
            v1.Comments.Add(comments.ToList()[1]);
            v2.Comments.Add(comments.ToList()[2]);
            videos.Add(v1);
            videos.Add(v2);
            ytcc1.Videos.Add(videos.ToList()[0]);
            ytcc1.Videos.Add(videos.ToList()[1]);
            ytccs.Add(ytcc1);
            ytccs.Add(ytcc2);

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
        public void GetAllNegativeCommentsFromYoutuberTest(int id)
        {
            //ARRANGE
            
            //ACT
            IEnumerable<Comment> result = ytccLogic.GetAllNegativeCommentsFromYoutuber(id);
            //ASSERT
            Assert.AreEqual(result.First().Likes, -11);
        }

        [TestCase(1)]
        public void VideosWithMoreThan30KViewsFromYoutuberTest(int id)
        {
            //ARRANGE

            //ACT
            IEnumerable<Video> result = ytccLogic.VideosWithMoreThan30KViewsFromYoutuber(id);
            List<Video> expected = new List<Video>();
            expected.Add(videosList[0]);
            //ASSERT
            Assert.AreEqual(result.ToList(), expected);
        }
        [TestCase(1)]
        public void GetVideosWithCommentsFromYoutuberTest(int id)
        {
            //ARRANGE

            //ACT
            IEnumerable<Video> result = ytccLogic.GetVideosWithCommentsFromYoutuber(id);
            List<Video> expected = videosList;
            //ASSERT
            Assert.AreEqual(result.ToList(), expected);
        }

        [TestCase(null)]
        public void CreateForYTContentCreatorLogicTest(YTContentCreator ytcc)
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => ytccLogic.Create(ytcc));
        }

        [Test]
        public void CreateForYTContentCreatorLogicTestWhichWontThrow()
        {
            //ARRANGE
            YTContentCreator ytccTest = new YTContentCreator() //Is this hidden dependency?
            {
                Creation = 2019,
                CreatorID = 3,
                CreatorName = "LolBoi",
                SubscriberCount = 9943543
                //Videos = 
            };
            //ACT
            //ASSERT
            Assert.That(() => ytccLogic.Create(ytccTest), Throws.Nothing);
        }

        [TestCase(null)]
        public void Update(YTContentCreator content)
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => ytccLogic.Update(content));
        }

        //Video
        [TestCase(1)]
        public void FirstXMostLikedCommentFromVideo(int id)
        {
            //ARRANGE
            //ACT
            IEnumerable<Comment> result = videoLogic.First3MostLikedCommentFromVideo(id);
            List<Comment> expected = new List<Comment>() { commentsList[0] };
            //ASSERT
            Assert.AreEqual(result.ToList(), expected);
        }

        [Test]
        public void GetMostWatchedVideoPerYoutubersTest()
        {
            //ARRANGE
            //ACT
            IEnumerable<KeyValuePair<string, Video>> result = videoLogic.GetMostWatchedVideoPerYoutubers();
            List<KeyValuePair<string, Video>> expected = new List<KeyValuePair<string, Video>>()
            { new KeyValuePair<string, Video>("Test 1", videosList[0]) };
            //ASSERT
            Assert.AreEqual(result.ToList(), expected);
        }

        [TestCase(null)]
        public void CreateForVideoLogicTest(Video video)
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => videoLogic.Create(video));
        }

        [Test]
        public void CreateForVideoLogicWhichWontThrow()
        {
            //ARRANGE
            Video vTest = new Video() //Is this hidden dependency?
            {
                Title = "Video LOLLLLLL",
                VideoID = 3,
                //CreatorID = null,
                ViewCount = 33023,
                //YTContentCreator = null
            };
            //ACT
            //ASSERT
            Assert.That(() => videoLogic.Create(vTest), Throws.Nothing);
        }

        [TestCase(null)]
        public void Update(Video content)
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => videoLogic.Update(content));
        }

        //Comment
        //Comment c1 = new Comment()
        //{
        //    CommentID = 4,
        //    VideoID = 2,
        //    Content = "fsdsdfgs",
        //    Likes = -341,
        //    Username = "Polyboi",
        //    Video = null
        //};

        [TestCase(null)]
        public void CreateForCommentLogicTest(Comment comment)
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => commentLogic.Create(comment));
        }

        [TestCase(null)]
        public void Update(Comment content)
        {
            //ARRANGE
            //ACT
            //ASSERT
            Assert.Throws<Exception>(() => commentLogic.Update(content));
        }
    }
}
