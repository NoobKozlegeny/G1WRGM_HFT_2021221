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
        private YTContentCreatorLogic ytccLogic;
        private VideoLogic videoLogic;
        private CommentLogic commentLogic;

        [SetUp]
        public void Init()
        {
            //Mock init
            var mockYtccRepo = new Mock<IYTContentCreatorRepository>();
            var mockVideoRepo = new Mock<IVideoRepository>();
            var mockCommentRepo = new Mock<ICommentRepository>();

            //Datas
            var ytccs = new List<YTContentCreator>();
            YTContentCreator ytcc1 = new YTContentCreator()
            {
                Creation = 2009,
                CreatorID = 1,
                CreatorName = "Test 1",
                SubscriberCount = 43456
            };
            YTContentCreator ytcc2 = new YTContentCreator()
            {
                Creation = 2011,
                CreatorID = 2,
                CreatorName = "Test 2",
                SubscriberCount = 438
            };
            ytccs.Add(ytcc1);
            ytccs.Add(ytcc2);

            var videos = new List<Video>();
            Video v1 = new Video()
            {
                Title = "Video 1",
                VideoID = 1,
                ViewCount = 33023,
                YTContentCreator = ytcc1
            };
            Video v2 = new Video()
            {
                Title = "Video 2",
                VideoID = 2,
                ViewCount = 4542,
                YTContentCreator = ytcc1
            };
            videos.Add(v1);
            videos.Add(v2);

            var comments = new List<Comment>()
            {
                new Comment()
                {
                    Content = "Comment 1",
                    Likes = 236,
                    Username = "Sanyi",
                    Video = v1
                },
                new Comment()
                {
                    Content = "Comment 2",
                    Likes = -11,
                    Username = "Róbert",
                    Video = v1
                },
                new Comment()
                {
                    Content = "Comment 3",
                    Likes = 0,
                    Username = "Lali",
                    Video = v1
                }
            }.AsQueryable();

            mockYtccRepo.Setup((t) => t.ReadAll()).Returns(ytccs.AsQueryable());
            mockVideoRepo.Setup((t) => t.ReadAll()).Returns(videos.AsQueryable());
            mockCommentRepo.Setup((t) => t.ReadAll()).Returns(comments);

            ytccLogic = new YTContentCreatorLogic(mockYtccRepo.Object);
            videoLogic = new VideoLogic(mockVideoRepo.Object);
            commentLogic = new CommentLogic(mockCommentRepo.Object);
        }

        [Test]
        public void Test1()
        {

        }
    }
}
