using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using AutoMapper;
using School3.Models.Dto;
using School3.Models;

namespace School3
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //CreateMap<UserModel, UserDto>()
            //        .ForMember(um => um.Id, opt => opt.MapFrom(src => src.UserId));

            CreateMap<Teacher, TeacherDetailDto>(); //conversion from Teacher into TeacherDetailDto
            CreateMap<ClassGroup, ClassGroupDetailDto>(); 
            CreateMap<Pupil, PupilDetailDto>(); 
        }

    }
}
