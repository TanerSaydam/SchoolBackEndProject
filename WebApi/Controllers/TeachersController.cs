using Business.Abstract;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TeachersController : ControllerBase
    {
        private readonly ITeacherService _teacherService;

        public TeachersController(ITeacherService teacherService)
        {
            _teacherService = teacherService;
        }

        [HttpPost("add")]
        public IActionResult Add(TeacherRegisterDto registerDto)
        {
            _teacherService.Add(registerDto);
            var results = _teacherService.GetList();
            return Ok(results);
        }

        [HttpGet("getlist")]
        public IActionResult GetList()
        {            
            var results = _teacherService.GetList();
            return Ok(results);
        }

    }
}
