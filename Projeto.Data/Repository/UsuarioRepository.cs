using Projeto.Data.Context;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Projeto.Data.Repository
{
  public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly DataColetrans dataContext;

        public UsuarioRepository(DataColetrans dataContext) : base(dataContext) 
        {
            this.dataContext = dataContext;
        }

    }
}
