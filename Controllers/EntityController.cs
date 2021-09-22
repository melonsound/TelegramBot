using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TgBotAspNet.Controllers
{
    [Route("config/{Controller}")]
    public class EntityController : Controller
    {
        [HttpGet]
        public IActionResult Test()
        {
            List<string> entities = new List<string>();
            var test = "test";
            entities.Add(test);

            return Ok(entities);
        }
    }
}
