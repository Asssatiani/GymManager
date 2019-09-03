using DAL.Models;
using Dapper;
using GymManager;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DAL
{
    public class DataAccess
    {
        public List<EmployerModel> GetEmployers(int? id, string firstName, string lastName, DateTime? dateFrom, DateTime? dateTo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("GymManagerDB")))
            {
                return connection.Query<EmployerModel>($"dbo.EmployerSearch @Id, @FirstName, @LastName, @DateFrom, @DateTo", new { Id = id, FirstName = firstName, LastName = lastName, DateFrom = dateFrom, DateTo = dateTo }).ToList();
            }
        }

        public EmployerInfoModel EmployerInfo(int id)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("GymManagerDB")))
            {
                return connection.Query<EmployerInfoModel>($"dbo.EmployerInfoSel @Id", new { Id = id }).FirstOrDefault();
            }
        }

        public void UpdateEmployerInfo(EmployerInfoModel employerInfo)
        {
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("GymManagerDB")))
            {
                connection.Execute($"dbo.EmployerInfoInsUpd @Id, @Address, @PhoneNumber, @Email", employerInfo);
            }
        }

    }
}
