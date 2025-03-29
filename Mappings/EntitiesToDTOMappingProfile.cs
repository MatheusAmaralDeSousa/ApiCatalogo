using ApiCatalogo.DTO;
using ApiCatalogo.Models;
using AutoMapper;

namespace ApiCatalogo.Mappings
{
    public class EntitiesToDTOMappingProfile : Profile
    {
        public EntitiesToDTOMappingProfile() {
            //Aqui vamos mapear as relações entre Entidades e os DTOS
            //Entidade, DTO
            //ReverseMap(), utilizado para haver a possibilidade de passar informações tanto de User para UserDTO, quanto UserDTO para User.
            CreateMap<User, UserDTO>().ReverseMap();
        }

    }
}
