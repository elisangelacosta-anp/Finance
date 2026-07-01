using Finance.Api.Data;
using Finance.Api.Interfaces;
using Finance.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Finance.Api.Repositories;

public class FinancialTransactionRepository : IFinancialTransactionRepository
{
    private readonly FinanceDbContext _context;

    public FinancialTransactionRepository(FinanceDbContext context)
    {
        _context = context;
    }

    public async Task<List<FinancialTransaction>> GetAllAsync()
    {
        return await _context.FinancialTransactions
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<FinancialTransaction?> GetByIdAsync(Guid id)
    {
        return await _context.FinancialTransactions
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task AddAsync(FinancialTransaction entity)
    {
        await _context.FinancialTransactions.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(FinancialTransaction entity)
    {
        _context.FinancialTransactions.Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Guid id)
    {
        var entity = await _context.FinancialTransactions
            .FirstOrDefaultAsync(x => x.Id == id);

        if (entity == null)
            return;

        _context.FinancialTransactions.Remove(entity);
        await _context.SaveChangesAsync();
    }
}