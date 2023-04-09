using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Data;

public class TranslationContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Data Source=localhost,1433;Initial Catalog=translation;Integrated Security=False;User ID=SA;Password=password_135790;TrustServerCertificate=True");
        }
    }
}