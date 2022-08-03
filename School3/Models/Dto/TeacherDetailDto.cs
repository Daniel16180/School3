using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models.Dto
{
    public class TeacherDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public int Experience { get; set; }
        public bool Director { get; set; }

        public TeacherDetailDto() { }

        public TeacherDetailDto(int id, string name, string surname, decimal salary, int experience, bool director)
        {
            Id = id;
            Name = name;
            Surname = surname;
            Salary = salary;
            Experience = experience;
            Director = director;
        }
    }
}
