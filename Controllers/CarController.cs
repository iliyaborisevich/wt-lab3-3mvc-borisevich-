using wt_lab3_3mvc_borisevich.Models;
using wt_lab3_3mvc_borisevich.Views;

namespace wt_lab3_3mvc_borisevich.Controllers;

public class CarController
{
    private readonly List<Car> cars;
    private readonly CarView view;

    public CarController()
    {
        cars = new List<Car>
        {
            new Car { Id = 1, Brand = "Toyota", Model = "Camry", Year = 2022, PricePerDay = 75, IsAvailable = true },
            new Car { Id = 2, Brand = "BMW", Model = "X5", Year = 2021, PricePerDay = 150, IsAvailable = false },
            new Car { Id = 3, Brand = "Kia", Model = "Rio", Year = 2020, PricePerDay = 45, IsAvailable = false }
        };
        view = new CarView();
    }

    public void Index()
    {
        view.ShowCars(cars);
    }

    public void Show(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            view.ShowMessage("Автомобиль не найден.");
            return;
        }
        view.ShowCar(car);
    }

    public void Add(Car car)
    {
        cars.Add(car);
        view.ShowMessage("Автомобиль успешно добавлен.");
    }

    public void Delete(int id)
    {
        var car = cars.FirstOrDefault(c => c.Id == id);
        if (car == null)
        {
            view.ShowMessage("Автомобиль не найден.");
            return;
        }
        cars.Remove(car);
        view.ShowMessage("Автомобиль успешно удалён.");
    }

    // ДОПОЛНИТЕЛЬНАЯ ОПЕРАЦИЯ: фильтр по доступности
    public void FilterAvailable()
    {
        var available = cars.Where(c => c.IsAvailable).ToList();
        if (available.Count == 0)
        {
            view.ShowMessage("Нет доступных автомобилей.");
            return;
        }
        view.ShowCars(available);
    }

    public void Run()
    {
        while (true)
        {
            Console.WriteLine();
            Console.WriteLine("=== МЕНЮ ===");
            Console.WriteLine("1. Показать все автомобили");
            Console.WriteLine("2. Найти автомобиль по ID");
            Console.WriteLine("3. Добавить автомобиль");
            Console.WriteLine("4. Удалить автомобиль");
            Console.WriteLine("5. Показать только доступные (доп. операция)");
            Console.WriteLine("0. Выход");
            Console.Write("Выберите действие: ");

            var command = Console.ReadLine();

            switch (command)
            {
                case "1": Index(); break;
                case "2": ShowCarByUserInput(); break;
                case "3": AddCarByUserInput(); break;
                case "4": DeleteCarByUserInput(); break;
                case "5": FilterAvailable(); break;
                case "0": return;
                default: view.ShowMessage("Неизвестная команда."); break;
            }
        }
    }

    private void ShowCarByUserInput()
    {
        Console.Write("Введите ID автомобиля: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Show(id);
    }

    private void AddCarByUserInput()
    {
        Console.Write("Введите ID: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }

        Console.Write("Введите марку: ");
        string brand = Console.ReadLine() ?? "";

        Console.Write("Введите модель: ");
        string model = Console.ReadLine() ?? "";

        Console.Write("Введите год: ");
        if (!int.TryParse(Console.ReadLine(), out int year))
        {
            view.ShowMessage("Некорректный год.");
            return;
        }

        Console.Write("Введите цену за день: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal price))
        {
            view.ShowMessage("Некорректная цена.");
            return;
        }

        Console.Write("Доступен (1 - да, 0 - нет): ");
        bool isAvailable = Console.ReadLine() == "1";

        Add(new Car
        {
            Id = id,
            Brand = brand,
            Model = model,
            Year = year,
            PricePerDay = price,
            IsAvailable = isAvailable
        });
    }

    private void DeleteCarByUserInput()
    {
        Console.Write("Введите ID для удаления: ");
        if (!int.TryParse(Console.ReadLine(), out int id))
        {
            view.ShowMessage("Некорректный ID.");
            return;
        }
        Delete(id);
    }
}