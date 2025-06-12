using Dapper;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly IConfiguration _configuration;

        public ProductRepository(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task<List<Product>> GetAllAsync()
        {
            using var connection = GetConnection();
            var sql = "select * from Product";
            var products = await connection.QueryAsync<Product>(sql);
            return products.ToList();
        }
        public async Task<Product?> GetByIdAsync(int id)
        {
            using var connection = GetConnection();
            var sql = "select * from product where product_id = @product_id";
            var product = await connection.QueryFirstOrDefaultAsync<Product>(sql, new { @product_id = id });
            return product;
        }

        public async Task<int> AddAsync(Product product)
        {
            using var connection = GetConnection();
            var sql = "insert into product (product_name,product_desc,product_price,createdDate) " +
                    "values (@product_name,@product_desc,@product_price,@createdDate); SELECT CAST(SCOPE_IDENTITY() as int)";
            int id = await connection.ExecuteScalarAsync<int>(sql, product);
            return id; ;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            using var connection = GetConnection();
            var sql = "delete from product where product_id = @product_id";
            var rows = await connection.ExecuteAsync(sql, new { product_id = id });
            return rows > 0;
        }

        public async Task<bool> UpdateAsync(Product product)
        {
            using var connection = GetConnection();
            var sql = "update product set product_name=@product_name,product_desc=@product_desc,product_price=@product_price where product_id = @product_id";
            var rows = await connection.ExecuteAsync(sql, product);
            return rows > 0;
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }
    }
}
