namespace DWH.ETL.Interfaces {
    public interface IETLProcess<TInput, TOutput> {
        TOutput Process(TInput input);
    }
}
