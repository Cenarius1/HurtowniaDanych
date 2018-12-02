using DWH.Domain;
using DWH.Storage.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace DWH.Storage {
    public class CarDetailsRepository : IGenericRepository<LoadCarDetail> {
        private readonly DataWarehouseContext context;

        public CarDetailsRepository(DataWarehouseContext context) {
            this.context = context;
        }

        public LoadCarDetail Insert(LoadCarDetail dbo) {
            if (context.CarDetails.Any(i => i.Id == dbo.Id)) {
                return null;
            };

            context.CarDetails.Add(dbo);

            return dbo;
        }

        public List<LoadCarDetail> SelectAll() {
            var carDetails = context.CarDetails.ToList();
            return carDetails;
        }

        public List<LoadCarDetail> Find(Expression<Func<LoadCarDetail, bool>> prediction) {
            var carDetails = context.CarDetails.Where(prediction).ToList();
            return carDetails;
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
