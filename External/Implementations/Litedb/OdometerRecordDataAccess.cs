﻿using CarCareTracker.External.Interfaces;
using CarCareTracker.Models;
using CarCareTracker.Helper;
using LiteDB;

namespace CarCareTracker.External.Implementations
{
    public class OdometerRecordDataAccess : IOdometerRecordDataAccess
    {
        private ILiteDBHelper _liteDB { get; set; }
        private static string tableName = "odometerrecords";
        public OdometerRecordDataAccess(ILiteDBHelper liteDB)
        {
           _liteDB = liteDB;
        }
        public List<OdometerRecord> GetOdometerRecordsByVehicleId(int vehicleId)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            var odometerRecords = table.Find(Query.EQ(nameof(OdometerRecord.VehicleId), vehicleId));
            return odometerRecords.ToList() ?? new List<OdometerRecord>();
        }

        public List<OdometerRecord> GetPaginatedOdometerRecordsByVehicleId(int vehicleId, int pageSize, int page, SortDirection sortDirection)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            var query = table.Query();
            List<OdometerRecord> resultPage = new();
            switch (sortDirection)
            {
                case SortDirection.Ascending:
                    resultPage = query.Where(x => x.VehicleId == vehicleId).OrderBy(x => x.Date).Limit(pageSize).Offset((page - 1) * pageSize).ToList();
                    break;
                case SortDirection.Descending:
                    resultPage = query.Where(x => x.VehicleId == vehicleId).OrderByDescending(x => x.Date).Limit(pageSize).Offset((page - 1) * pageSize).ToList();
                    break;
                default:
                    break;
            }
            
            return resultPage ?? new List<OdometerRecord>();
        }

        public int GetNumberOfOdometerRecordsByVehicleId(int vehicleId)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            var odometerRecords = table.Find(Query.EQ(nameof(OdometerRecord.VehicleId), vehicleId));
            return odometerRecords.Count();
        }

        public OdometerRecord GetOdometerRecordById(int odometerRecordId)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            return table.FindById(odometerRecordId);
        }
        public bool DeleteOdometerRecordById(int odometerRecordId)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            table.Delete(odometerRecordId);
            db.Checkpoint();
            return true;
        }
        public bool SaveOdometerRecordToVehicle(OdometerRecord odometerRecord)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            table.Upsert(odometerRecord);
            db.Checkpoint();
            return true;
        }
        public bool DeleteAllOdometerRecordsByVehicleId(int vehicleId)
        {
            var db = _liteDB.GetLiteDB();
            var table = db.GetCollection<OdometerRecord>(tableName);
            var odometerRecords = table.DeleteMany(Query.EQ(nameof(OdometerRecord.VehicleId), vehicleId));
            db.Checkpoint();
            return true;
        }

    }
}
