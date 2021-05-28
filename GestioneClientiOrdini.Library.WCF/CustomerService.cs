using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using GestioneClientiOrdini.Core.BusinessLayer;
using GestioneClientiOrdini.Core.EF.Repositories;
using GestioneClientiOrdini.Core.Entities;
using GestioneClientiOrdini.Core.Interfaces;

namespace GestioneClientiOrdini.Library.WCF
{
    // implementazione del servizio
    public class CustomerService : ICustomerService
    {

        IServiceBL bl; // il servizio comunica con il Business Layer

        #region Ctors
        public CustomerService()
        {
            // definisco la repository da usare
            bl = new ServiceBL(new EFCustomerRepository());
        }
        #endregion

        #region Customer CRUD services
        public List<Customer> GetCustomers()
        {
            try
            {
                return bl.FetchCustomers().ToList();
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituita un valore nullo
            }
        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                return bl.GetCustomerById(id);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }

        public Customer GetCustomerByCode(string code)
        {
            try
            {
                return bl.GetCustomerByCode(code);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }

        public bool AddNewCustomer(Customer newCustomer)
        {
            try
            {
                if (newCustomer != null) // validazione del parametro di input
                    return bl.AddNewCustomer(newCustomer);
                else
                    return false;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }
        public bool EditCustomer(Customer editedCustomer)
        {
            try
            {
                if (editedCustomer != null) // validazione del parametro di input
                    return bl.UpdateCustomer(editedCustomer);
                else
                    return false;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }

        public bool DeleteCustomerById(int id)
        {
            try
            {
                // recupero il cliente con l'id specificato
                var customerToDelete = bl.GetCustomerById(id);

                if (customerToDelete != null)
                    // se il cliente è stato trovato lo cancello
                    return bl.DeleteCustomer(customerToDelete);
                else
                    // altrimenti restituisco false
                    return false;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }
        #endregion

        #region Customer extra services
        public List<Order> FetchCustomerOrders(int id)
        {
            try
            {
                return bl.FetchOrdersByCustomer(id).ToList();
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituita un valore nullo
            }
        }
        #endregion

    }
}
