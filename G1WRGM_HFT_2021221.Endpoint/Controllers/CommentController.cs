using G1WRGM_HFT_2021221.Logic.Interfaces;
using G1WRGM_HFT_2021221.Models;
using Microsoft.AspNetCore.Mvc;
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
        public CommentController(ICommentLogic cl)
        {
            this.cl = cl;
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
        }

        // PUT /comment
        [HttpPut]
        public void Put([FromBody] Comment value)
        {
            cl.Update(value);
        }

        // DELETE /comment/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            cl.Delete(id);
        }
    }
}
