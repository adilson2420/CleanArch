using CleanArch.Dominio.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArch.Infrastutura.EntityConfiguration
{
    public class ConfiguracaoMembro : IEntityTypeConfiguration<Membro>
    {
        public void Configure(EntityTypeBuilder<Membro> builder)
        {
            builder.HasKey(m => m.Id);
            builder.Property(m => m.Nome).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Email).HasMaxLength(100).IsRequired();
            builder.Property(m => m.Sexo).HasMaxLength(1);
            builder.Property(m => m.Activo).IsRequired();

            builder.HasData(
                new Membro(1, "Adilson", "adilson@gmail.com", 'M', true),
                new Membro(1, "Clara", "clara@gmail.com", 'F', true)
                );
        }
    }
}
