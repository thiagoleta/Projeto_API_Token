using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Services.Models.Motorista;
using Projeto.Services.Models.Rota;
using Projeto.Services.Models.Usuario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Projeto.Services.Mappings
{
    //classe de mapeamento do AutoMapper de forma a permitir
    //que classes de modelo (Models) possam transferir seus dados
    //para classes de entidade (Entities)

    public class ModelToEntityMapping : Profile
    {
        public ModelToEntityMapping()
        {
            CreateMap<RotaCadastroModel, Rota>();
            CreateMap<MotoristaCadastroModel, Motorista>();

            CreateMap<RotaEdicaoModel, Rota>();
            CreateMap<MotoristaEdicaoModel, Motorista>();

            CreateMap<UsuarioCadastroModel, Usuario>();

        }
    }
}
