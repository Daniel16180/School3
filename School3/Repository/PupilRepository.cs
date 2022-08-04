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
    public class PupilRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<Pupil> GetPupils()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var pupil = connection.Query<Pupil>("SELECT id as Id, first_name as Name, last_name as Surname, age as Age, id_classgroup as ClassGroupId FROM Pupil");
                return pupil;
            }
        }

        public void SetPupil(Pupil pupil)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Pupil (first_name, last_name, age, id_classgroup) VALUES(@Name, @Surname, @Age, @ClassGroupId)";

                int rowsAffected = connection.Execute(sqlQuery, pupil);
            }
        }

        public void UpdatePupil(PupilShortDto pupilShortDto)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"UPDATE Pupil
                                    SET age= " + pupilShortDto.Age + ", id_classgroup = " + pupilShortDto.ClassGroupId + " " +
                                    "WHERE id= " + pupilShortDto.Id;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void DeletePupil(int pupilId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"DELETE FROM Pupil
                                    WHERE id = " + pupilId;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public IReadOnlyList<Person2Dto> MyMates(int classGroupId)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();


                var personDTOList = connection.Query<Person2Dto>(@"SELECT id as Id, first_name as Name, last_name as Surname FROM dbo.Pupil WHERE id_classgroup = " + classGroupId);
                return personDTOList.ToList().AsReadOnly();
            }
        }
    }
}
