using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.ModuloSala;

namespace Teste_ControleDeCinema.Orm.ModuloSala
{
    public class MapeadorSalaOrm : IEntityTypeConfiguration<Sala>
    {
        public void Configure(EntityTypeBuilder<Sala> builder)
        {
            builder.ToTable("TBSala");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Nome).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Capacidade).IsRequired();

            builder.HasOne(x => x.Usuario)
              .WithMany()
              .IsRequired(false)
              .HasForeignKey(x => x.UsuarioId)
              .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(new Sala("Sala - 1", 50));
            builder.HasData(new Sala("Sala - 2", 50));


        }
    }
}
