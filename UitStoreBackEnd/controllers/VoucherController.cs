using Microsoft.AspNetCore.Mvc;
using UitStoreBackEnd.entity;
using UitStoreBackEnd.factory;

namespace UitStoreBackEnd.Controllers;

public interface IVoucherController
{
    Task<IActionResult> create(Voucher voucher);

    Task<IActionResult> getDetailById(Guid id);

    Task<IActionResult> update(Voucher voucher);

    Task<IActionResult> delete(Guid id);

    Task<IActionResult> getList();
}

[Route("/api/v1/voucher")]
public class VoucherController : Controller, IVoucherController
{
    private readonly IVoucherFactory iVoucherFactory;

    public VoucherController(IVoucherFactory iVoucherFactory)
    {
        this.iVoucherFactory = iVoucherFactory;
    }

    [HttpPost("create")]
    public async Task<IActionResult> create([FromBody] Voucher voucher)
    {
        return Ok(await iVoucherFactory.create(voucher));
    }

    [HttpGet("{id}/detail")]
    public async Task<IActionResult> getDetailById(Guid id)
    {
        return Ok(await iVoucherFactory.getDetail(id));
    }

    [HttpPut("update")]
    public async Task<IActionResult> update([FromBody] Voucher voucher)
    {
        return Ok(await iVoucherFactory.update(voucher));
    }

    [HttpDelete("{id}/delete")]
    public async Task<IActionResult> delete(Guid id)
    {
        return Ok(await iVoucherFactory.deleteById(id));
    }

    [HttpGet("list")]
    public async Task<IActionResult> getList()
    {
        return Ok(iVoucherFactory.getList());
    }
}