using Microsoft.Extensions.Logging;
using Teste.Interfaces.IRepositories.ICommon;
using Teste.Interfaces.IRepositories;
using Teste.Models.Requests;
using Teste.Models.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Test.Models.Responses;
using Test.Models.Responses.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.ReportingServices.Interfaces;

namespace Teste.UseCases
{
    public class CustomerUseCase
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICustomerRepository _CustomerRepository;
        private readonly ILogger<CustomerUseCase> _logger;

        public CustomerUseCase(ICustomerRepository CustomerRepository, IUnitOfWork unitOfWork, ILogger<CustomerUseCase> logger)
        {
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _CustomerRepository = CustomerRepository ?? throw new ArgumentNullException(nameof(CustomerRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        #region Read
        public Result<Customer> FindCustomerByName(string name)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de cliente.");

                var customer = _CustomerRepository.Query()
                    .FirstOrDefault(e => e.Name.Contains(name));

                if (customer == null)
                {
                    return new ErrorResponse()
                    {
                        Code = "CustomerNotFound",
                        Message = "Falha ao buscar o cliente",
                        Description = "Cliente não encontrado"
                    };
                }

                return customer;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar cliente.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar cliente",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public Result<List<ReportCustomerResponse>> FindReportCustomer(DateTime startDate = default, DateTime endDate = default, string search = null)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de cliente.");

                var query = _CustomerRepository.Query();

                if (!string.IsNullOrEmpty(search))
                {
                    query = query.Where(e => e.Name.Contains(search) || e.Email.Contains(search));
                }

                if (startDate.Date != default && endDate.Date != default)
                {
                    query = query.Where(e => e.CreatedAt.Value.Date >= startDate.Date && e.CreatedAt.Value.Date <= endDate.Date);
                }

                var data = query.Select(e => new ReportCustomerResponse(e, e.Sales
                            .Sum(sale => sale.ItemsSales.Sum(item => item.UnitPrice * item.Quantity))))
                    .ToList();

                _logger.LogInformation("Consulta de clientes concluída com {Count} resultados.", data.Count);

                return data;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar clientes.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar clientes",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }
        public Result<List<Customer>> FindAllCustomer(string search = null)
        {
            try
            {
                _logger.LogInformation("Iniciando consulta de cliente.");

                var query = _CustomerRepository.Query();

                if (!string.IsNullOrEmpty(search))
                {
                    _logger.LogInformation("Filtrando clientes com base na pesquisa: {SearchTerm}", search);
                    query = query.Where(e => e.Name.Contains(search) || e.Email.Contains(search));
                }

                var Customers = query.ToList();

                _logger.LogInformation("Consulta de clientes concluída com {Count} resultados.", Customers.Count);
                return Customers;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consultar clientes.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao buscar clientes",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }

        #endregion

        public Result<Guid?> InsertCustomer(CreateCustomerRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando inserção do cliente.");

                var customerExist = _CustomerRepository.Query()
                    .FirstOrDefault(e => e.Name == request.Name &&
                     e.Email == request.Email &&
                     e.PhoneNumber == request.PhoneNumber);

                if (customerExist != null){
                    return new ErrorResponse()
                    {
                        Code = "CustomerExist",
                        Message = "Falha ao cadastrar o cliente",
                        Description = "Cliente ja esta registrado no banco de dados",
                        Extension = customerExist.Id.ToString()
                    };
                }
                var customer = new Customer(request);

                _CustomerRepository.Insert(customer);
                _unitOfWork.SaveChange();

                _logger.LogInformation("Cliente inserido com sucesso.");
                return customer.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao inserir o cliente.");
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao cadastrar cliente",
                    Description = "Ocorreu um erro desconhecido"
                };
            }
        }

        public Result<bool> UpdateCustomer(Guid id, UpdateCustomerRequest request)
        {
            try
            {
                _logger.LogInformation("Iniciando atualização do cliente com ID: {CustomerId}", id);

                var Customer = _CustomerRepository.Query().FirstOrDefault(x => x.Id == id);

                if (Customer is null)
                {
                    _logger.LogWarning("Cliente com ID: {CustomerId} não encontrado.", id);
                    return new ErrorResponse()
                    {
                        Code = "CustomerNotFound",
                        Message = "Falha ao atualizar dados do cliente",
                        Description = $"Cliente com ID: {id} não encontrado."
                    };
                }

                Customer.Update(request);
                _CustomerRepository.Update(Customer);
                _unitOfWork.SaveChange();

                _logger.LogInformation("Cliente com ID: {CustomerId} atualizado com sucesso.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar o cliente com ID: {CustomerId}", id);
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao atualizar dados do cliente",
                    Description = $"Ocorreu um erro desconhecido."
                };
            }
        }

        public async Task<Result<bool>> DeleteCustomerAsync(Guid id)
        {
            try
            {
                _logger.LogInformation("Iniciando deleção do cliente com ID: {CustomerId}", id);

                var Customer = _CustomerRepository.Query()
                    .Include(e => e.Sales)
                    .FirstOrDefault(x => x.Id == id);

                if (Customer is null)
                {
                    _logger.LogWarning("Cliente com ID: {CustomerId} não encontrado.", id);
                    return new ErrorResponse()
                    {
                        Code = "CustomerNotFound",
                        Message = "Falha ao remover dados do cliente",
                        Description = $"Cliente com ID: {id} não encontrado."
                    };
                }
                if (Customer.Sales.Count() > 0)
                {
                    _logger.LogWarning("Cliente com ID: {CustomerId} tem venda registrada não pode ser deletado", id);
                    return new ErrorResponse()
                    {
                        Code = "CustomerWithRegisteredSale",
                        Message = "Falha ao remover dados do cliente",
                        Description = $"Cliente com ID: {id} tem venda registrada não pode ser deletado."
                    };
                }
                _CustomerRepository.Remove(Customer);
                await _unitOfWork.SaveChangeAsync();

                _logger.LogInformation("Cliente com ID: {CustomerId} deletado com sucesso.", id);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao deletar o cliente com ID: {CustomerId}", id);
                return new ErrorResponse()
                {
                    Code = "Unknow",
                    Message = "Falha ao remover dados do cliente",
                    Description = $"Ocorreu um erro desconhecido."
                };
            }
        }
    }
}
