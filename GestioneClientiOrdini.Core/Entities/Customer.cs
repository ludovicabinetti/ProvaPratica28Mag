using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace GestioneClientiOrdini.Core.Entities
{
    [DataContract] // definizione del contratto dati del servizio Wcf che gestisce l'anagrafica (CRUD) dei clienti
    public class Customer
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Code { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Surname { get; set; }
        public List<Order> Orders { get; set; }
    }
}
