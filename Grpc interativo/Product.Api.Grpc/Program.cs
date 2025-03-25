using Product.Api.Grpc.Services;

var builder = WebApplication.CreateBuilder(args);

// Adicionar suporte ao gRPC
builder.Services.AddGrpc();

// Adicionar acesso ao banco de dados via MySQL
builder.Services.AddScoped<ProductService>();

var app = builder.Build();

// Configurar o gRPC
app.MapGrpcService<ProductService>();

app.Run();
