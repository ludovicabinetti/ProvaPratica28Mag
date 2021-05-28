using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneClientiOrdini.Core.Entities
{
    [DataContract]
    public class Order
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public DateTime Date { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string ProductCode { get; set; }
        [DataMember]
        public decimal Total { get; set; }
        [DataMember]
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        [DataMember]
        public bool Cancelled { get; set; } // flag nel caso in cui un ordine venisse annullato

        public override string ToString()
        {
            return $"[Order {Code}] placed in {Date} by customer {CustomerId}. Amount due: {Total}";
        }

    }
}
