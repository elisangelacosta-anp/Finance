using Finance.Api.Data;
using Finance.Api.Interfaces;
using Finance.Api.Models;
using MongoDB.Driver;

namespace Finance.Api.Repositories;

public class MongoFinancialTransactionRepository : IFinancialTransactionRepository
{
    private readonly IMongoCollection<FinancialTransaction> _collection;

    public MongoFinancialTransactionRepository(MongoDbContext context)
    {
        _collection = context.FinancialTransactions;
    }

    public async Task<List<FinancialTransaction>> GetAllAsync()
    {
        return await _collection
            .Find(_ => true)
            .ToListAsync();
    }

    public async Task<FinancialTransaction?> GetByIdAsync(Guid id)
    {
        return await _collection
            .Find(x => x.Id == id)
            .FirstOrDefaultAsync();
    }

    public async Task AddAsync(FinancialTransaction entity)
    {
        await _collection.InsertOneAsync(entity);
    }

    public async Task UpdateAsync(FinancialTransaction entity)
    {
        await _collection.ReplaceOneAsync(
            x => x.Id == entity.Id,
            entity);
    }

    public async Task DeleteAsync(Guid id)
    {
        await _collection.DeleteOneAsync(
            x => x.Id == id);
    }
}