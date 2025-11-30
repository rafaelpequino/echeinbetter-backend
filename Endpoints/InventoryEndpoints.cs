using Echeinbetter.Controllers;

namespace Echeinbetter.Endpoints;

public static class InventoryEndpoints
{
    public static void AddInventoryEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/api/inventory")
            .WithName("Inventory");

        group.MapPost("/", InventoryController.Create)
            .WithName("CreateInventory")
            .Produces(201)
            .Produces(400)
            .Produces(500);

        group.MapPost("/search", InventoryController.Search)
            .WithName("SearchInventory")
            .Produces(200)
            .Produces(500);

        group.MapGet("/{id}", InventoryController.GetById)
            .WithName("GetInventoryById")
            .Produces(200)
            .Produces(404)
            .Produces(500);

        group.MapPut("/{id}", InventoryController.Update)
            .WithName("UpdateInventory")
            .Produces(200)
            .Produces(400)
            .Produces(404)
            .Produces(500);

        group.MapDelete("/{id}", InventoryController.Delete)
            .WithName("DeleteInventory")
            .Produces(200)
            .Produces(404)
            .Produces(500);
    }
}

