using Echeinbetter.Database;
using Echeinbetter.Dtos;
using Echeinbetter.Models;
using Microsoft.AspNetCore.Mvc;

namespace Echeinbetter.Controllers
{
    public class InventoryController
    {
        [HttpGet("/api/inventory")]
        public static IResult GetAll(HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dalInventory = new DAL<Inventory>(context);
                var inventory = dalInventory.Select();

                return Results.Ok(inventory);
            }
            catch (Exception ex)
            {
                return Results.Problem("Error fetching data: " + ex.Message);
            }
        }

        [HttpGet("/api/inventory/{id}")]
        public static IResult GetById(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dalInventory = new DAL<Inventory>(context);
                var inventory = dalInventory.SelectWhere(e => e.Id == id);

                if (inventory == null)
                    return Results.NotFound(new { message = $"Inventory with ID {id} not found" });

                return Results.Ok(inventory);
            }
            catch (Exception ex)
            {
                return Results.Problem("Error fetching data: " + ex.Message);
            }
        }

        [HttpPost("/api/inventory")]
        public static IResult Create(CreateInventoryDto dto, HttpContext http)
        {
            try
            {
                var newInventory = new Inventory
                {
                    Category = dto.Category,
                    Product = dto.Product,
                    Batch = dto.Batch,
                    Quad = dto.Quad,
                    BarCode = dto.BarCode,
                    Note = dto.Note ?? string.Empty
                };

                var context = new EngenhariasSenacContext();
                var dalInventory = new DAL<Inventory>(context);
                dalInventory.Insert(newInventory);

                return Results.Created($"/api/inventory/{newInventory.Id}", newInventory);
            }
            catch (Exception ex)
            {
                return Results.Problem("Error creating inventory: " + ex.Message);
            }
        }

        [HttpPut("/api/inventory/{id}")]
        public static IResult Update(int id, UpdateInventoryDto dto, HttpContext http)
        {
            try
            {
                if (id != dto.Id)
                    return Results.BadRequest(new { message = "URL ID does not match request body ID" });

                var context = new EngenhariasSenacContext();
                var dalInventory = new DAL<Inventory>(context);
                var existingInventory = dalInventory.SelectWhere(e => e.Id == id);

                if (existingInventory == null)
                    return Results.NotFound(new { message = $"Inventory with ID {id} not found" });

                existingInventory.Category = dto.Category;
                existingInventory.Product = dto.Product;
                existingInventory.Batch = dto.Batch;
                existingInventory.Quad = dto.Quad;
                existingInventory.BarCode = dto.BarCode;
                existingInventory.Note = dto.Note ?? string.Empty;

                dalInventory.Update(existingInventory);

                return Results.Ok(new { message = "Inventory updated successfully", data = existingInventory });
            }
            catch (Exception ex)
            {
                return Results.Problem("Error updating inventory: " + ex.Message);
            }
        }

        [HttpDelete("/api/inventory/{id}")]
        public static IResult Delete(int id, HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dalInventory = new DAL<Inventory>(context);
                var existingInventory = dalInventory.SelectWhere(e => e.Id == id);

                if (existingInventory == null)
                    return Results.NotFound(new { message = $"Inventory with ID {id} not found" });

                dalInventory.Delete(existingInventory);

                return Results.Ok(new { message = $"Inventory with ID {id} deleted successfully" });
            }
            catch (Exception ex)
            {
                return Results.Problem("Error deleting inventory: " + ex.Message);
            }
        }

        [HttpGet("/api/inventory/data")]
        public static IResult GetData(HttpContext http)
        {
            try
            {
                var context = new EngenhariasSenacContext();
                var dalInventory = new DAL<Inventory>(context);
                var inventory = dalInventory.Select();

                return Results.Ok(inventory);
            }
            catch (Exception ex)
            {
                return Results.Problem("Error fetching data: " + ex.Message);
            }
        }
    }
}

