namespace wt_lab3_3mvc_borisevich.Models;

public class Car
{
    public int Id { get; set; }
    public string Brand { get; set; } = "";
    public string Model { get; set; } = "";
    public int Year { get; set; }
    public decimal PricePerDay { get; set; }
    public bool IsAvailable { get; set; }
}