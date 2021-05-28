using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneClientiOrdini.Core.Entities;
using GestioneClientiOrdini.Core.Interfaces;

namespace GestioneClientiOrdini.Core.BusinessLayer
{
    // Business layer che usa le Repository Interfaces
    public class ServiceBL : IServiceBL
    {
        private readonly ICustomer _customerRepos;
        private readonly IOrder _orderRepos;

        #region ServiceBL ctors
        public ServiceBL(ICustomer customerRepos) : this(customerRepos, null) { }

        public ServiceBL(IOrder orderRepos) : this(null, orderRepos) { }

        public ServiceBL(ICustomer customerRepos, IOrder orderRepos)
        {
            _customerRepos = customerRepos;
            _orderRepos = orderRepos;
        }
        #endregion

        #region Customer CRUD
        public IEnumerable<Customer> FetchCustomers(Func<Customer, bool> filter = null)
        {
            return _customerRepos.Fetch();
        }

        public Customer GetCustomerById(int id)
        {
            return _customerRepos.GetById(id);
        }

        public Customer GetCustomerByCode(string code)
        {
            return _customerRepos.GetByCode(code);
        }

        public bool AddNewCustomer(Customer newCustomer)
        {
            return _customerRepos.Add(newCustomer);
        }

        public bool UpdateCustomer(Customer editedCustomer)
        {
            return _customerRepos.Update(editedCustomer);
        }

        public bool DeleteCustomer(Customer customerToDelete)
        {
            return _customerRepos.Delete(customerToDelete);
        }
        #endregion

        #region Order CRUD
        public IEnumerable<Order> FetchOrders(Func<Order, bool> filter = null)
        {
            return _orderRepos.Fetch();
        }
        public Order GetOrderById(int id)
        {
            return _orderRepos.GetById(id);
        }

        public Order GetOrderByCode(string code)
        {
            return _orderRepos.GetByCode(code);
        }

        public bool AddNewOrder(Order newOrder)
        {
            return _orderRepos.Add(newOrder);
        }
        public bool UpdateOrder(Order editedOrder)
        {
            return _orderRepos.Update(editedOrder);
        }

        public bool DeleteOrder(Order orderToDelete)
        {
            return _orderRepos.Delete(orderToDelete);
        }
        #endregion

        #region Customer
        public IEnumerable<Order> FetchOrdersByCustomer(int id)
        {
            return _customerRepos.FetchCustomerOrders(id);
        }
        #endregion

        #region Order

        public bool PlaceOrder(int customerId, string productCode, decimal amount)
        {
            return _orderRepos.Add(new Order
            {
                Date = DateTime.Now,
                // Code = null, // di default
                ProductCode = productCode,
                Total = amount,
                CustomerId = customerId,
                // Cancelled = false // è false di default
            });
        }

        public bool CancelOrder(int orderId)
        {
            // usando l'apposita repository, recupero tutti gli ordini
            // uso linq per recuperare l'elemento con quell'id
            var orderToDelete = _orderRepos.Fetch().FirstOrDefault(o => o.Id == orderId);

            if (orderToDelete != null) // se la ricerca ha prodotto risultati
            {
                orderToDelete.Cancelled = true; // annullo l'ordine modificando il flag

                return _orderRepos.Delete(orderToDelete);
            }

            return false; // restituisco falso se qualcosa è andato storto
                          // (es. la ricerca non ha prodotto risultati)
        }

        #endregion
    }
}
