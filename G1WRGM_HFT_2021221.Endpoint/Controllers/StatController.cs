using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace G1WRGM_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StatController : ControllerBase
    {
        IYTContentCreatorLogic ytccl;
        IVideoLogic vl;
        ICommentLogic cl;
        public StatController(IYTContentCreatorLogic ytccl, IVideoLogic vl, ICommentLogic cl)
        {
            this.ytccl = ytccl;
            this.vl = vl;
            this.cl = cl;
        }

        // GET /stat/allnegcommsfromytber/5
        [HttpGet("{id}")]
        public IEnumerable<Comment> AllNegCommsFromYTber(int id)
        {
            return ytccl.GetAllNegativeCommentsFromYoutuber(id);
        }

        // GET: /stat/videoswithmorethan30kviewsfromyoutuber/5
        [HttpGet("{id}")]
        public IEnumerable<Video> VideosWithMoreThan30KViewsFromYoutuber(int id)
        {
            return ytccl.VideosWithMoreThan30KViewsFromYoutuber(id);
        }

        // GET: /stat/getvideoswithcommentsfromyoutuber/5
        [HttpGet("{id}")]
        public IEnumerable<Video> GetVideosWithCommentsFromYoutuber(int id)
        {
            return ytccl.GetVideosWithCommentsFromYoutuber(id);
        }

        // GET: /stat/changesubscribercount/5
        [HttpGet("{id}")]
        public void ChangeSubscriberCount(int id, int newCount)
        {
            ytccl.ChangeSubscriberCount(id, newCount);
        }

        // GET: /stat/first3mostlikedcommentfromvideo/5
        [HttpGet("{id}")]
        public IEnumerable<Comment> First3MostLikedCommentFromVideo(int id)
        {
            return vl.First3MostLikedCommentFromVideo(id);
        }

        // GET: /stat/getmostwatchedvideoperyoutubers
        [HttpGet]
        public IEnumerable<KeyValuePair<string, Video>> GetMostWatchedVideoPerYoutubers()
        {
            return ytccl.GetMostWatchedVideoPerYoutubers();
        }

        // GET: /stat/getmostlikescommentsfromvideos
        [HttpGet]
        public IEnumerable<KeyValuePair<string, Comment>> GetMostLikesCommentsFromVideos()
        {
            return vl.GetMostLikesCommentsFromVideos();
        }

        // GET: /stat/commorexlikexcontent/10/10
        [HttpGet("{likeX}/{contentX}")]
        public IEnumerable<Comment> ComMoreXLikeXContent(int likeX, int contentX)
        {
            return cl.CommentsWithMorethanXLikesAndXContent(likeX, contentX);
        }
    }
}
