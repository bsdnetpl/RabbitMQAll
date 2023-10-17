using System.Text.Json.Serialization;

namespace RabbitMQAll.Models
{
    public class FieldInvoce
    {
        public Guid id {  get; set; }
        public string nameValue { get; set; }
        public int vat {  get; set; }
        public double netto { get; set; }
        public double brutto { get; set; }
        public Guid idInvoce { get; set; }
        [JsonIgnore]
        public  Invoce? Invoce { get; set; }

    }
}