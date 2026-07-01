using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Finance.Api.DTOs;

namespace Finance.Api.Interfaces;

public interface IFinancialTransactionService
{
    Task<List<FinancialTransactionResponseDto>> GetAllAsync();

    Task<FinancialTransactionResponseDto?> GetByIdAsync(Guid id);

    Task<FinancialTransactionResponseDto> CreateAsync(CreateFinancialTransactionDto dto);

    Task<FinancialTransactionResponseDto?> UpdateAsync(Guid id, UpdateFinancialTransactionDto dto);

    Task<bool> DeleteAsync(Guid id);
}