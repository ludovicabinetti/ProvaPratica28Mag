using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GestioneClientiOrdini.Core.Entities;

namespace GestioneClientiOrdini.Library.WCF
{
    // definizione del Data contract nella entity Customer del Core

    [ServiceContract] // definizione del service contract = insieme delle funzionalità che il servizio offre
                      // (che riguardano solo l'entità Customer)
    public interface ICustomerService
    {
        #region Customer CRUD services
        [OperationContract]
        List<Customer> GetCustomers();

        [OperationContract]
        Customer GetCustomerById(int id);

        [OperationContract]
        Customer GetCustomerByCode(string code);

        [OperationContract]
        bool AddNewCustomer(Customer newCustomer);

        [OperationContract]
        bool EditCustomer(Customer editedCustomer);

        [OperationContract]
        bool DeleteCustomerById(int id);
        #endregion

        #region Customer extra services
        [OperationContract]
        List<Order> FetchCustomerOrders(int id);
        #endregion

    }
}
