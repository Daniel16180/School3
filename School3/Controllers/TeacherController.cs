using Microsoft.AspNetCore.Mvc;
using School3.Models;

using School3.Service;
using School3.Models.Dto;
using System.Collections.Generic;

namespace School3.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        [Route("all")]
        [HttpGet]
        public IEnumerable<TeacherDetailDto> GetAllTeachers()
        {
            TeacherService teacherService = new TeacherService();
            return teacherService.ReadAll();
        }

        [HttpPost]
        public IActionResult SetTeacher(Teacher teacher)
        {
            string message = "Successful Registration";

            TeacherService teacherService = new TeacherService();
            teacherService.Create(teacher);

            return Ok(message);
        }

        [HttpPatch]
        public IActionResult UpdateTeacher(TeacherShortDto teacherUpdateDto)
        {
            string message = "Successful Update";

            TeacherService teacherService = new TeacherService();
            teacherService.Update(teacherUpdateDto);

            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteTeacher(int id)
        {
            string message = "Successful Delection";

            TeacherService teacherService = new TeacherService();
            teacherService.Delete(id);

            return Ok(message);
        }

        [Route("/director")]
        [HttpGet]
        public IActionResult GetDirector()
        {
            TeacherService teacherService = new TeacherService();
            return Ok(teacherService.ViewDirector());
        }
    }
}
