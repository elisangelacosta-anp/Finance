using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Finance.Api.DTOs;
using Finance.Api.Interfaces;
using Finance.Api.Models;

namespace Finance.Api.Services;

public class FinancialTransactionService : IFinancialTransactionService
{
    private readonly IFinancialTransactionRepository _repository;

    public FinancialTransactionService(IFinancialTransactionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<FinancialTransactionResponseDto>> GetAllAsync()
    {
        var entities = await _repository.GetAllAsync();

        return entities.Select(MapToResponse).ToList();
    }

    public async Task<FinancialTransactionResponseDto?> GetByIdAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            return null;

        return MapToResponse(entity);
    }

    public async Task<FinancialTransactionResponseDto> CreateAsync(CreateFinancialTransactionDto dto)
    {
        var entity = new FinancialTransaction
        {
            Id = Guid.NewGuid(),
            Description = dto.Description,
            Amount = dto.Amount,
            Type = dto.Type,
            TransactionDate = dto.TransactionDate,
            Category = dto.Category
        };

        await _repository.AddAsync(entity);

        return MapToResponse(entity);
    }

    public async Task<FinancialTransactionResponseDto?> UpdateAsync(Guid id, UpdateFinancialTransactionDto dto)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            return null;

        entity.Description = dto.Description;
        entity.Amount = dto.Amount;
        entity.Type = dto.Type;
        entity.TransactionDate = dto.TransactionDate;
        entity.Category = dto.Category;

        await _repository.UpdateAsync(entity);

        return MapToResponse(entity);
    }

    public async Task<bool> DeleteAsync(Guid id)
    {
        var entity = await _repository.GetByIdAsync(id);

        if (entity == null)
            return false;

        await _repository.DeleteAsync(id);

        return true;
    }

    private static FinancialTransactionResponseDto MapToResponse(FinancialTransaction entity)
    {
        return new FinancialTransactionResponseDto
        {
            Id = entity.Id,
            Description = entity.Description,
            Amount = entity.Amount,
            Type = (TransactionType)entity.Type,
            TransactionDate = entity.TransactionDate,
            Category = entity.Category
        };
    }
}