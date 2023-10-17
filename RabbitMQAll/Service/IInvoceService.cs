using RabbitMQAll.Models;

namespace RabbitMQAll.Service
{
    public interface IInvoceService
    {
        Task<Invoce> AddInvoce(Invoce invoce);
    }
}