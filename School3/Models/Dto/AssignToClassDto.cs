using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models.Dto
{
    public class AssignToClassDto
    {
        public string TeacherName { get; set; }
        public string TeacherSurname { get; set; }
        public int ClassGroupId { get; set; }

        public AssignToClassDto(){ }

        public AssignToClassDto(string teacherName, string teacherSurname, int classGroupId)
        {
            TeacherName = teacherName;
            TeacherSurname = teacherSurname;
            ClassGroupId = classGroupId;
        }
    }
}
