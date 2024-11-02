using API.DTOs;
using API.Interfaces;
using API.Models;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ItemsController : ControllerBase
{
    private readonly IItemsRepository _itemsRepository;

    public ItemsController(IItemsRepository itemsRepository)
    {
        _itemsRepository = itemsRepository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Item>>> GetItems()
    {
        var items = await _itemsRepository.GetItemsAsync();
        return Ok(items);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Item>> GetItem(int id)
    {
        var item = await _itemsRepository.GetItemByIdAsync(id);
        return item is null ? NotFound() : Ok(item);
    }

    [HttpGet("upc/{upc}")]
    public async Task<ActionResult<IEnumerable<Item>>> GetItemsByUPC(string upc)
    {
        var items = await _itemsRepository.GetItemsByUPCAsync(upc);
        return items.Any() ? Ok(items) : NotFound();
    }

    [HttpGet("count")]
    public async Task<ActionResult<IEnumerable<ItemsCountDTO>>> GetItemsCount()
    {
        var itemsCount = await _itemsRepository.GetItemsCountAsync();
        return Ok(itemsCount);
    }

    [HttpPost]
    public async Task<ActionResult<Item>> AddItem(ItemDto item)
    {
        Item itemToCreate = new()
        {
            Name = item.Name,
            Description = item.Description,
            UPC = item.UPC
        };

        await _itemsRepository.AddItemAsync(itemToCreate);
        await _itemsRepository.Complete();
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<Item>> UpdateItem(int id, ItemDto item)
    {
        var existingItem = await _itemsRepository.GetItemByIdAsync(id);
        if (existingItem is null) return NotFound();

        existingItem.Name = item.Name;
        existingItem.Description = item.Description;
        existingItem.UPC = item.UPC;

        _itemsRepository.UpdateItem(existingItem);
        await _itemsRepository.Complete();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteItem(int id)
    {
        var item = await _itemsRepository.GetItemByIdAsync(id);
        if (item is null) return NotFound();

        _itemsRepository.DeleteItem(item);
        await _itemsRepository.Complete();
        return NoContent();
    }
}