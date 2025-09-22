using AutoMapper;
using ToDo.Domain.Dtos;
using ToDo.Domain.Entity;

namespace ToDo.AutoMapper
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDoItemDto,ToDoItem>().ReverseMap();
        }
    }
}
