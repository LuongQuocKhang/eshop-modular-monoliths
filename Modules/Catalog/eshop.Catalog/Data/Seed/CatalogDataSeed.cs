namespace eshop.Catalog.Data.Seed;

public class CatalogDataSeed(CatalogDbContext dbContext) : IDataSeeder
{
    
    public async Task SeedData()
    {
        if (dbContext.Products.Any()) return;

        await dbContext.Products.AddRangeAsync(InitialData.Products);
        await dbContext.SaveChangesAsync();
    }
}
