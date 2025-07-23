using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// --- 1. CONFIGURAÇÃO DOS SERVIÇOS ---

// ✨ A MUDANÇA ESTÁ AQUI: ignoramos o appsettings.json e colocamos o endereço "na marra" ✨
var connectionString = "Server=localhost\\SQLEXPRESS;Database=VendasVeiculos;Trusted_Connection=True;TrustServerCertificate=True;";

// Configura a conexão com o Banco de Dados SQL Server
builder.Services.AddDbContext<ApiDbContext>(options =>
    options.UseSqlServer(connectionString));

// Configura o Swagger para gerar a documentação da API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Ensina a API a converter Enums (como o StatusVenda) para texto no JSON
builder.Services.Configure<Microsoft.AspNetCore.Http.Json.JsonOptions>(options =>
{
    options.SerializerOptions.Converters.Add(new JsonStringEnumConverter());
});


// --- 2. CONSTRUÇÃO DA APLICAÇÃO ---
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();


// --- 3. ENDPOINTS (AS FUNCIONALIDADES DA API) ---

// GET /veiculos - Listar todos os veículos
app.MapGet("/veiculos", (ApiDbContext context) =>
{
    var veiculos = context.Veiculos.ToList();
    return Results.Ok(veiculos);
});

// POST /veiculos - Adicionar um novo veículo
app.MapPost("/veiculos", (ApiDbContext context, Veiculo veiculo) =>
{
    context.Veiculos.Add(veiculo);
    context.SaveChanges();
    return Results.Created($"/veiculos/{veiculo.Id}", veiculo);
});

// GET /veiculos/{id} - Buscar um veículo por ID
app.MapGet("/veiculos/{id}", (ApiDbContext context, int id) =>
{
    var veiculo = context.Veiculos.Find(id);
    if (veiculo == null)
    {
        return Results.NotFound("Veículo não encontrado.");
    }
    return Results.Ok(veiculo);
});

// PUT /veiculos/{id} - Atualizar um veículo
app.MapPut("/veiculos/{id}", (ApiDbContext context, int id, Veiculo veiculoAlterado) =>
{
    var veiculo = context.Veiculos.Find(id);
    if (veiculo == null)
    {
        return Results.NotFound("Veículo não encontrado.");
    }

    veiculo.Nome = veiculoAlterado.Nome;
    veiculo.Marca = veiculoAlterado.Marca;
    veiculo.Ano = veiculoAlterado.Ano;
    veiculo.Preco = veiculoAlterado.Preco;
    veiculo.Cor = veiculoAlterado.Cor;
    veiculo.Kilometragem = veiculoAlterado.Kilometragem;
    veiculo.Status = veiculoAlterado.Status;

    context.SaveChanges();
    return Results.Ok(veiculo);
});

// DELETE /veiculos/{id} - Deletar um veículo
app.MapDelete("/veiculos/{id}", (ApiDbContext context, int id) =>
{
    var veiculo = context.Veiculos.Find(id);
    if (veiculo == null)
    {
        return Results.NotFound("Veículo não encontrado.");
    }
    
    context.Veiculos.Remove(veiculo);
    context.SaveChanges();
    return Results.NoContent();
});

// --- 4. INICIA A APLICAÇÃO ---
app.Run();