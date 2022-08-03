using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace School3.Models
{
    public class ClassGroup
    {
        public int Id { get; set; }
        public int Year { get; set; } //1º, 2º, 3º and 4º.
        public string Letter { get; set; }//a or b

        public ClassGroup(){}

        public ClassGroup(int id, int year, string letter)
        {
            Id = id;
            Year = year;
            Letter = letter;
        }
    }
}
