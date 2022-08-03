using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models.Dto
{
    public class TeacherShortDto
    {
        public int Id { get; set; }
        public decimal Salary { get; set; }
        public int Experience { get; set; }

        public TeacherShortDto() { }

        public TeacherShortDto(int id, decimal salary, int experience)
        {
            Id = id;
            Salary = salary;
            Experience = experience;
        }
    }
}
