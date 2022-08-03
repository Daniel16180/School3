using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School3.Repository;
using School3.Models;
using School3.Models.Dto;
using Ubiety.Dns.Core;
using System.Web.Http;
using System.Linq;

namespace School3.Service
{
    public class PupilService
    {
        public void Create(Pupil pupil)
        {
            PupilRepository pupilRepository = new PupilRepository();
            pupilRepository.SetPupil(pupil);

        }
        public IEnumerable<PupilDetailDto> ReadAll()
        {
            PupilRepository pupilRepository = new PupilRepository();
            PupilDetailDto pupilDetailDto = new PupilDetailDto();
            List<PupilDetailDto> pupilDetailDtos = new List<PupilDetailDto>();



            //pupilDetailDtos = (from p in pupilRepository
            //                   select new PupilDetailDto()
            //                   {
            //                       Id = pupilDetailDto.Id,
            //                       Name = pupilDetailDto.Name
            //                   }).ToList();

            foreach (var pupil in pupilRepository.GetPupils()) //change
            {

                pupilDetailDto.Id = pupil.Id;
                pupilDetailDto.Name = pupil.Name;
                pupilDetailDto.Surname = pupil.Surname;
                pupilDetailDto.Age = pupil.Age;
                pupilDetailDto.ClassGroupId = pupil.ClassGroupId;

                pupilDetailDtos.Add(pupilDetailDto);
            }

            return pupilDetailDtos;
        }

        public void Update(PupilShortDto pupilShortDto)
        {
            PupilRepository pupilRepository = new PupilRepository();
            pupilRepository.UpdatePupil(pupilShortDto);

        }

        public void Delete(int pupilId)
        {
                PupilRepository pupilRepository = new PupilRepository();
                pupilRepository.DeletePupil(pupilId);
        }

        public void FindMates()
        {
            Console.Clear();
            Console.WriteLine("Select your classgroup id: ");


            int classId = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Insert your own id: ");
            int ownId = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Your classmates are: ");

            PupilRepository pupilRepository = new PupilRepository();
            foreach (var Person2DTO in pupilRepository.MyMates(classId))
            {
                if (Person2DTO.Id != ownId)
                {
                    Console.WriteLine(Person2DTO.Name + " " + Person2DTO.Surname);

                }

            }

        }

        public void FindMyTeachers()
        {
            Console.WriteLine("Write your student number (id)");
            int studentNumber = Convert.ToInt32(Console.ReadLine());

            Console.Clear();
            Console.WriteLine("Your teachers are: ");
            TeacherRepository teacherRepository = new TeacherRepository();
            foreach (var PersonDTO in teacherRepository.MyTeachers(studentNumber))
            {
                Console.WriteLine(PersonDTO.Name + " " + PersonDTO.Surname);


            }

        }
    }
}
