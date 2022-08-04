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

        public IEnumerable<ClassGroupDetailDto> ReadAll()
        {
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            
            List<ClassGroupDetailDto> classGroupDetailDtos = new List<ClassGroupDetailDto>();

            foreach (var classGroup in classGroupRepository.GetClassgroups())
            {
                ClassGroupDetailDto classGroupDetailDto = new ClassGroupDetailDto();
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

        public void Merge(MergedGroupsDto mergedGroupsDto) //int groupMergedId, int groupToMergedInId
        {
  
            ClassGroupRepository classGroupRepository = new ClassGroupRepository();
            classGroupRepository.Merge(mergedGroupsDto.GroupMergedId, mergedGroupsDto.GroupToMergedInId);
            TeacherRepository teacherRepository = new TeacherRepository();

            teacherRepository.unassignTeachers(mergedGroupsDto.GroupMergedId);
        }
    }
}
