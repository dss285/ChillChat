using ChillChat.DataModels;
using ChillChat.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChillChat.RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private ChillChatDbRepository _repository = new ChillChatDbRepository();
        // GET: api/<ServerController>
        [HttpGet]
        public IEnumerable<ServerViewModel> Get()
        {
            var ser = new ServerService(_repository);
            return ser.GetAll();
        }

        // GET api/<ServerController>/5
        [HttpGet("{id}")]
        public ServerViewModel? Get(int id)
        {
            var ser = new ServerService(_repository);
            return ser.GetByExpression(t => t.ServerId == id);
        }

        // POST api/<ServerController>
        [HttpPost]
        public void Post([FromBody] ServerViewModel model)
        {
            var ser = new ServerService(_repository);
            var dbModel = ser.Save(model);
            return;
        }

        // PUT api/<ServerController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] ServerViewModel model)
        {
            model.ServerId = id;
            var ser = new ServerService(_repository);
            var dbModel = ser.Save(model);
            return;
        }

        // DELETE api/<ServerController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var ser = new ServerService(_repository);
            var dbModel = ser.Find(t => t.ServerId == id);
            if(dbModel != null)
                ser.Delete(dbModel);

        }
    }
}
