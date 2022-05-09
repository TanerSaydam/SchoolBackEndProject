using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]   
    [ApiController]
    public class LessonsController : ControllerBase
    {
        //LessonManager lessonManager = new LessonManager(new EfLessonDal());
        private readonly ILessonService _lessonService;
        public LessonsController(ILessonService lessonService)
        {
            _lessonService = lessonService;
        }

        [HttpGet("getList")]
        public IActionResult GetList()
        {
            var result = _lessonService.GetList();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _lessonService.GetById(id);            
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);     
        }

        [HttpPost("update")]
        public IActionResult Update(Lesson lesson)
        {
            _lessonService.Update(lesson);
            var results = _lessonService.GetList();            
            return Ok(results);
        }

        [HttpPost("add")]
        public IActionResult Add(Lesson lesson)
        {   
            var result = _lessonService.Add(lesson);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);            
        }
    }
}
