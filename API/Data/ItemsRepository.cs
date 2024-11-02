using API.DTOs;
using API.Interfaces;
using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data;

public class ItemsRepository : IItemsRepository
{
    private readonly DataContext _context;

    public ItemsRepository(DataContext context)
    {
        _context = context;
    }

    public async Task AddItemAsync(Item item)
    {
        await _context.Items.AddAsync(item);
    }

    public async Task<bool> Complete()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public void DeleteItem(Item item)
    {
        _context.Remove(item);
    }

    public Task<Item?> GetItemByIdAsync(int id)
    {
        return _context.Items.SingleOrDefaultAsync(item => item.Id == id);
    }

    public async Task<IEnumerable<Item>> GetItemsAsync()
    {
        return await _context.Items.ToListAsync();
    }

    public async Task<IEnumerable<Item>> GetItemsByUPCAsync(string upc)
    {
        return await _context.Items.Where(item => item.UPC == upc).ToListAsync();
    }

    public async Task<IEnumerable<ItemsCountDTO>> GetItemsCountAsync()
    {
        var productCounts = await _context.Items
        .GroupBy(items => items.UPC)
        .Select(g => new ItemsCountDTO
        {
            UPC = g.Key,
            Count = g.Count()
        })
        .ToListAsync();

        return productCounts;
    }

    public void UpdateItem(Item item)
    {
        _context.Entry(item).State = EntityState.Modified;
    }
}