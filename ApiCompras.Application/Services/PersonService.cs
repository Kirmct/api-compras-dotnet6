using ApiCompras.Application.DTOs;
using ApiCompras.Application.DTOs.Validations;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Entities;
using ApiCompras.Domain.FiltersDb;
using ApiCompras.Domain.Repositories;
using AutoMapper;

namespace ApiCompras.Application.Services;

public class PersonService : IPersonService
{
    private readonly IPersonRepository _personRepository;
    private readonly IMapper _mapper;

    public PersonService(IPersonRepository personRepository, IMapper mapper)
    {
        _personRepository = personRepository;
        _mapper = mapper;
    }
    public async Task<ResultService<PersonDTO>> CreateAsync(PersonDTO personDTO)
    {
        if (personDTO == null)
        {
            return ResultService.Fail<PersonDTO>("Objeto deve ser informado");
        }

        var result = new PersonDTOValidator().Validate(personDTO);
        if (!result.IsValid) 
        {
            return ResultService.RequestError<PersonDTO>("Problemas na validação!", result);
        }

        var person = _mapper.Map<Person>(personDTO);

        var data = await _personRepository.CreateAsync(person);
        return ResultService.Ok(_mapper.Map<PersonDTO>(data));
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var person = await _personRepository.GetByIdAsync(id);

        if (person == null)        
            return ResultService.Fail("Pessoa não encontrada!");
        
        await _personRepository.DeleteAsync(person);

        return ResultService.Ok("Pessoa deletada com sucesso!");
    }

    public async Task<ResultService<ICollection<PersonDTO>>> GetAsync()
    {
        var data = await _personRepository.GetAll();        
        return ResultService.Ok(_mapper.Map<ICollection<PersonDTO>>(data));
    }

    public async Task<ResultService<PersonDTO>> GetByIdAsync(int id)
    {
        var data = await _personRepository.GetByIdAsync(id);
        if (data == null)        
            return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");

        return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(data));
    }

    public async Task<ResultService<PageBaseResponseDTO<PersonDTO>>> GetPagedAsync(PersonFilterDb personFilterDb)
    {
        var peoplePaged = await _personRepository.GetPagedAsync(personFilterDb);

        var result = new PageBaseResponseDTO<PersonDTO>
                    (peoplePaged.TotalRegisters, 
                    _mapper.Map<List<PersonDTO>>(peoplePaged.Data));

        return ResultService.Ok(result);
    }

    public async Task<ResultService<PersonDTO>> UpdateAsync(PersonDTO personDTO)
    {
        if(personDTO == null)
            return ResultService.Fail<PersonDTO>("Objeto deve ser informado!");
        
        var validation = new PersonDTOValidator().Validate(personDTO);
        if (!validation.IsValid)
            return ResultService.RequestError<PersonDTO>("Dados inválidos", validation);

        var person = await _personRepository.GetByIdAsync(personDTO.Id);
        if (person == null)
            return ResultService.Fail<PersonDTO>("Pessoa não encontrada!");

        //mapeando os dados de personDTO para a person
        person = _mapper.Map<PersonDTO, Person>(personDTO, person); //de para
        person.Update();        

        await _personRepository.UpdateAsync(person);
        return ResultService.Ok<PersonDTO>(_mapper.Map<PersonDTO>(person));
    }
}
