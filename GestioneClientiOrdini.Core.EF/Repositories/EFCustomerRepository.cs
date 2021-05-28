using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneClientiOrdini.Core.Entities;
using GestioneClientiOrdini.Core.Interfaces;

namespace GestioneClientiOrdini.Core.EF.Repositories
{
    public class EFCustomerRepository : ICustomer
    {
        private readonly ServiceContext ctx;

        #region Ctors
        public EFCustomerRepository() : this(new ServiceContext()) { }

        public EFCustomerRepository(ServiceContext ctx)
        {
            this.ctx = ctx;
        }
        #endregion

        #region Customer CRUD
        public List<Customer> Fetch()
        {
            try
            {
                // recupero del DbSet (tabella) Customers e trasformazione in una lista
                return ctx.Customers.ToList();
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }
        public Customer GetById(int id)
        {
            try
            {
                // dal DbSet/tabella Customers recupero l'elemento con l'id specificato
                return ctx.Customers.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }

        public Customer GetByCode(string code)
        {
            try
            {
                // dal DbSet/tabella Customers recupero l'elemento con il code specificato
                return ctx.Customers.FirstOrDefault(c => c.Code == code);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }

        public bool Add(Customer customer)
        {
            try
            {
                // inserisco un nuovo elemento nella tabella Customers
                ctx.Customers.Add(customer);
                ctx.SaveChanges(); // salvo le modifiche effettuate al database

                return true;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }
        public bool Update(Customer customer)
        {
            try
            {
                ctx.Customers.Update(customer); // aggiornamento del customer nel DbSet/tabella
                ctx.SaveChanges(); // salvo le modifiche effettuate al database

                return true;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }

        public bool Delete(Customer customer)
        {
            try
            {
                ctx.Customers.Remove(customer); // rimozione del customer dal DbSet/tabella
                ctx.SaveChanges(); // salvo le modifiche effettuate al database

                return true;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }
        #endregion

        #region Customer
        public IEnumerable<Order> FetchCustomerOrders(int customerId)
        {
            try
            {
                // dalla tabella Ordini recupero tutti gli ordini che hanno come CustomerId il customerId specificato
                return ctx.Orders.Where(o => o.CustomerId == customerId);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }
        #endregion
    }
}
