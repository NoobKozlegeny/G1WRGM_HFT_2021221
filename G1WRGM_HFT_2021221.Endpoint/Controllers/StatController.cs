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
        public StatController(IYTContentCreatorLogic ytccl, IVideoLogic vl)
        {
            this.ytccl = ytccl;
            this.vl = vl;
        }

        // GET /stat/allnegcommsfromytber/5
        [HttpGet("{id}")]
        public IEnumerable<Comment> AllNegCommsFromYTber(int id)
        {
            return ytccl.GetAllNegativeCommentsFromYoutuber(id);
        }

        // GET: /stat/vidmorexviews/5
        [HttpGet]
        public IEnumerable<Video> VideosWithMoreThanXViewsFromYoutuber(int id, int X)
        {
            return ytccl.VideosWithMoreThanXViewsFromYoutuber(id, X);
        }

        // GET: /stat/vidwithmorecomm/5
        [HttpGet]
        public IEnumerable<Video> GetVideosWithCommentsFromYoutuber(int id)
        {
            return ytccl.GetVideosWithCommentsFromYoutuber(id);
        }

        // GET: /stat/subcount/5
        [HttpGet]
        public void ChangeSubscriberCount(int id, int newCount)
        {
            ytccl.ChangeSubscriberCount(id, newCount);
        }
    }
}
