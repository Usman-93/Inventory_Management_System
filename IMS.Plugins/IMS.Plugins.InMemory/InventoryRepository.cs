using IMS.CoreBusiness;
using IMS.UseCases.PluginInterfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace IMS.Plugins.InMemory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<Inventory> _inventories;

        public InventoryRepository()
        {
            _inventories = new List<Inventory>()
            {
                new Inventory { InventoryId = 1, InventoryName = "Bike Seat", Quantity = 10, Price = 2 },
                new Inventory { InventoryId = 2, InventoryName = "Bike Body", Quantity = 10, Price = 15 },
                new Inventory { InventoryId = 3, InventoryName = "Bike Wheels", Quantity = 20, Price = 8 },
                new Inventory { InventoryId = 4, InventoryName = "Bike Pedels", Quantity = 20, Price = 1 },
            };
        }

        public async Task<IEnumerable<Inventory>> GetInventoriesByNameAsync(string inventoryName)
        {
            if (String.IsNullOrEmpty(inventoryName))
            {
                // Return all inventories
                return await Task.FromResult<IEnumerable<Inventory>>(_inventories);

            }
            return await Task.FromResult<IEnumerable<Inventory>>(
                _inventories.Where(i => i.InventoryName.Contains(inventoryName, StringComparison.OrdinalIgnoreCase))
            );
        }
    }
}
