using DWH.Domain;
using DWH.ETL.Interfaces;
using DWH.Storage;
using System;
using System.Collections.Generic;

namespace DWH.ETL.Load {
    public class LoadProcess : IETLProcess<List<LoadCarDetail>, bool> {
        private DateTime loadTimestamp;
        public LoadProcess() {
            loadTimestamp = DateTime.Now;
        }

        public bool Process(List<LoadCarDetail> carDetails) {
            var carDetailRepository = new CarDetailsRepository(new DataWarehouseContext());

            try {
                foreach (var carDetail in carDetails) {
                    carDetail.InsertedDttm = loadTimestamp;
                    carDetailRepository.Insert(carDetail);
                }

                carDetailRepository.SaveChanges();
            } catch (Exception ex) {
                Console.WriteLine("Problem occures during loading data into warehouse: [EXCEPTION MESSAGE]: {0}, [INNER EXCEPTION MESSAGE]: {1}", ex.Message, ex.InnerException?.Message);
                return false;
            }

            return true;
        }
    }
}
