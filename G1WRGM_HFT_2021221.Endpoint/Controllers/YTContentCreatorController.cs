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
    public class YTContentCreatorController : ControllerBase
    {
        IYTContentCreatorLogic ytcc;
        public YTContentCreatorController(IYTContentCreatorLogic ytcc)
        {
            this.ytcc = ytcc;
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
        public void Post([FromBody] YTContentCreator value)
        {
            ytcc.Create(value);
        }

        // PUT /ytcontentcreator
        [HttpPut]
        public void Put([FromBody] YTContentCreator value)
        {
            ytcc.Update(value);
        }

        // DELETE /ytcontentcreator/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            ytcc.Delete(id);
        }
    }
}
