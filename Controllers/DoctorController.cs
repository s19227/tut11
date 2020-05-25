using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using tut11.Entities;
using tut11.Requests;
using tut11.Services;

namespace tut11.Controllers
{
    [Route("api/doctors")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _dbService;

        public DoctorController(IDbService dbService)
        {
            _dbService = dbService;
        }

        [HttpGet]
        public IActionResult GetDoctors()
        {
            var result = _dbService.GetDoctors();
            return Ok(result);
        }

        [HttpGet] [Route("seed")]
        public IActionResult SeedData()
        {
            var result = _dbService.SeedData();

            if (result is null) return BadRequest();
            else return Ok(result);
        }

        [HttpGet("{@id}")][Route("get")]
        public IActionResult GetDoctor(int id)
        {
            var result = _dbService.GetDoctor(id);

            if (result is null) return BadRequest();
            else return Ok(result);
        }

        [HttpDelete("{@id}")][Route("delete")]
        public IActionResult DeleteDoctor(int id)
        {
            var result = _dbService.DeleteDoctor(id);

            if (result is null) return BadRequest();
            else return Ok(result);
        }

        [HttpPost][Route("add")]
        public IActionResult AddDoctor(AddDoctorReq request)
        {
            var result = _dbService.AddDoctor(request);

            if (result is null) return BadRequest();
            else return Ok(result);
        }

        [HttpPost][Route("update")]
        public IActionResult UpdateDoctor(UpdateDoctorReq request)
        {
            var result = _dbService.UpdateDoctor(request);

            if (result is null) return BadRequest();
            else return Ok(result);
        }
    }
}