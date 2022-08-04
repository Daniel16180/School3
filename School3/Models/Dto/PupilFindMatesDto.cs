using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models.Dto
{
    public class PupilFindMatesDto
    {
        public int ClassGroupId { get; set; }
        public int PupilId { get; set; }

        public PupilFindMatesDto()
        {

        }

        public PupilFindMatesDto(int classGroupId, int pupilId)
        {
            ClassGroupId = classGroupId;
            PupilId = pupilId;
        }
    }
}
