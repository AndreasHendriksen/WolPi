using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using server.Models;
using server.Services;

namespace server.Controllers
{
    [ApiController]
    [Route("api")]
    public class WoLController : ControllerBase
    {
        private readonly ServiceManager serviceManager;

        public WoLController(ServiceManager _servicemanager)
        {
            serviceManager = _servicemanager;
        }

        [EnableCors]
        [HttpGet("status")]
        public ActionResult<InfoList> GetStatus()
        {
            InfoList list = serviceManager.GetInfoList();

            return StatusCode(200, list);
        }

        [EnableCors]
        [HttpGet("status/{id}")]
        public ActionResult<InfoItem> GetStatus(int id)
        {
            InfoItem item = serviceManager.CheckStatus(id);

            return StatusCode(200, item);
        }

        [HttpPost]
        public ActionResult PostMagicSignal()
        {
            return StatusCode(501);
        }

        [HttpPost("Update")]
        public ActionResult PostUpdate()
        {
            return StatusCode(501);
        }

        [HttpPost("disable")]
        public ActionResult PostDisable()
        {
            return StatusCode(501);
        }
    }
}
