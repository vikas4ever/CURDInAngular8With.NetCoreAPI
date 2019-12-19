using System;
using log4net;
using Dapper;
using System.Linq;
using ConnectionLibrary;
using MasterLibrary.Model;
using System.Data.SqlClient;
using MasterLibrary.Interface;
using System.Collections.Generic;

namespace MasterLibrary.DAL
{
    public class EmployeeDetails_DAL : IEmployeeDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDetails_DAL));
        public List<EmployeeDetails> GetAllRecord()
        {
            List<EmployeeDetails> objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<EmployeeDetails>("udp_EmployeeDetails_lst", commandType: System.Data.CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }
        public Guid? InsertUpdateRecord(EmployeeDetails objEmployeeDetails)
        {
            Guid? objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    objReturn = db.Query<Guid>("udp_EmployeeDetails_ups", param: objEmployeeDetails, commandType: System.Data.CommandType.StoredProcedure).Single();
                }
            }
            catch (Exception ex)
            {
                log.Error("InsertUpdateRecord Error: ", ex);
            }
            return objReturn;
        }
        public EmployeeDetailsList GetRecordPage(int iPageNo, int iPageSize)
        {
            EmployeeDetailsList objReturn = new EmployeeDetailsList();
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@pageNum", iPageNo);
                    param.Add("@pageSize", iPageSize);
                    param.Add("@TotalRecords", dbType: System.Data.DbType.Int32, direction: System.Data.ParameterDirection.Output);

                    objReturn.EmployeeDetailss = db.Query<EmployeeDetails>("udp_EmployeeDetails_lstpage", param, commandType: System.Data.CommandType.StoredProcedure).ToList();
                    objReturn.TotalRecords = param.Get<int>("@TotalRecords");
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordsPage Error: ", ex); }
            return objReturn;
        }
        public EmployeeDetails GetRecordById(Guid iId)
        {
            EmployeeDetails objReturn = null;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    objReturn = db.Query<EmployeeDetails>("udp_EmployeeDetails_sel", param: param, commandType: System.Data.CommandType.StoredProcedure).SingleOrDefault();
                }
            }
            catch (Exception ex)
            { log.Error("GetRecordById Error: ", ex); }
            return objReturn;
        }
        public bool DeleteRecord(int iId)
        {
            bool objReturn = false;
            try
            {
                using (SqlConnection db = new SqlDBConnect().GetConnection())
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@Id", iId);
                    db.Query("udp_EmployeeDetails_del", param: param, commandType: System.Data.CommandType.StoredProcedure);
                    objReturn = true;
                }
            }
            catch (Exception ex)
            { log.Error("DeleteRecord Error: ", ex); }
            return objReturn;
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects).
                }

                // TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
                // TODO: set large fields to null.

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        #endregion

    }
}
