using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste_ControleDeCinema.Dominio.ModuloSessao;

namespace Teste_ControleDeCinema.Orm.ModuloSessao
{
    public class MapeadorSessaoOrm : IEntityTypeConfiguration<Sessao>
    {
        public void Configure(EntityTypeBuilder<Sessao> builder)
        {
            builder.ToTable("TBSessao");
            builder.Property(x => x.Id).ValueGeneratedNever();
            builder.Property(x => x.Data).IsRequired();
            builder.Property(x => x.HoraInicio).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.HoraTermino).HasColumnType("bigint").IsRequired();
            builder.Property(x => x.TipoSessao).HasConversion<int>().IsRequired();
            builder.Property(x => x.TipoAudio).HasConversion<int>().IsRequired();
            builder.Property(x => x.ValorIngresso).IsRequired();

          

            builder.HasOne(x => x.Filme)
                .WithMany(x => x.Sessoes)
                .IsRequired()
                .HasForeignKey(x => x.FilmeId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Sala)
               .WithMany(x => x.Sessoes)
               .IsRequired()
               .HasForeignKey(x => x.SalaId)
               .OnDelete(DeleteBehavior.NoAction);



        }
    }
}
