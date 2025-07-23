using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

// --- CLASSE DO SEU DBCONTEXT (COM A CORREÇÃO PARA O AVISO) ---
public class ApiDbContext : DbContext
{
    public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
    {
    }

    public DbSet<Veiculo> Veiculos { get; set; }

    // Configuração para a propriedade 'Preco' para evitar o aviso
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Veiculo>().Property(p => p.Preco).HasColumnType("decimal(18, 2)");
    }
}


// --- FÁBRICA DE DBCONTEXT (COM A CORREÇÃO FINAL PARA O ERRO) ---
// Esta classe ensina as ferramentas de linha de comando a criar o seu DbContext.
// Colocamos a Connection String diretamente aqui como nosso teste final.
public class ApiDbContextFactory : IDesignTimeDbContextFactory<ApiDbContext>
{
    public ApiDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ApiDbContext>();
        
        // AQUI ESTÁ A MUDANÇA: Em vez de ler o arquivo, colocamos a 
        // connection string diretamente no código para forçar o funcionamento.
        var connectionString = "Server=localhost\\SQLEXPRESS;Database=VendasVeiculos;Trusted_Connection=True;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new ApiDbContext(optionsBuilder.Options);
    }
}