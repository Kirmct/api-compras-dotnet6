using ApiCompras.Application.DTOs;
using ApiCompras.Application.DTOs.Validations;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Repositories;
using AutoMapper;

namespace ApiCompras.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
    }

    public async Task<ResultService<ProductDTO>> CreateAsync(ProductDTO productDTO)
    {
        var validation = new ProductDTOValidator().Validate(productDTO);
        if (!validation.IsValid)
            return ResultService.RequestError<ProductDTO>("Dados inválidos!", validation);

        var product = _mapper.Map<Product>(productDTO);
        await _productRepository.CreateAsync(product);

        return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(product));
    }

    public async Task<ResultService> DeleteAsync(int id)
    {
        var data = await _productRepository.GetByIdAsync(id);
        if (data == null)
            return ResultService.Fail("Produto não encontrado");

        await _productRepository.DeleteAsync(data);
        return ResultService.Ok("Produto deletado com sucesso!");
    }

    public async Task<ResultService<ICollection<ProductDTO>>> GetAllAsync()
    {
        var data = await _productRepository.GetAllAsync();
        var result = _mapper.Map<ICollection<ProductDTO>>(data);
        return ResultService.Ok<ICollection<ProductDTO>>(result);
    }

    public async Task<ResultService<ProductDTO>> GetByIdAsync(int id)
    {
        var data = await _productRepository.GetByIdAsync(id);

        if (data == null)
            return ResultService.Fail<ProductDTO>("Produto não encontrado");

        return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(data));
    }

    public async Task<ResultService<ProductDTO>> UpdateAsync(ProductDTO productDTO)
    {
        var validation = new ProductDTOValidator().Validate(productDTO);
        if (!validation.IsValid)
            return ResultService.RequestError<ProductDTO>("Dados inválidos", validation);

        var product = await _productRepository.GetByIdAsync(productDTO.Id);
        if (product == null)
            return ResultService.Fail<ProductDTO>("Produto não encontrado!");

        product = _mapper.Map<ProductDTO, Product>(productDTO, product);
        product.Update();

        await _productRepository.UpdateAsync(product);
        return ResultService.Ok<ProductDTO>(_mapper.Map<ProductDTO>(product));
    }
}
