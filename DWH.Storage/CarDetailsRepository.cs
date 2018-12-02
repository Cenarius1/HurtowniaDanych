using DWH.Domain;
using DWH.Storage.Interface;

namespace DWH.Storage {
    public class CarDetailsRepository : IGenericRepository<LoadCarDetail> {
        private readonly DataWarehouseContext context;

        public CarDetailsRepository(DataWarehouseContext context) {
            this.context = context;
        }

        public LoadCarDetail Insert(LoadCarDetail dbo) {
            context.CarDetails.Add(dbo);

            return dbo;
        }

        public void SaveChanges() {
            context.SaveChanges();
        }
    }
}
