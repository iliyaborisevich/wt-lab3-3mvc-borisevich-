using wt_lab3_3mvc_borisevich.Models;

namespace wt_lab3_3mvc_borisevich.Views;

public class CarView
{
    public void ShowCars(List<Car> cars)
    {
        Console.WriteLine("* СПИСОК АВТОМОБИЛЕЙ *");
        if (cars.Count == 0)
        {
            Console.WriteLine("Список пуст.");
            return;
        }

        foreach (var car in cars)
        {
            Console.WriteLine($"{car.Id}. {car.Brand} {car.Model} | {car.Year} | {car.PricePerDay} BYN | Доступен: {(car.IsAvailable ? "да" : "нет")}");
        }
    }

    public void ShowCar(Car car)
    {
        Console.WriteLine("$$$ АВТОМОБИЛЬ $$$");
        Console.WriteLine($"ID: {car.Id}");
        Console.WriteLine($"Марка: {car.Brand}");
        Console.WriteLine($"Модель: {car.Model}");
        Console.WriteLine($"Год: {car.Year}");
        Console.WriteLine($"Цена за день: {car.PricePerDay} BYN");
        Console.WriteLine($"Доступен: {(car.IsAvailable ? "да" : "нет")}");
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }
}