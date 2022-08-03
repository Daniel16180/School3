using Microsoft.AspNetCore.Http;
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
        
            [Microsoft.AspNetCore.Mvc.HttpGet]
            public IActionResult GetAllPupilss()
            {
                PupilService pupilService = new PupilService();
                return Ok(pupilService.ReadAll());
            }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult SetPupil(Pupil pupil)
        {
            string message = "Successful Registration";

            PupilService pupilService = new PupilService();
            pupilService.Create(pupil);

            return Ok(message);
        }

        [Microsoft.AspNetCore.Mvc.HttpPatch]
        public IActionResult UpdatePupil(PupilShortDto pupilShortDto)
        {
            string message = "Successful Update";

            PupilService pupilService = new PupilService();
            pupilService.Update(pupilShortDto);

            return Ok(message);
        }


        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public IActionResult DeletePupil(int id)
        {
            string message = "Successful Delection";

            PupilService pupilService = new PupilService();
            pupilService.Delete(id);

            return Ok(message);
        }
    }
}
