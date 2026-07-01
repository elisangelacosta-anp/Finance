using Finance.Api.DTOs;
using Finance.Api.Interfaces;
using Finance.Api.Models;
using Finance.Api.Services;
using Moq;
using Xunit;

namespace Finance.Api.Tests;

public class FinancialTransactionServiceTests
{
    private readonly Mock<IFinancialTransactionRepository> _repositoryMock;
    private readonly FinancialTransactionService _service;

    public FinancialTransactionServiceTests()
    {
        _repositoryMock = new Mock<IFinancialTransactionRepository>();
        _service = new FinancialTransactionService(_repositoryMock.Object);
    }

    // =========================
    // 1. CREATE
    // =========================
    [Fact]
    public async Task CreateAsync_ShouldReturnTransaction_WhenValidInput()
    {
        // Arrange
        var dto = new CreateFinancialTransactionDto
        {
            Description = "Venda teste",
            Amount = 150.00m,
            Type = TransactionType.Income,
            TransactionDate = DateTime.UtcNow,
            Category = "Vendas"
        };

        _repositoryMock
            .Setup(r => r.AddAsync(It.IsAny<FinancialTransaction>()))
            .Returns(Task.CompletedTask);

        // Act
        var result = await _service.CreateAsync(dto);

        // Assert
        Assert.NotNull(result);
        Assert.Equal(dto.Description, result.Description);
        Assert.Equal(dto.Amount, result.Amount);
        Assert.Equal(dto.Category, result.Category);
    }

    // =========================
    // 2. GET BY ID (NOT FOUND)
    // =========================
    [Fact]
    public async Task GetByIdAsync_ShouldReturnNull_WhenTransactionDoesNotExist()
    {
        // Arrange
        var id = Guid.NewGuid();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((FinancialTransaction)null);

        // Act
        var result = await _service.GetByIdAsync(id);

        // Assert
        Assert.Null(result);
    }

    // =========================
    // 3. DELETE (NOT FOUND)
    // =========================
    [Fact]
    public async Task DeleteAsync_ShouldReturnFalse_WhenTransactionDoesNotExist()
    {
        // Arrange
        var id = Guid.NewGuid();

        _repositoryMock
            .Setup(r => r.GetByIdAsync(id))
            .ReturnsAsync((FinancialTransaction)null);

        // Act
        var result = await _service.DeleteAsync(id);

        // Assert
        Assert.False(result);
    }
}