using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Mappings
{
    public class UsuarioMapping : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            
            builder.ToTable("Usuario");

            builder.Property(u => u.CodUsuario)
             .HasColumnName("Cod_Usuario");

            
            builder.HasKey(u => u.CodUsuario);

        }
    }
}
