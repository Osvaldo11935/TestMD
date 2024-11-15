using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Interfaces.IRepositories.ICommon;
using Teste.Interfaces.IRepositories;
using Teste.Models.Requests;
using Teste.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Test.Models.Responses.Common;

namespace Teste.UseCases
{
    public class SaleUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISaleRepository _saleRepository;
        private readonly IProductRepository _productRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<SaleUseCase> _logger;

        public SaleUseCase(ISaleRepository saleRepository, IUnitOfWork unitOfWork, ILogger<SaleUseCase> logger, ICustomerRepository customerRepository, IProductRepository productRepository)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _saleRepository = saleRepository ?? throw new ArgumentNullException(nameof(saleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _customerRepository = customerRepository;
            _productRepository = productRepository;
        }

        public async Task<Result<bool>> InsertSaleAsync(Guid customerId, List<CreateItemsSaleRequest> request)
        {
            try
            {
                _logger.LogInformation("Iniciando inserção do Venda.");

                var customer = _customerRepository.Query()
                    .Include(e => e.Sales)
                    .FirstOrDefault(x => x.Id == customerId);

                if (customer == null) {
                    _logger.LogWarning("Cliente não encontrado.");
                    return new ErrorResponse()
                    {
                        Code = "CustomerNotFound",
                        Message = "Falha ao buscar o cliente",
                        Description = "Cliente não encontrado."
                    };
                }

                customer.AddSale(request);

                await _saleRepository.InsertAsync(customer.Sales.ToList());

                await _unitOfWork.SaveChangeAsync();

                await UpdateProductQuantityAsync(request);

                _logger.LogInformation("Venda inserido com sucesso.");


                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir o Venda.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao registrar venda",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public async Task<Result<bool>> UpdateProductQuantityAsync(List<CreateItemsSaleRequest> requests)
        {
            try
            {
                _logger.LogInformation("Iniciando atualização da quantidade do produto.");

                var productsIds = requests.Select(x => x.ProductId).ToList();

                var products = _productRepository.Query()
                    .Where(e => productsIds.Contains(e.Id.Value)).ToList();

                if (!products.Any())
                {
                    _logger.LogWarning("Produtos não encontrado.");
                    return new ErrorResponse()
                    {
                        Code = "ProductNotFound",
                        Message = "Falha ao atualizar quantidades dos produtos",
                        Description = $"Produtos não encontrado.",
                    };

                }
                products.ForEach(e =>
                {
                    var cd = requests.FirstOrDefault(r => r.ProductId == e.Id);
                    if (cd != null)
                    {
                        e.Quantity = e.Quantity - cd.Quantity;
                    }
                });

                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Quantidades dos produtos atualizado com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o quantidades dos produtos");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao atualizar quantidades dos produtos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }

        public async Task<Result<bool>> DeleteSaleAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Iniciando deleção do Venda com ID: {SaleId}", id);

                var sale = _saleRepository.Query().FirstOrDefault(x => x.Id == id);

                if (sale is null)
                {
                    _logger.LogWarning("Venda com ID: {SaleId} não encontrado.", id);
                    return new ErrorResponse()
                    {
                        Code = "CustomerNotFound",
                        Message = "Falha ao buscar o cliente",
                        Description = $"Venda com ID: {id} não encontrado."
                    };
                }

                _saleRepository.Remove(sale);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Venda com ID: {SaleId} deletado com sucesso.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar o Venda com ID: {SaleId}", id);
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao remover venda",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
    }
}
