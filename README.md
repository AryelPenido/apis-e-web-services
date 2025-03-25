# Projeto gRPC com .NET 8 e MySQL

## 📌 Visão Geral
Este projeto implementa um serviço gRPC para consulta de marcas de produtos armazenados em um banco de dados MySQL. Ele consiste em:

- **Servidor gRPC** (Product.Api.Grpc)
- **Cliente gRPC** (ProductGrpcClient)
- **Banco de Dados MySQL** (Docker)

---

## 📦 Pré-requisitos
Certifique-se de ter instalado:
- [.NET 8 SDK](https://dotnet.microsoft.com/)
- [Docker](https://www.docker.com/)
---

## 🚀 Configuração do Ambiente

### 1️⃣ Subir o banco de dados MySQL com Docker

No diretório do projeto, execute o seguinte comando para iniciar o banco de dados:

```sh
docker-compose up -d
```

Isso criará um contêiner MySQL com o banco **ProductDb**.

---

### 2️⃣ Configurar o Servidor gRPC

1. Navegue até a pasta do servidor:
   ```sh
   cd Product.Api.Grpc
   ```
2. Restaure os pacotes NuGet:
   ```sh
   dotnet restore
   ```
3. Execute o servidor:
   ```sh
   dotnet run
   ```
   O servidor iniciará na porta **5122**.

---

### 3️⃣ Configurar o Cliente gRPC

1. Navegue até a pasta do cliente:
   ```sh
   cd ProductGrpcClient
   ```
2. Restaure os pacotes NuGet:
   ```sh
   dotnet restore
   ```
3. Execute o cliente:
   ```sh
   dotnet run
   ```
   O cliente pedirá o nome de um produto para consulta.

---

## 📡 Como Usar

1. Execute o servidor gRPC.
2. Execute o cliente gRPC.
3. No cliente, digite o nome do produto que deseja consultar.
4. O cliente retornará os detalhes da marca do produto, se disponível.

Exemplo de saída:
```
Digite o nome do produto que deseja consultar:
iPhone 15

Produto Encontrado:
Nome: iPhone 15
Marca: Apple
Preço Sugerido: R$ 7.299,99
Criado em: 2024-03-24T10:15:30Z
```