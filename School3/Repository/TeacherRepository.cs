using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using School3.Models;
using School3.Models.Dto;

namespace School3.Repository
{
    public class TeacherRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<Teacher> GetTeachers()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var teacher = connection.Query<Teacher>("SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience, director as Director FROM Teacher");
                return teacher;
            }
        }

        public void SetTeacher(Teacher teacher)
        {

            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Teacher (first_name, last_name, salary, experience) VALUES(@Name, @Surname, @Salary, @Experience)";

                int rowsAffected = connection.Execute(sqlQuery, teacher);
            }
        }

        public void UpdateTeacher(TeacherShortDto teacherUpdateDto)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"UPDATE Teacher
                                    SET salary= " + teacherUpdateDto.Salary.ToString(System.Globalization.CultureInfo.InvariantCulture) + ", experience = " + teacherUpdateDto.Experience + " " +
                                    "WHERE id= " + teacherUpdateDto.Id;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void DeleteTeacher(int teacherId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"DELETE FROM Teacher
                                    WHERE id = " + teacherId;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void SetAssignment(int idClasgroup, int teacherId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Classgroup_Teacher (id_classgroup, id_teacher) VALUES(" + idClasgroup + ", " + teacherId + ")";

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void unassignTeachers(int firstGroup)
        { 
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "DELETE FROM Classgroup_Teacher WHERE id_classgroup = " + firstGroup;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void setDirector(int winnerPosition)
        { 
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 1 WHERE id = " + winnerPosition;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void unsetDirector()
        { 
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "UPDATE dbo.Teacher SET director = 0";

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public IReadOnlyList<Person2Dto> findUnassignTeachers(int firstGroup)
        { 
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var Person2DTOList = connection.Query<Person2Dto>(@"SELECT dbo.Teacher.id as Id, dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname
                                  FROM dbo.Teacher, dbo.Classgroup_Teacher
                                  WHERE dbo.Classgroup_Teacher.id_teacher = dbo.Teacher.id AND  dbo.Classgroup_Teacher.id_classgroup = " + firstGroup);

                return Person2DTOList.ToList().AsReadOnly();
            }
        }

        public IReadOnlyList<PersonDto> MyTeachers(int pupilId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();


                var personDTOList = connection.Query<PersonDto>(@"SELECT dbo.Teacher.first_name as Name, dbo.Teacher.last_name as Surname 
                                                                FROM dbo.Teacher, dbo.Classgroup_Teacher, dbo.Pupil
                                                                WHERE dbo.Teacher.id = dbo.Classgroup_Teacher.id_teacher AND dbo.Classgroup_Teacher.id_classgroup = dbo.Pupil.id_classgroup AND dbo.Pupil.id =" + pupilId);
                return personDTOList.ToList().AsReadOnly();
            }
        }

        public IEnumerable<Teacher> GetDirector()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var teacher = connection.Query<Teacher>(@"SELECT id as Id, first_name as Name, last_name as Surname, salary as Salary, experience as Experience, director as Director
                                                      FROM Teacher
                                                      WHERE director= 1");
                return teacher;
            }
        }
    }
}
