using Grpc.Net.Client;
using ProductGrpcClient;
using Google.Protobuf.WellKnownTypes;
using System;

class Program
{
    static async Task Main(string[] args)
    {
      
        var channel = GrpcChannel.ForAddress("http://localhost:5122");

        var client = new Product.ProductClient(channel);

        while (true)
        {
            Console.WriteLine("\nDigite o nome do produto que deseja consultar (ou 'exit' para sair):");
            string productName = Console.ReadLine();

            if (productName.ToLower() == "exit")
            {
                Console.WriteLine("Encerrando o cliente...");
                break;
            }

            var request = new GetProductBrandRequest { Name = productName };

            try
            {
                var response = await client.GetProductBrandAsync(request);

                if (response.Productbrand.Count > 0)
                {
                    foreach (var product in response.Productbrand)
                    {
                        Console.WriteLine("\nProduto Encontrado:");
                        Console.WriteLine($"Nome: {product.Productname}");
                        Console.WriteLine($"Marca: {product.Brandname}");
                        Console.WriteLine($"Preço Sugerido: {product.Suggestedprice}");
                        Console.WriteLine($"Criado em: {product.CreatedAt.ToDateTime()}\n");
                    }
                }
                else
                {
                    Console.WriteLine("Nenhum produto encontrado com esse nome.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro ao chamar o serviço gRPC: {ex.Message}");
            }
        }
    }
}