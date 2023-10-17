using RabbitMQAll.DB;
using RabbitMQAll.Models;

namespace RabbitMQAll.Service
{
    public class InvoceService : IInvoceService
    {
        private readonly Dbconnect _dbconnect;

        public InvoceService(Dbconnect dbconnect)
        {
            _dbconnect = dbconnect;
        }
        public async Task<Invoce> AddInvoce(Invoce invoce)
        {
            _dbconnect.invoces.Add(invoce);
            await _dbconnect.SaveChangesAsync();
            return invoce;
        }
    }
}
