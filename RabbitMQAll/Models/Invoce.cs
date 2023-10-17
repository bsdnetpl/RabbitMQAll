using Newtonsoft.Json;

namespace RabbitMQAll.Models
{
    public class Invoce
    {
        public Guid Id { get; set; }
        public string Number { get; set; }
        public string nipBayer { get; set; }
        public DateTime dateTimeCreate { get; set; }
        [JsonIgnore]
        public  FieldInvoce? fieldInvoce { get; set; }
       
    }
}
