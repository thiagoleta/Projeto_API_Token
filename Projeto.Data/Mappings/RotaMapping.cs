using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Mappings
{
    public class RotaMapping : IEntityTypeConfiguration<Rota>
    {
        public void Configure(EntityTypeBuilder<Rota> builder)
        {
            //nome da tabela (opcional)
            builder.ToTable("Rota");


            //chave primária (obrigatório)
            builder.HasKey(r => r.CodRota);

            builder.Property(r => r.CodRota)
          .HasColumnName("Cod_Rota");

            builder.Property(r => r.Cod_Motorista)
        .HasColumnName("Cod_Motorista");




            //demais campos da entidade           

            #region Mapeamento dos Relacionamentos

            // Mapameamento de cardialidade 1 para muitos
            builder.HasOne(r => r.Motorista)
                .WithOne(m => m.Rota)
            .HasForeignKey<Motorista>(m => m.CodMotorista);



            #endregion
        }

    }
}

