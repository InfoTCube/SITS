using API.Models;

namespace API.Interfaces;

public interface IItemsRepository
{
    Task<IEnumerable<Item>> GetItemsAsync();
    Task<Item?> GetItemByIdAsync(int id);
    Task AddItemAsync(Item item);
    void DeleteItem(Item item);
    void UpdateItem(Item item);
    Task<bool> Complete();
}