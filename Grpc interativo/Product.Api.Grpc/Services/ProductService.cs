using Grpc.Core;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Google.Protobuf.WellKnownTypes;
using System;
using System.Threading.Tasks;

namespace Product.Api.Grpc.Services
{
    public class ProductService : Product.ProductBase
    {
        private readonly IConfiguration _configuration;

        public ProductService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public override async Task<GetProductBrandResponse> GetProductBrand(GetProductBrandRequest request, ServerCallContext context)
        {
            Console.WriteLine($"Recebido request para produto: {request.Name}");

            var response = new GetProductBrandResponse();
            string connectionString = _configuration.GetConnectionString("DefaultConnection");

            using var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();

            string query = @"
                SELECT Id, BrandName, ProductName, SuggestedPrice, CreatedAt
                FROM Products 
                WHERE LOWER(ProductName) = LOWER(@name)";

            using var command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@name", request.Name);

            using var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                response.Productbrand.Add(new GetProductBrandResponseModel
                {
                    Key = reader["Id"].ToString(),
                    Brandname = reader["BrandName"].ToString(),
                    Productname = reader["ProductName"].ToString(),
                    Suggestedprice = reader["SuggestedPrice"].ToString(),
                    CreatedAt = Timestamp.FromDateTime(((DateTime)reader["CreatedAt"]).ToUniversalTime())
                });
            }

            return response;
        }
    }
}
