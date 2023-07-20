using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GetECINo.Repository;
using GetECIno.Controllers;
using GetECIno.Models;
using GetECIno.Filters;
using Microsoft.AspNetCore.Mvc;
using StackExchange.Profiling;
using GetECINo.Models;
using Serilog;
using Newtonsoft.Json;


namespace GetECIno.Controllers
{
    [Route("api/mongodb")]
    [ApiController]

    
    public class MongoDBController : ControllerBase
    {
        public readonly IDataRepository _dataRepository;

        public MongoDBController(IDataRepository dataRepository)
        {
            _dataRepository = dataRepository;
        }
        [Consumes("application/json")]
        [Produces("application/json")]
        [HttpPost("getEcino")]
        [ValidateModel]

        public ActionResult Result([FromBody] EcinoRequest ecinoRequest)
        {
            return _dataRepository.GetEcino(ecinoRequest);
        }
        #region IsAlive
        [ApiVersion("1.0")]
        [HttpGet("health",Name="IsAlive")]
        public async Task<IActionResult> IsAliveAsync()
        {
            var health = await _dataRepository.IsAliveAsync();
            using (MiniProfiler.Current.Step(Constants.Health))
            {
                Log.Information(Constants.Health);
                return Content(JsonConvert.SerializeObject(health));
            }
        }
       
        #endregion
    }
}
