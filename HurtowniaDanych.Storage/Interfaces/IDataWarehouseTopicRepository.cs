namespace HurtowniaDanych.Storage {
    public interface IDataWarehouseTopicRepository<TTopic> {
        TTopic Insert(TTopic topic);
        void SaveChanges();
    }
}
