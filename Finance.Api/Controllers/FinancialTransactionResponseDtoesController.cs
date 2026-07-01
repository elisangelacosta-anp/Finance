using Finance.Api.DTOs;
using Finance.Api.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Finance.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class FinancialTransactionsController : ControllerBase
{
    private readonly IFinancialTransactionService _service;

    public FinancialTransactionsController(IFinancialTransactionService service)
    {
        _service = service;
    }

    // GET: api/financialtransactions
    [HttpGet]
    public async Task<ActionResult<List<FinancialTransactionResponseDto>>> GetAll()
    {
        var result = await _service.GetAllAsync();
        return Ok(result);
    }

    // GET: api/financialtransactions/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<FinancialTransactionResponseDto>> GetById(Guid id)
    {
        var result = await _service.GetByIdAsync(id);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // POST: api/financialtransactions
    [HttpPost]
    public async Task<ActionResult<FinancialTransactionResponseDto>> Create(
        [FromBody] CreateFinancialTransactionDto dto)
    {
        var result = await _service.CreateAsync(dto);

        return CreatedAtAction(
            nameof(GetById),
            new { id = result.Id },
            result);
    }

    // PUT: api/financialtransactions/{id}
    [HttpPut("{id}")]
    public async Task<ActionResult<FinancialTransactionResponseDto>> Update(
        Guid id,
        [FromBody] UpdateFinancialTransactionDto dto)
    {
        var result = await _service.UpdateAsync(id, dto);

        if (result == null)
            return NotFound();

        return Ok(result);
    }

    // DELETE: api/financialtransactions/{id}
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _service.DeleteAsync(id);

        if (!result)
            return NotFound();

        return NoContent();
    }
}