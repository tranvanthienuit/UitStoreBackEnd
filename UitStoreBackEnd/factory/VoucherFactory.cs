using UitStoreBackEnd.db_context;
using UitStoreBackEnd.entity;

namespace UitStoreBackEnd.factory;

public interface IVoucherFactory
{
    Task<Voucher> create(Voucher Voucher);

    Task<bool> deleteById(Guid id);

    Task<Voucher> update(Voucher Voucher);

    Task<Voucher> getDetail(Guid id);

    List<Voucher> getList();
}

public class VoucherFactory : IVoucherFactory
{
    private readonly dbcontext _dbcontext;

    public VoucherFactory(dbcontext dbcontext)
    {
        _dbcontext = dbcontext;
    }

    public async Task<Voucher> create(Voucher Voucher)
    {
        var result = await _dbcontext.Vouchers.AddAsync(Voucher);
        await _dbcontext.SaveChangesAsync();
        return result.Entity;
    }

    public async Task<bool> deleteById(Guid id)
    {
        try
        {
            var Voucher = getDetail(id).Result;
            _dbcontext.Vouchers.Remove(Voucher);
            await _dbcontext.SaveChangesAsync();
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return false;
        }
    }

    public async Task<Voucher> update(Voucher Voucher)
    {
        var voucher = _dbcontext.Vouchers.Update(Voucher).Entity;
        await _dbcontext.SaveChangesAsync();
        return voucher;
    }

    public async Task<Voucher> getDetail(Guid id)
    {
        return await _dbcontext.Vouchers.FindAsync(id) ?? throw new InvalidOperationException();
    }

    public List<Voucher> getList()
    {
        return _dbcontext.Vouchers.ToList();
    }
}