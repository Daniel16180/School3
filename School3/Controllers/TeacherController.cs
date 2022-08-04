using Microsoft.AspNetCore.Mvc;
using School3.Models;

using School3.Service;
using School3.Models.Dto;
using System.Collections.Generic;
using AutoMapper;

namespace School3.Controllers
{
    [Route("api/teacher")]
    [ApiController]
    public class TeacherController : ControllerBase
    {
        private readonly IMapper _mapper;

        public TeacherController(IMapper mapper)
        {
            //UserRepository = new UserRepository();
            this._mapper = mapper;
        }

        [Route("all")]
        [HttpGet]
        public IEnumerable<TeacherDetailDto> GetAllTeachers()
        {
            TeacherService teacherService = new TeacherService(_mapper);
            return teacherService.ReadAll();
        }

        [HttpPost]
        public string SetTeacher(Teacher teacher)
        {
            string message = "Successful Registration";

            TeacherService teacherService = new TeacherService(_mapper);
            teacherService.Create(teacher);

            return message;
        }

        [HttpPatch]
        public string UpdateTeacher(TeacherShortDto teacherUpdateDto)
        {
            string message = "Successful Update";

            TeacherService teacherService = new TeacherService(_mapper);
            teacherService.Update(teacherUpdateDto);

            return message;
        }

        [HttpDelete]
        public string DeleteTeacher(int id)
        {
            string message = "Successful Delection";

            TeacherService teacherService = new TeacherService(_mapper);
            teacherService.Delete(id);

            return message;
        }

        [Route("director")]
        [HttpGet]
        public PersonDto GetDirector()
        {
            TeacherService teacherService = new TeacherService(_mapper);
            return teacherService.ViewDirector();
        }

        [Route("directorElection")]
        [HttpGet]
        public string UpdateDirector()
        {
            string message = "Director elected";
            TeacherService teacherService = new TeacherService(_mapper);
            teacherService.ElectDirector();
            return message;
        }

        [Route("assign")]
        [HttpPost]
        public string AssignTeacherToClassGroup(AssignToClassDto assignToClassDto)
        {
            string message = "Teacher asigned";
            TeacherService teacherService = new TeacherService(_mapper);
            teacherService.AssignToClass(assignToClassDto);
            return message;
        }
    }
}
