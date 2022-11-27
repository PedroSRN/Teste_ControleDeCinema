using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.ModuloFilme;

namespace Teste_ControleDeCinema.Orm.ModuloFilme
{
    public class MapeadorFilmeOrm : IEntityTypeConfiguration<Filme>
    {
        public void Configure(EntityTypeBuilder<Filme> builder)
        {
            builder.ToTable("TBFilme");

            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Titulo).HasColumnType("varchar(200)").IsRequired();
            builder.Property(x => x.Duracao).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.Descricao).HasColumnType("varchar(500)").IsRequired();
        }
    }
}
