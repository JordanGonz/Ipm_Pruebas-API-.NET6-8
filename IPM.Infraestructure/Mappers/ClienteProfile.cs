using AutoMapper;
using IPM.Core.Dtos;
using IPM.Infraestructure.MainContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPM.Infraestructure.Mappers
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<ClienteDto,Cliente>();
            CreateMap<EditarCliente, Cliente>();
            CreateMap<EliminarCliente, Cliente>();
            CreateMap<Cliente, ConsultaCliente>();
        }
    }
}
