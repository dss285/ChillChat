using ChillChat.DataModels;
using ChillChat.Server.Hubs;
using ChillChat.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ChillChat.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServerController : ControllerBase
    {
        private readonly ChillChatDbRepository _repository;
        private readonly IHubContext<ChatHub> _hubContext;

        public ServerController(ChillChatDbRepository repository, IHubContext<ChatHub> hubContext)
        {
            _repository = repository;
            _hubContext = hubContext;
        }

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
        public async Task Post([FromBody] ServerViewModel model)
        {
            var ser = new ServerService(_repository);
            _ = ser.Save(model);
            await _hubContext.Clients.All.SendAsync(ChatSchema.ServerPost.Event, model);
            return;
        }

        // PUT api/<ServerController>/5
        [HttpPut("{id}")]
        public async void Put(int id, [FromBody] ServerViewModel model)
        {
            model.ServerId = id;
            ServerService ser = new(_repository);
            _ = ser.Save(model);
            await _hubContext.Clients.All.SendAsync(ChatSchema.ServerPut.Event, model);
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
