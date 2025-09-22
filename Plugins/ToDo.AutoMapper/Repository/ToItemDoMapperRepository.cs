using AutoMapper;
using ToDo.Domain.Dtos;
using ToDo.Domain.Entity;
using ToDo.Domain.Interfaces.Mapper;

namespace ToDo.AutoMapper.Repository
{
    public class ToItemDoMapperRepository : IToItemDoMapperRepository
    {
        private readonly IMapper _mapper;

        public ToItemDoMapperRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public ToDoItem ToDoItemDtoToToDoItem(ToDoItemDto dto)
        {
            return _mapper.Map<ToDoItem>(dto);
        }

        public ToDoItemDto ToDoItemToToDoItemDto(ToDoItem item)
        {
            return _mapper.Map<ToDoItemDto>(item);
        }
    }
}
