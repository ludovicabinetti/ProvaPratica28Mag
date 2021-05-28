using System;
using System.Collections.Generic;
using System.Text;

namespace GestioneClientiOrdini.Core.Interfaces
{
    // interfaccia generica di tutte le repository del modello
    public interface IRepository<TEntity>
    {
        List<TEntity> Fetch();
        TEntity GetById(int id);
        TEntity GetByCode(string code);
        bool Add(TEntity item);
        bool Update(TEntity item);
        bool Delete(TEntity item);
    }
}
