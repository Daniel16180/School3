using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School3.Repository;
using School3.Models;
using School3.Models.Dto;

namespace School3.Service
{
    public class ClassGroupService
    {
        public void Create(ClassGroupDetailDto classGroupDetailDto)
        {
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            classGroupRepository.SetClassgroup(classGroupDetailDto);       
        }

        public IEnumerable<ClassGroupDetailDto> ReadAll() //change
        {
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            ClassGroupDetailDto classGroupDetailDto = new ClassGroupDetailDto();
            List<ClassGroupDetailDto> classGroupDetailDtos = new List<ClassGroupDetailDto>();

            foreach (var classGroup in classGroupRepository.GetClassgroups())
            {
                classGroupDetailDto.Id = classGroup.Id;
                classGroupDetailDto.Year = classGroup.Year;
                classGroupDetailDto.Letter = classGroup.Letter;

                classGroupDetailDtos.Add(classGroupDetailDto);
            }

            return classGroupDetailDtos;
        }

        public void Update(ClassGroupDetailDto classGroupDetailDto)
        {
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            classGroupRepository.UpdateClassgroup(classGroupDetailDto);
          
        }
        public void Delete(int idClassGroup)
        {
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            classGroupRepository.DeleteClassgroup(idClassGroup);
        }

        public void Merge()
        {
            Console.Clear();
         
       

            Console.WriteLine("Select the group you want to merge into a second one");
            int firstGroup = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Select the second group");
            int secondGroup = Convert.ToInt32(Console.ReadLine());

            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            classGroupRepository.Merge(firstGroup, secondGroup);
            TeacherRepository teacherRepository = new TeacherRepository();


            Console.WriteLine("Both groups where succesfully merged into one.");
   

            Console.WriteLine($"The teachers in the classgroup with id {firstGroup} are bored. Those teachers are: ");
            foreach (var Person2DTO in teacherRepository.findUnassignTeachers(firstGroup))
            {
                Console.WriteLine("Id: " + Person2DTO.Id + " Name: " + Person2DTO.Name + " Surname: " + Person2DTO.Surname);
            }
          
            Console.WriteLine("Please, reassign them to new classgroups. \n");
            foreach (var Person2DTO in teacherRepository.findUnassignTeachers(firstGroup))
            {
          
                Console.WriteLine($"{Person2DTO.Name} {Person2DTO.Surname} goes to classgroup: ");
                Console.WriteLine("(Insert classgroup id)");
                int newClassGroupId = Convert.ToInt32(Console.ReadLine());
                if (newClassGroupId > 0 && newClassGroupId < 8 && newClassGroupId != firstGroup)
                {
                    teacherRepository.SetAssignment(newClassGroupId, Person2DTO.Id);
                    Console.WriteLine($"{Person2DTO.Name} was assigned.");
                }
                else
                {
                    Console.WriteLine("Invalid group.");
                }
               
            }

            teacherRepository.unassignTeachers(firstGroup); //since it is prevented to use this var in the new assignment, it is safe to delete those rows.
        }
    }
}
