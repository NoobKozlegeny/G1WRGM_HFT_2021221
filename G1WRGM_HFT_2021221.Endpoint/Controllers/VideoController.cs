using G1WRGM_HFT_2021221.Endpoint.Services;
using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace G1WRGM_HFT_2021221.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        IVideoLogic vl;
        IHubContext<SignalRHub> hub;
        public VideoController(IVideoLogic vl, IHubContext<SignalRHub> hub)
        {
            this.vl = vl;
            this.hub = hub;
        }

        // GET: /video
        [HttpGet]
        public IEnumerable<Video> Get()
        {
            return vl.ReadAll();
        }

        // GET /video/5
        [HttpGet("{id}")]
        public Video Get(int id)
        {
            return vl.Read(id);
        }

        // POST /video
        [HttpPost]
        public void Post([FromBody] Video value)
        {
            vl.Create(value);
            this.hub.Clients.All.SendAsync("VideoCreated", value);
        }

        // PUT /video
        [HttpPut]
        public void Put([FromBody] Video value)
        {
            vl.Update(value);
            this.hub.Clients.All.SendAsync("VideoUpdated", value);
        }

        // DELETE /video/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var videoToDelete = vl.Read(id);
            vl.Delete(id);
            this.hub.Clients.All.SendAsync("VideoDeleted", videoToDelete);
        }
    }
}
