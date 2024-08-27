using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using server.DTOs;
using server.Models;
using server.Services;
using System.Text.Json.Serialization;

namespace server.Controllers
{
    [ApiController]
    [Route("api")]
    public class WoLController : ControllerBase
    {
        private readonly ServiceManager serviceManager;
        private readonly PasswordHandler passwordHandler;

        public WoLController(ServiceManager _servicemanager, PasswordHandler _passwordHandler)
        {
            serviceManager = _servicemanager;
            passwordHandler = _passwordHandler;
        }

        [EnableCors("AllowAllOrigins")]
        [HttpGet("status")]
        public ActionResult<InfoList> GetStatus()
        {
            InfoList list = serviceManager.GetInfoList();

            return StatusCode(200, list);
        }

        [EnableCors("AllowAllOrigins")]
        [HttpGet("status/{id}")]
        public ActionResult<InfoItem> GetStatus(int id)
        {
            InfoItem item = serviceManager.CheckStatus(id);

            return StatusCode(200, item);
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPost]
        public ActionResult PostMagicSignal([FromBody] Password_DTO _password)
        {
            Console.WriteLine(JsonConvert.SerializeObject(_password));

            if (_password.Password == null || _password.Password == "")
                return BadRequest();

            if (!passwordHandler.CheckPassword(_password.Password))
                return Unauthorized();

            serviceManager.BroadcastMagicSignal();
            return Ok();
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPost("update")]
        public ActionResult PostUpdate([FromBody] Password_DTO _password)
        {
            return StatusCode(501);
        }

        [EnableCors("AllowAllOrigins")]
        [HttpPost("disable")]
        public ActionResult PostDisable([FromBody] Password_DTO _password)
        {
            return StatusCode(501);
        }
    }
}
