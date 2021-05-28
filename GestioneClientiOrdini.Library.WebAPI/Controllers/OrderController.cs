using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GestioneClientiOrdini.Core.BusinessLayer;
using GestioneClientiOrdini.Core.EF.Repositories;
using GestioneClientiOrdini.Core.Entities;
using GestioneClientiOrdini.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GestioneClientiOrdini.Library.WebAPI.Controllers
{
    // controller per l'anagrafica delle entità di tipo Order
    [Route("[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IServiceBL bl; // il servizio comunica con il Business Layer

        #region Ctors
        public OrderController()
        {
            // definisco la repository da usare
            this.bl = new ServiceBL(new EFOrderRepository());
        }
        #endregion

        #region Order CRUD
        [HttpGet]
        public ActionResult Get()
        {
            var result = bl.FetchOrders();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            var order = bl.GetOrderById(id);

            if (order == null)
                return NotFound($"Order with ID = {id} is missing.");

            return Ok(order);
        }

        [HttpPost]
        public ActionResult Post([FromBody] Order newOrder)
        {
            if (newOrder == null)
                return BadRequest("Invalid Order data.");

            bl.AddNewOrder(newOrder);

            return Created($"/order/{newOrder.Id}", newOrder);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Order editedOrder)
        {
            if (editedOrder == null)
                return BadRequest("Invalid Order data.");

            if (id != editedOrder.Id)
                return BadRequest("Edited order ID doesn't match with an existing Order.");

            bl.UpdateOrder(editedOrder);

            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid Order ID.");

            var orderToDelete = bl.GetOrderById(id);

            if (orderToDelete != null)
                bl.DeleteOrder(orderToDelete);

            return Ok();
        }

        #endregion
    }
}
