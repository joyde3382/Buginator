using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BuginatorServer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILoggerManager _logger;
        private IRepositoryWrapper _repoWrapper;

        public WeatherForecastController(IRepositoryWrapper repository)
        {
            _repoWrapper = repository;
        }

        [HttpGet]
        public IEnumerable<string> Get()
        {
            var adminUsers = _repoWrapper.User.FindAll(); //FindByCondition(x => x.Name.Equals("Jones")); //Role.Equals(1)
            var projects = _repoWrapper.Project.FindAll();
            var tickets = _repoWrapper.Ticket.FindAll();

            return new string[] { "value1", "value2" };
        }
    }
}
