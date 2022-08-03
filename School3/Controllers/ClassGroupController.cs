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
    public class ClassGroupController : ControllerBase
    {
        [Microsoft.AspNetCore.Mvc.HttpGet]
        public IActionResult GetAllClassGroups()
        {
            ClassGroupService classGroupService = new ClassGroupService();
            return Ok(classGroupService.ReadAll());
        }

        [Microsoft.AspNetCore.Mvc.HttpPost]
        public IActionResult SetClassGroup(ClassGroupDetailDto classGroupDetailDto)
        {
            string message = "Successful Registration";

            ClassGroupService classGroupService = new ClassGroupService();
            classGroupService.Create(classGroupDetailDto);

            return Ok(message);
        }

        [Microsoft.AspNetCore.Mvc.HttpPatch]
        public IActionResult UpdateClassGroup(ClassGroupDetailDto classGroupDetailDto)
        {
            string message = "Successful Update";

            ClassGroupService classGroupService = new ClassGroupService();
            classGroupService.Update(classGroupDetailDto);

            return Ok(message);
        }

        [Microsoft.AspNetCore.Mvc.HttpDelete]
        public IActionResult DeleteClassGroup(int id)
        {
            string message = "Successful Delection";

            ClassGroupService classGroupService = new ClassGroupService();
            classGroupService.Delete(id);

            return Ok(message);
        }
    }
}
