﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School3.Service;
using School3.Models;
using School3.Models.Dto;

namespace School3.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PupilController : ControllerBase
    {
        
            [HttpGet]
            public IEnumerable<PupilDetailDto> GetAllPupilss()
            {
                PupilService pupilService = new PupilService();
                return pupilService.ReadAll();
            }

        [HttpPost]
        public string SetPupil(Pupil pupil)
        {
            string message = "Successful Registration";

            PupilService pupilService = new PupilService();
            pupilService.Create(pupil);

            return message;
        }

        [HttpPatch]
        public string UpdatePupil(PupilShortDto pupilShortDto)
        {
            string message = "Successful Update";

            PupilService pupilService = new PupilService();
            pupilService.Update(pupilShortDto);

            return message;
        }


        [HttpDelete]
        public string DeletePupil(int id)
        {
            string message = "Successful Delection";

            PupilService pupilService = new PupilService();
            pupilService.Delete(id);

            return message;
        }

        [Route("myMates")]
        [HttpPatch]
        public IEnumerable<Person2Dto> FindMates(PupilFindMatesDto findMatesDto)
        {

            PupilService pupilService = new PupilService(); 

            return pupilService.FindMates(findMatesDto);
        }

        [Route("myTeachers")]
        [HttpGet]
        public IEnumerable<PersonDto> FindMyTeachers(int pupilId)
        {

            PupilService pupilService = new PupilService();

            return pupilService.FindMyTeachers(pupilId);
        }



    }
}
