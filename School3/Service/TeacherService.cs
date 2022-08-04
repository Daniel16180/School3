using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using School3.Models;
using School3.Models.Dto;
using School3.Repository;

namespace School3.Service
{
    public class TeacherService
    {
        private readonly IMapper _mapper;

        public TeacherService(IMapper mapper)
        {
             TeacherRepository teacherRepository = new TeacherRepository();
            _mapper = mapper;
        }

        public void Create(Teacher teacher)
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            teacherRepository.SetTeacher(teacher);
        }

        public IEnumerable<TeacherDetailDto> ReadAll()
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            List<TeacherDetailDto> teacherDetailDtos = new List<TeacherDetailDto>();

            var teachers = teacherRepository.GetTeachers();

            //conversion from Teacher into TeacherDetailDto with AutoMapper
            var resultDtos = this._mapper.Map<IEnumerable<TeacherDetailDto>>(teachers);

            return resultDtos;
        }
        public void Update(TeacherShortDto teacherUpdateDto)
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            teacherRepository.UpdateTeacher(teacherUpdateDto);
        }

        public void Delete(int teacherId)
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            teacherRepository.DeleteTeacher(teacherId);
        }

        public PersonDto ViewDirector()
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            PersonDto personDto = new PersonDto();
            foreach (var teacher in teacherRepository.GetDirector()) //change?
            {
                personDto.Name = teacher.Name;
                personDto.Surname = teacher.Surname;
            }

            return personDto;
        }

        public void ElectDirector() //change. Problem -> Some IDs missing. Use Name and Surname in the Query.
        {
            var votes = new List<int>();
            TeacherRepository teacherRepository = new TeacherRepository();
            foreach (var teacher in teacherRepository.GetTeachers())
            {
                Random randomVotes = new Random();
                int randomNumber = randomVotes.Next(50, 500);
                votes.Add(randomNumber);
            }

            int[] positions = votes.ToArray();
            int winnerPosition = Convert.ToInt32(Array.IndexOf(positions, positions.Max()));
            int realPosition = winnerPosition++;

            teacherRepository.unsetDirector();
            teacherRepository.setDirector(realPosition);
        }

        public void AssignToClass(AssignToClassDto assignToClassDto) //name+surname+existingClassGroupId
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            foreach (var teacher in teacherRepository.GetTeachers())
            {
                if (teacher.Name == assignToClassDto.TeacherName && teacher.Surname == assignToClassDto.TeacherSurname)
                {
                    int teacherId = teacher.Id;
                    teacherRepository.SetAssignment(assignToClassDto.ClassGroupId, teacherId);
                }

            }
        }
    }
}
