using System;
using System.Collections.Generic;
using System.Text;
using GestioneClientiOrdini.Core.Entities;

namespace GestioneClientiOrdini.Core.Interfaces
{
    public interface ICustomer : IRepository<Customer>
    {
        IEnumerable<Order> FetchCustomerOrders(int id);
    }
}
