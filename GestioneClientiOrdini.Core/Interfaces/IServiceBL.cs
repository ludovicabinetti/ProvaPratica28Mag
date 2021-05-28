using System;
using System.Collections.Generic;
using System.Text;
using GestioneClientiOrdini.Core.Entities;

namespace GestioneClientiOrdini.Core.Interfaces
{
    // interfaccia che definisce il contratto del BL
    public interface IServiceBL
    {
        #region Customer CRUD

        // recupero dei clienti con eventuale applicazione di un filtro
        IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null);
       
        Customer GetCustomerById(int id);
        
        Customer GetCustomerByCode(string code);
        
        bool AddNewCustomer(Customer newCustomer);
        
        bool UpdateCustomer(Customer editedCustomer);
        
        bool DeleteCustomer(Customer customerToDelete);
        #endregion

        #region Order CRUD
        // recupero degli ordini con eventuale applicazione di un filtro
        IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null);

        Order GetOrderById(int id);

        Order GetOrderByCode(string code);

        bool AddNewOrder(Order newOrder);

        bool UpdateOrder(Order editedOrder);

        bool DeleteOrder(Order orderToDelete);
        #endregion

        #region Customer
        // restituzione dello storico degli ordini di un utente
        IEnumerable<Order> FetchOrdersByCustomer(int id);
        #endregion

        #region Order
        bool PlaceOrder(int customerId, string productCode, decimal amount);
        bool CancelOrder(int orderId);
        #endregion

    }
}
