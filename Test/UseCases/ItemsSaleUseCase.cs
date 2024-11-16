using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teste.Interfaces.IRepositories.ICommon;
using Teste.Interfaces.IRepositories;
using Teste.Models.Entities;
using Teste.Models.Requests;
using Test.Models.Responses;
using Microsoft.EntityFrameworkCore;
using Test.Models.Responses.Common;

namespace Teste.UseCases
{
    public class ItemsSaleUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IItemsSaleRepository _itemsSaleRepository;
        private readonly ILogger<ItemsSaleUseCase> _logger;

        public ItemsSaleUseCase(IItemsSaleRepository itemsSaleRepository, IUnitOfWork unitOfWork, ILogger<ItemsSaleUseCase> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _itemsSaleRepository = itemsSaleRepository ?? throw new ArgumentNullException(nameof(itemsSaleRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
        public Result<(List<ItemsSalesResponse> itemsSales, double totalSold)> FindAllItemsSale(DateTime startDate = default, DateTime endDate = default, string search = null)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de vendas.");

                var query = _itemsSaleRepository.Query()
                    .Include(e => e.Product)
                    .Include(e => e.Sale)
                    .ThenInclude(e => e.Customer)
                    .AsQueryable();

                if (!string.IsNullOrEmpty(search))
                {
                    _logger.LogInformation("Filtrando itens vendidos com base na pesquisa: {SearchTerm}", search);
                    query = query.Where(e => e.Product.Name.Contains(search) || 
                                             e.Sale.Customer.Name.Contains(search));
                }

                if (startDate.Date != default && endDate.Date != default) { 
                     query = query.Where(e => e.CreatedAt.Value.Date >= startDate.Date && e.CreatedAt.Value.Date <= endDate.Date);
                }

                var totalSold = query.Sum(e => e.UnitPrice);

                var ItemsSales = query
                    .Select(e => new ItemsSalesResponse(e))
                    .ToList();

                _logger.LogInformation("Consulta de vendas concluída com {Count} resultados.", ItemsSales.Count);
                
                return (ItemsSales, totalSold);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar vendas.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar items vendidos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public Result<List<ReportSalesResponse>> FindReportItemsSale(DateTime startDate = default, DateTime endEnd = default, string search = default)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de vendas.");

                var query = _itemsSaleRepository.Query()
                    .Include(e => e.Product)
                    .Include(e => e.Sale)
                    .ThenInclude(e => e.Customer).AsQueryable();

                if (startDate.Date != default && endEnd.Date != default)
                {
                    _logger.LogInformation("Filtrando itens vendidos com base na pesquisa: {Data de inicio}", startDate);
                     query = query.Where(e => e.CreatedAt.Value.Date >= startDate.Date && e.CreatedAt.Value.Date <= endEnd.Date);
                }

                if (!string.IsNullOrEmpty(search)) {
                    query = query.Where(e => e.Product.Name.Contains(search) || e.Sale.Customer.Name.Contains(search) || e.Sale.Customer.Email.Contains(search));
                }
                var ItemsSales = query
                    .Select(e => new ReportSalesResponse(e))
                    .ToList();

                _logger.LogInformation("Consulta de vendas concluída com {Count} resultados.", ItemsSales.Count);
                return ItemsSales;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar vendas.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar items vendidos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public async Task<Result<bool>> InsertItemsSaleAsync(List<CreateItemsSaleRequest> requests)
        {
            try
            {

                _logger.LogInformation("Iniciando inserção do itens vendidos.");
                
                var itemsSales = new List<ItemsSale>();

                requests.ForEach(e => itemsSales.Add(new ItemsSale(e)));

                await _itemsSaleRepository.InsertAsync(itemsSales);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Itens vendidos inserido com sucesso.");
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir o itens vendidos.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao registrar items vendidos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public async Task<Result<bool>> DeleteItemsSaleAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Iniciando deleção do Venda com ID: {ItemsSaleId}", id);

                var ItemsSale = _itemsSaleRepository.Query().FirstOrDefault(x => x.Id == id);

                if (ItemsSale is null)
                {
                    _logger.LogWarning("Itens vendidos com ID: {ItemsSaleId} não encontrado.", id);
                    return new ErrorResponse()
                    {
                        Code = "ItemsSaleNotFound",
                        Message = "Falha ao remover items vendidos",
                        Description = "Ocorreu um erro desconhecido"
                    };
                }

                _itemsSaleRepository.Remove(ItemsSale);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Itens vendidos com ID: {ItemsSaleId} deletado com sucesso.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar os itens vendidos com ID: {ItemsSaleId}", id);
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao remover items vendidos",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
    }
}
