using ApiCompras.Application.DTOs.PersonImage;
using ApiCompras.Application.DTOs.Validations;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Integration;
using ApiCompras.Domain.Repositories;
using AutoMapper;

namespace ApiCompras.Application.Services;

public class PersonImageService : IPersonImageService
{
    private readonly IPersonRepository _personRepository;
    private readonly IPersonImageRepository _personImageRepository;    
    private readonly ISavePersonImage _savePersonImage;

    public PersonImageService(
        IPersonRepository personRepository, 
        IPersonImageRepository personImageRepository, 
        ISavePersonImage savePersonImage)
    {
        _personRepository = personRepository;
        _personImageRepository = personImageRepository;
        _savePersonImage = savePersonImage;
    }

    public async Task<ResultService> CreateImageBase64Async(PersonImageDTO personImageDto)
    {
        if (personImageDto == null)
            return ResultService.Fail("Objeto deve ser informado");

        var validations = new PersonImageDTOValidatior().Validate(personImageDto);
        if (!validations.IsValid)
            return ResultService.RequestError("Erros de validação", validations);

        var person = await _personRepository.GetByIdAsync(personImageDto.PersonId);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada!");

        var personImage = new PersonImage(
                            personImageDto.PersonId, 
                            null, 
                            personImageDto.Image);

        await _personImageRepository.CreateAsync(personImage);
        return ResultService.Ok("Imagem em Base64 salva");
    }

    public async Task<ResultService> CreateImageUrlAsync(PersonImageDTO personImageDto)
    {
        if (personImageDto == null)
            return ResultService.Fail("Objeto deve ser informado");

        var validations = new PersonImageDTOValidatior().Validate(personImageDto);
        if (!validations.IsValid)
            return ResultService.RequestError("Erros de validação", validations);

        var person = await _personRepository.GetByIdAsync(personImageDto.PersonId);
        if (person == null)
            return ResultService.Fail("Pessoa não encontrada!");

        var filePath = _savePersonImage.Save(personImageDto.Image);

        var personImage = new PersonImage(
                            personImageDto.PersonId,
                            filePath,
                            personImageDto.Image);

        await _personImageRepository.CreateAsync(personImage);

        return ResultService.Ok(filePath);
    }

    public Task<ResultService<ICollection<PersonImageDTO>>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<ICollection<PersonImageDTO>>> GetAllByPersonId(int personId)
    {
        throw new NotImplementedException();
    }

    public Task<ResultService<PersonImageDTO>> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(PersonImage personImage)
    {
        throw new NotImplementedException();
    }
}
