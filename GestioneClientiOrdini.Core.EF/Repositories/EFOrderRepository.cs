using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GestioneClientiOrdini.Core.Entities;
using GestioneClientiOrdini.Core.Interfaces;

namespace GestioneClientiOrdini.Core.EF.Repositories
{
    public class EFOrderRepository : IOrder
    {
        private readonly ServiceContext ctx;

        #region Ctors
        public EFOrderRepository() : this(new ServiceContext()) { }

        public EFOrderRepository(ServiceContext ctx)
        {
            this.ctx = ctx;
        }
        #endregion

        #region Order CRUD
        public List<Order> Fetch()
        {
            try
            {
                // recupero del DbSet (tabella) Orders e trasformazione in una lista
                return ctx.Orders.ToList();
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }
        public Order GetById(int id)
        {
            try
            {
                // dal DbSet/tabella Orders recupero l'elemento con l'id specificato
                return ctx.Orders.FirstOrDefault(c => c.Id == id);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }

        public Order GetByCode(string code)
        {
            try
            {
                // dal DbSet/tabella Orders recupero l'elemento con il code specificato
                return ctx.Orders.FirstOrDefault(c => c.Code == code);
            }
            catch (Exception)
            {
                return null; // nel caso in cui si verifichino errori, viene restituito un valore nullo
            }
        }

        public bool Add(Order order)
        {
            try
            {
                // inserisco un nuovo elemento nella tabella Orders
                ctx.Orders.Add(order);
                ctx.SaveChanges(); // salvo le modifiche effettuate al database

                return true;
            }
            catch (Exception ex)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }
        public bool Update(Order order)
        {
            try
            {
                ctx.Orders.Update(order); // aggiornamento dell'order nel DbSet/tabella
                ctx.SaveChanges(); // salvo le modifiche effettuate al database

                return true;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }

        public bool Delete(Order order)
        {
            try
            {
                ctx.Orders.Remove(order); // rimozione dell'order dal DbSet/tabella
                ctx.SaveChanges(); // salvo le modifiche effettuate al database

                return true;
            }
            catch (Exception)
            {
                return false; // nel caso in cui si verifichino errori, viene restituito false
            }
        }
        #endregion

    }
}
