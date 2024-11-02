namespace API.Models;

public class Item
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public string? UPC { get; set; } //Universal Product Code
}