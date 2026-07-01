using Finance.Api.Models;
using Finance.Api.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Finance.Api.Data;

public class MongoDbContext
{
    private readonly IMongoDatabase _database;

    public MongoDbContext(IOptions<MongoSettings> settings)
    {
        var client = new MongoClient(settings.Value.ConnectionString);

        _database = client.GetDatabase(settings.Value.DatabaseName);
    }

    public IMongoCollection<FinancialTransaction> FinancialTransactions =>
        _database.GetCollection<FinancialTransaction>(
            "FinancialTransactions");
}