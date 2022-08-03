using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models.Dto
{
    public class MergedGroupsDto
    {
        public int GroupMergedId { get; set; }
        public int GroupToMergedInId { get; set; }

        public MergedGroupsDto()
        {

        }

        public MergedGroupsDto(int groupMergedId, int groupToMergedInId)
        {
            GroupMergedId = groupMergedId;
            GroupToMergedInId = groupToMergedInId;
        }
    }
}
