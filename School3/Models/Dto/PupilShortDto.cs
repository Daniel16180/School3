using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models.Dto
{
    public class PupilShortDto
    {
        public int Id { get; set; }
        public int Age { get; set; }
        public int ClassGroupId { get; set; }

        public PupilShortDto() { }

        public PupilShortDto(int id, int age, int classGroupId)
        {
            Id = id;
            Age = age;
            ClassGroupId = classGroupId;
        }
    }
}
