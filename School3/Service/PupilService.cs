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

        public IEnumerable<Person2Dto> FindMates(PupilFindMatesDto findMatesDto)
        {

            PupilRepository pupilRepository = new PupilRepository();
            List<Person2Dto> matesList = new List<Person2Dto>();
            foreach (var mate in pupilRepository.MyMates(findMatesDto.ClassGroupId))
            {
                if (mate.Id != findMatesDto.PupilId)
                {
                    matesList.Add(mate);
                }
            }

            return matesList;
        }

        public IEnumerable<PersonDto> FindMyTeachers(int pupilId) 
        {
            
            TeacherRepository teacherRepository = new TeacherRepository();
            List<PersonDto> myTeachersList = new List<PersonDto>();
            foreach (var teacher in teacherRepository.MyTeachers(pupilId))
            {
                myTeachersList.Add(teacher);
            }

            return myTeachersList;
        }
    }
}
