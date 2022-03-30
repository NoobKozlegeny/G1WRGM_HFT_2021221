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
    public class YTContentCreatorController : ControllerBase
    {
        IYTContentCreatorLogic ytcc;
        IHubContext<SignalRHub> hub;
        public YTContentCreatorController(IYTContentCreatorLogic ytcc, IHubContext<SignalRHub> hub)
        {
            this.ytcc = ytcc;
            this.hub = hub;
        }

        // GET: /ytcontentcreator
        [HttpGet]
        public IEnumerable<YTContentCreator> Get()
        {
            return ytcc.ReadAll();
        }

        // GET /ytcontentcreator/5
        [HttpGet("{id}")]
        public YTContentCreator Get(int id)
        {
            return ytcc.Read(id);
        }

        // POST /ytcontentcreator
        [HttpPost]
        public void Post([FromBody] YTContentCreator value) //Stackoverflow says that Post should update, if not then create and PUT should be the creator.
        {
            ytcc.Create(value);
            this.hub.Clients.All.SendAsync("YTContentCreatorCreated", value);
        }

        // PUT /ytcontentcreator
        [HttpPut]
        public void Put([FromBody] YTContentCreator value)
        {
            ytcc.Update(value);
            this.hub.Clients.All.SendAsync("YTContentCreatorUpdated", value);
        }

        // DELETE /ytcontentcreator/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ytccToDelete = this.ytcc.Read(id);
            ytcc.Delete(id);
            this.hub.Clients.All.SendAsync("YTContentCreatorDeleted", ytccToDelete);
        }
    }
}
