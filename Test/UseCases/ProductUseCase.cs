using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Test.Models.Responses.Common;
using Teste.Interfaces.IRepositories;
using Teste.Interfaces.IRepositories.ICommon;
using Teste.Models.Entities;
using Teste.Models.Requests;

namespace Teste.UseCases
{
    public class ProductUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IProductRepository _productRepository;
        private readonly ILogger<ProductUseCase> _logger;

        public ProductUseCase(IProductRepository productRepository, IUnitOfWork unitOfWork, ILogger<ProductUseCase> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _productRepository = productRepository ?? throw new ArgumentNullException(nameof(productRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Result<List<Product>> FindAllProduct(string search = null)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de produtos.");

                var query = _productRepository.Query();

                if (!string.IsNullOrEmpty(search))
                {
                    _logger.LogInformation("Filtrando produtos com base na pesquisa: {SearchTerm}", search);
                    query = query.Where(e => e.Name.Contains(search));
                }

                var products = query.ToList();

                _logger.LogInformation("Consulta de produtos concluída com {Count} resultados.", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar produtos.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar os produtos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public Result<List<Product>> FindAllProductsAvailableForSale(string search = null)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de produtos.");

                var query = _productRepository.Query()
                    .Where(e => e.Quantity > 0);

                if (!string.IsNullOrEmpty(search))
                {
                    _logger.LogInformation("Filtrando produtos com base na pesquisa: {SearchTerm}", search);
                    query = query.Where(e => e.Name.Contains(search));
                }

                var products = query.ToList();

                _logger.LogInformation("Consulta de produtos concluída com {Count} resultados.", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar produtos.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar os produtos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public Result<List<Product>> FindProductInStock(DateTime startDate = default, DateTime endDate = default, string search = null)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de produtos.");

                var query = _productRepository.Query()
                    .Where(e => e.Quantity > 0);

                if (startDate != default && endDate != default)
                {
                    query = query.Where(e => e.CreatedAt.Value.Date >= startDate.Date && e.CreatedAt.Value.Date <= endDate.Date);
                }

                if (!string.IsNullOrEmpty(search))
                {
                    _logger.LogInformation("Filtrando produtos com base na pesquisa: {SearchTerm}", search);
                    query = query.Where(e => e.Name.Contains(search));
                }

                var products = query.ToList();

                _logger.LogInformation("Consulta de produtos concluída com {Count} resultados.", products.Count);
                return products;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar produtos.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar os produtos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }

        public async Task<Result<bool>> InsertProductAsync(CreateProductRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando inserção do produto.");

                var product = new Product(request);

                await _productRepository.InsertAsync(product);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Produto inserido com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir o produto.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao cadastrar produto",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }

        public async Task<Result<bool>> UpdateProductAsync(Guid id, UpdateProductRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando atualização do produto com ID: {ProductId}", id);

                var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);

                if (product is null)
                {
                    _logger.LogWarning("Produto com ID: {ProductId} não encontrado.", id);
                    return new ErrorResponse()
                    {
                        Code = "ProductNotFound",
                        Message = "Falha ao buscar os produtos",
                        Description = $"Produto com ID: {id} não encontrado.",
                    };
                    
                }

                product.Update(request);
                _productRepository.Update(product);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Produto com ID: {ProductId} atualizado com sucesso.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o produto com ID: {ProductId}", id);
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao atualizar produto",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public async Task<Result<bool>> UpdateProductQuantityAsync(List<CreateItemsSaleRequest> requests) {
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
                    if (cd != null) {
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

        public async Task<Result<bool>> DeleteProductAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Iniciando deleção do produto com ID: {ProductId}", id);

                var product = _productRepository.Query().FirstOrDefault(x => x.Id == id);

                if (product is null)
                {
                    _logger.LogWarning("Produto com ID: {ProductId} não encontrado.", id);
                    return new ErrorResponse()
                    {
                        Code = "ProductNotFound",
                        Message = "Falha ao buscar os produtos",
                        Description = $"Produto com ID: {id} não encontrado.",
                    };
                }

                _productRepository.Remove(product);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Produto com ID: {ProductId} deletado com sucesso.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar o produto com ID: {ProductId}", id);
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao atualizar produto",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
    }
}
