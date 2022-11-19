namespace UitStoreBackEnd.base_factory;

public interface IBaseFactory<I, DT, F>
{
    Task<DT> create(DT DT);

    Task<bool> deleteById(I ID);

    Task<DT> update(DT DT);

    Task<DT> getDetailById(I ID);

    Task<List<DT>> getList();

    Task<List<DT>> getPage(F Filter);
}