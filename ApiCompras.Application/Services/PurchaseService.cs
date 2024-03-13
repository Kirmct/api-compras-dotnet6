using ApiCompras.Application.DTOs;
using ApiCompras.Application.DTOs.Validations;
using ApiCompras.Application.Services.Interface;
using ApiCompras.Domain.Entities;
using ApiCompras.Domain.Repositories;
using AutoMapper;

namespace ApiCompras.Application.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IPersonRepository _personRepository;
        private readonly IProductRepository _productRepository; 
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public PurchaseService(
            IPurchaseRepository purchaseRepository, 
            IPersonRepository personRepository, 
            IProductRepository productRepository, 
            IMapper mapper,
            IUnitOfWork unitOfWork)
        {
            _purchaseRepository = purchaseRepository;
            _personRepository = personRepository;
            _productRepository = productRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ResultService<ICollection<PurchaseDetailDTO>>> GetAllAsync()
        {
            var result = await _purchaseRepository.GetAllAsync();
            return ResultService.Ok(_mapper.Map<ICollection<PurchaseDetailDTO>>(result));
        }

        public async Task<ResultService<PurchaseDTO>> CreateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");

            var validation = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Dados inválidos!", validation);

            //transacao caso ele passe um produto que nao exista
            //vamos criar uma transacao para criar o produto, e caso de certo fazemos o commit            
            try
            {
                await _unitOfWork.BeginTransaction();

                var productId = await _productRepository.GetIdByCodeErp(purchaseDTO.CodeErp);
                if (productId == 0)
                {
                    var product = new Product(purchaseDTO.ProductName, purchaseDTO.CodeErp, purchaseDTO.Price ?? 0);
                    await _productRepository.CreateAsync(product);
                    productId = product.Id;
                }

                var personId = await _personRepository.GetIdByDocument(purchaseDTO.Document);

                var purchase = new Purchase(productId, personId);

                var data = await _purchaseRepository.CreateAsync(purchase);
                purchaseDTO.Id = data.Id;
                //caso de tudo certo commitamos
                await _unitOfWork.Commit();
                return ResultService.Ok<PurchaseDTO>(purchaseDTO);
                
            }
            catch (Exception e)
            {
                //caso tenha alguma falha demos rollback
                await _unitOfWork.Rollback();
                return ResultService.Fail<PurchaseDTO>(e.Message);
            }           
        }

        public async Task<ResultService> DeleteAsync(int id)
        {
            var result = await _purchaseRepository.GetByIdAsync(id);
            if (result == null)
                return ResultService.Fail("Compra não encontrada!");

            await _purchaseRepository.DeleteAsync(result);

            return ResultService.Ok("Compra apagada com sucesso!");
        }       

        public async Task<ResultService<PurchaseDetailDTO>> GetByIdAsync(int id)
        {
            var data = await _purchaseRepository.GetByIdAsync(id);
            if (data == null)
                return ResultService.Fail<PurchaseDetailDTO>("Compra não encontrada!");
            var result = _mapper.Map<PurchaseDetailDTO>(data);
            return ResultService.Ok<PurchaseDetailDTO>(result);
        }

        public async Task<ResultService<PurchaseDTO>> UpdateAsync(PurchaseDTO purchaseDTO)
        {
            if (purchaseDTO == null)
                return ResultService.Fail<PurchaseDTO>("Objeto deve ser informado!");
            
            var validation = new PurchaseDTOValidator().Validate(purchaseDTO);
            if (!validation.IsValid)
                return ResultService.RequestError<PurchaseDTO>("Erro na validação", validation);

            var data = await _purchaseRepository.GetByIdAsync(purchaseDTO.Id);
            if (data == null)
                return ResultService.Fail<PurchaseDTO>("Compra não encontrada!");

            var productId = await _productRepository.GetIdByCodeErp(purchaseDTO.CodeErp);
            var personId = await _personRepository.GetIdByDocument(purchaseDTO.Document);
            data.UpdateEntity(data.Id, productId, personId);

            await _purchaseRepository.UpdateAsync(data);
            purchaseDTO.Id = purchaseDTO.Id;

            return ResultService.Ok<PurchaseDTO>(purchaseDTO);
        }
    }
}
