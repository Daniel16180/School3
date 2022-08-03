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
    public class ClassGroupRepository
    {
        private string connectionStr = Initialize.GetConnectionString();

        public IEnumerable<ClassGroup> GetClassgroups()
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                var classgroup = connection.Query<ClassGroup>("SELECT id as Id, year as Year, letter as Letter FROM Classgroup");
                return classgroup;
            }
        }

        public void SetClassgroup(ClassGroupDetailDto classGroupDetailDto)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "INSERT INTO Classgroup (year, letter) VALUES(" + classGroupDetailDto.Year + ", '" + classGroupDetailDto.Letter + "')";

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void UpdateClassgroup(ClassGroupDetailDto classGroupDetailDto)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"UPDATE Classgroup
                                    SET year= " + classGroupDetailDto.Year + ", letter= '" + classGroupDetailDto.Letter + "' " +
                                    "WHERE id= " + classGroupDetailDto.Id;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void DeleteClassgroup(int idClassGroup)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = @"DELETE FROM Classgroup
                                    WHERE id = " + idClassGroup;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }

        public void Merge(int firstGroup, int secondGroup)
        {
            using (IDbConnection connection = new SqlConnection(connectionStr))
            {
                connection.Open();

                string sqlQuery = "UPDATE Pupil SET id_classgroup = " + secondGroup + " WHERE id_classgroup = " + firstGroup;

                int rowsAffected = connection.Execute(sqlQuery);
            }
        }
    }
}
