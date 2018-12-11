using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using dotnet_shared_volume.Model;
using System.Collections.Generic;
using dotnet_shared_volume.Repository;

namespace dotnet_shared_volume.Controllers
{
    [Route("api/v1/counter")]
    public class CounterController : ControllerBase
    {
        private readonly IRepository _repository;
        public CounterController(IRepository repository)
        {
             _repository = repository;
        }

        [HttpGet("")]
        [Route("")]
        public async Task<IActionResult> GetCounter()
        {
            System.Console.WriteLine("get operation");
            return Ok(await _repository.GetCountAsync());
        }

        [HttpPost]
        public IActionResult Post()
        {
            _repository.AddCounter().Wait();
            System.Console.WriteLine("post completed");

            return Ok();
        }
    }
}