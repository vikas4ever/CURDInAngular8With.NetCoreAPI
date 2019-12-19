using System;
using log4net;
using MasterLibrary.DAL;
using MasterLibrary.Model;
using MasterLibrary.Interface;
using System.Collections.Generic;


namespace MasterLibrary.BAL
{
    public class EmployeeDetails_BAL : IEmployeeDetailsRepository
    {
        ILog log = log4net.LogManager.GetLogger(typeof(EmployeeDetails_DAL));

        public List<EmployeeDetails> GetAllRecord()
        {
            List<EmployeeDetails> objReturn = null;
            try
            {
                using (EmployeeDetails_DAL objDAL = new EmployeeDetails_DAL())
                {
                    objReturn = objDAL.GetAllRecord();
                }
            }
            catch (Exception ex)
            { log.Error("GetAllRecorod Error: ", ex); }
            return objReturn;
        }


        public Guid? InsertUpdateRecord(EmployeeDetails objProductDetails)
        {
            Guid? objReturn = null;
            try
            {
                using (EmployeeDetails_DAL objDAL = new EmployeeDetails_DAL())
                {
                    objReturn = objDAL.InsertUpdateRecord(objProductDetails);
                }
            }
            catch (Exception ex)
            { log.Error("InsertUpdateRecord Error: ", ex); }
            return objReturn;
        }

        public EmployeeDetailsList GetRecordPage(int iPageNo, int iPageSize)
        {
            EmployeeDetailsList objReturn = null;
            try
            {
                if (iPageNo > 0)
                {
                    using (EmployeeDetails_DAL objDAL = new EmployeeDetails_DAL())
                    {
                        objReturn = objDAL.GetRecordPage(iPageNo, iPageSize);
                    }
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
                //if (iId > 0)
                {
                    using (EmployeeDetails_DAL objDAL = new EmployeeDetails_DAL())
                    {
                        objReturn = objDAL.GetRecordById(iId);
                    }
                }
            }
            catch (Exception ex)
            { log.Error("GetRecorodById Error: ", ex); }
            return objReturn;
        }

        public bool DeleteRecord(int iId)
        {
            bool objReturn = false;
            try
            {
                if (iId > 0)
                {
                    using (EmployeeDetails_DAL objDAL = new EmployeeDetails_DAL())
                    {
                        objReturn = objDAL.DeleteRecord(iId);
                    }
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
