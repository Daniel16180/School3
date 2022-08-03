using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School3.Models;
using School3.Models.Dto;
using School3.Repository;

namespace School3.Service
{
    public class TeacherService
    {
        public void Create(Teacher teacher)
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            teacherRepository.SetTeacher(teacher);
        }

        public IEnumerable<TeacherDetailDto> ReadAll() //change
        {
            TeacherRepository teacherRepository = new TeacherRepository();
            TeacherDetailDto teacherDetailDto = new TeacherDetailDto();
            List<TeacherDetailDto> teacherDetailDtos = new List<TeacherDetailDto> ();
            
            foreach (var teacher in teacherRepository.GetTeachers())
            {
                teacherDetailDto.Id = teacher.Id;
                teacherDetailDto.Name = teacher.Name;
                teacherDetailDto.Surname = teacher.Surname;
                teacherDetailDto.Salary = teacher.Salary;
                teacherDetailDto.Experience = teacher.Experience;
                teacherDetailDto.Director = teacher.Director;

                teacherDetailDtos.Add(teacherDetailDto);
            }

            return teacherDetailDtos;
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

        public void ElectDirector()
        {
            Console.Clear();
            var votes = new List<int>();
            TeacherRepository query = new TeacherRepository();
            foreach (var teacher in query.GetTeachers())
            {
                Console.WriteLine(teacher.Name);
                Random randomVotes = new Random();
                int randomNumber = randomVotes.Next(50, 500);
                Console.WriteLine(randomNumber + "votes.");
                votes.Add(randomNumber);


            }

            Console.Clear();
            int[] positions = votes.ToArray();
            Console.WriteLine("The winner has " + positions.Max() + "votes!");
            int winnerPosition = Convert.ToInt32(Array.IndexOf(positions, positions.Max()));
            int realWinnerPosition = winnerPosition++;
            Console.WriteLine("The candidate number " + winnerPosition + " won.");


            query.unsetDirector();
            query.setDirector(winnerPosition);
        }

        public void AssignToClass()
        {
            int exitMenu = 0;
            Console.Clear();
            while (exitMenu == 0)
            {
                Console.WriteLine("Write the teacher´s name or type 1 to go back to the Main Menu.");
                string name = Console.ReadLine();
                Console.Clear();
                if (name == "1")
                {
                    exitMenu = 1;
                }
                else
                {
                    Console.WriteLine("Enter the surname");
                    string surname = Console.ReadLine();
                    Console.Clear();

                    Console.WriteLine("Select the classgroup id to assign");
                    int classGroup = Convert.ToInt32(Console.ReadLine());


                    TeacherRepository teacherRepository = new TeacherRepository();
                    foreach (var teacher in teacherRepository.GetTeachers())
                    {
                        if (teacher.Name == name && teacher.Surname == surname)
                        {
                            int idTeacher = teacher.Id;
                            teacherRepository.SetAssignment(classGroup, idTeacher);
                            Console.WriteLine("Done!");
                        }

                    }
                }
            }
        }
    }
}
