using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using dotnet_rpg.Dtos.Character;
using dotnet_rpg.Models;

namespace dotnet_rpg.Services.CharacterService
{
  public class CharacterService : ICharacterService
  {
    private static List<Character> characters = new List<Character> {
        new Character(),
        new Character {Id = 1, Name = "Sam"},
        new Character {Id = 2 , Name = "Bilbo"}
    };
    private readonly IMapper _mapper;

    public CharacterService(IMapper mapper)
    {
      _mapper = mapper;

    }
    public async Task<ServiceResponse<List<GetCharacterDto>>> AddCharacter(AddCharacterDto newCharacter)
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      characters.Add(newCharacter);
      serviceResponse.Data = characters;
      return serviceResponse;
    }

    public async Task<ServiceResponse<List<GetCharacterDto>>> GetAllCharacters()
    {
      ServiceResponse<List<GetCharacterDto>> serviceResponse = new ServiceResponse<List<GetCharacterDto>>();
      serviceResponse.Data = characters;
      return serviceResponse;
    }

    public async Task<ServiceResponse<GetCharacterDto>> GetCharacterById(int id)
    {
      ServiceResponse<GetCharacterDto> serviceResponse = new ServiceResponse<GetCharacterDto>();
      serviceResponse.Data = characters.FirstOrDefault(person => person.Id == id);
      return serviceResponse;
    }
  }
}