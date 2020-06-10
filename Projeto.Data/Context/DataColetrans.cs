using Microsoft.EntityFrameworkCore;
using Projeto.Data.Entities;
using Projeto.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Context
{
    //REGRA 1) Deverá HERDAR DbContext
    public class DataColetrans : DbContext
    {


        //REGRA 2) Criando um construtor para injeção de dependência
        //este construtor irá receber configurações definidas na
        //classe Startup.cs do projeto API
        public DataColetrans(DbContextOptions<DataColetrans> options)
            : base(options) //construtor da superclasse
        {

        }

        //REGRA 3) Sobrescrita (OVERRIDE) do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento (Mapping) feito no projeto
            modelBuilder.ApplyConfiguration(new MotoristaMapping());
            modelBuilder.ApplyConfiguration(new RotaMapping());
            modelBuilder.ApplyConfiguration(new UsuarioMapping());


        }

                    //REGRA 4) Declarar um set/get utilizando a classe DbSet do EF
                    //para cada entidade do projeto. Este DbSet irá permitir o uso
                    //de expressões LAMBDA para executar consultas com qualquer
                    //uma das entidades
        public DbSet<Motorista> Motorista { get; set; } //LAMBDA Functions
        public DbSet<Rota> Rota { get; set; } //LAMBDA Functions
        public DbSet<Usuario> Usuario { get; set; } //LAMBDA Functions

    }

}

