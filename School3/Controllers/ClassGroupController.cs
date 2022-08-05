using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using School3.Service;
using School3.Models;
using School3.Models.Dto;
using AutoMapper;

namespace School3.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class ClassGroupController : ControllerBase
    {
        private readonly IMapper _mapper;

        public ClassGroupController(IMapper mapper)
        {
            //UserRepository = new UserRepository();
            this._mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<ClassGroupDetailDto> GetAllClassGroups()
        {
            ClassGroupService classGroupService = new ClassGroupService(_mapper);
            return classGroupService.ReadAll();
        }

        [HttpPost]
        public string SetClassGroup(ClassGroupDetailDto classGroupDetailDto)
        {
            string message = "Successful Registration";

            ClassGroupService classGroupService = new ClassGroupService(_mapper);
            classGroupService.Create(classGroupDetailDto);

            return message;
        }

        [HttpPatch]
        public string UpdateClassGroup(ClassGroupDetailDto classGroupDetailDto)
        {
            string message = "Successful Update";

            ClassGroupService classGroupService = new ClassGroupService(_mapper);
            classGroupService.Update(classGroupDetailDto);

            return message;
        }

        [HttpDelete]
        public string DeleteClassGroup(int id)
        {
            string message = "Successful Delection";

            ClassGroupService classGroupService = new ClassGroupService(_mapper);
            classGroupService.Delete(id);

            return message;
        }

        [Route("merge")]
        [HttpPatch]
        public string MergeClassGroup(MergedGroupsDto mergedGroupsDto)
        {
            string message = "Successfull merged. Please reassign unassigned teachers.";

            ClassGroupService classGroupService = new ClassGroupService(_mapper);
            classGroupService.Merge(mergedGroupsDto);

            return message;
        }
    }
}
