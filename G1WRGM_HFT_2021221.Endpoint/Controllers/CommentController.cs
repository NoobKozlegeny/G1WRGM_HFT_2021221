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
    public class CommentController : ControllerBase
    {
        ICommentLogic cl;
        IHubContext<SignalRHub> hub;
        public CommentController(ICommentLogic cl, IHubContext<SignalRHub> hub)
        {
            this.cl = cl;
            this.hub = hub;
        }

        // GET: /comment
        [HttpGet]
        public IEnumerable<Comment> Get()
        {
            return cl.ReadAll();
        }

        // GET /comment/5
        [HttpGet("{id}")]
        public Comment Get(int id)
        {
            return cl.Read(id);
        }

        // POST /comment
        [HttpPost]
        public void Post([FromBody] Comment value)
        {
            cl.Create(value);
            this.hub.Clients.All.SendAsync("CommentCreated", value);
        }

        // PUT /comment
        [HttpPut]
        public void Put([FromBody] Comment value)
        {
            cl.Update(value);
            this.hub.Clients.All.SendAsync("CommentUpdated", value);
        }

        // DELETE /comment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var commentToDelete = cl.Read(id);
            cl.Delete(id);
            this.hub.Clients.All.SendAsync("CommentDeleted", commentToDelete);
        }
    }
}
