using System;
using PlantsLibrary;

namespace PlantsLibrary
{
    class Program
    {
        static void Main(string[] args)
        {
            var hashTable = new HashSet<Plant>(10, 0.72);
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Меню:");
                Console.WriteLine("1. Добавить 1 растение");
                Console.WriteLine("2. Добавить растения с помощью ДСЧ");
                Console.WriteLine("3. Показать хеш-таблицу");
                Console.WriteLine("4. Удалить растение");
                Console.WriteLine("5. Найти растение");
                Console.WriteLine("6. Выход");
                Console.Write("Выберите действие: ");

                if (!int.TryParse(Console.ReadLine(), out int choice))
                {
                    Console.WriteLine("Неверный ввод. Пожалуйста, введите число от 1 до 6.\n");
                    continue;
                }

                Console.WriteLine();

                try
                {
                    switch (choice)
                    {
                        case 1:
                            AddPlantMenu(hashTable);
                            break;
                        case 2:
                            AddRandomElements(hashTable);
                            break;
                        case 3:
                             hashTable.PrintTable();
                            break;
                        case 4:
                            RemovePlantMenu(hashTable);
                            break;
                        case 5:
                            SearchPlantMenu(hashTable);
                            break;
                        case 6:
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, введите число от 1 до 6.\n");
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Ошибка: {ex.Message}\n");
                }
            }
        }

        static void AddPlantMenu(HashSet<Plant> hashTable)
        {
            Console.WriteLine("Выберите тип растения для добавления:");
            Console.WriteLine("1. Растение");
            Console.WriteLine("2. Дерево");
            Console.WriteLine("3. Цветок");
            Console.WriteLine("4. Роза");
            Console.Write("Ваш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out int typeChoice) || typeChoice < 1 || typeChoice > 4)
            {
                Console.WriteLine("Неверный выбор типа растения.Пожалуйста, введите число от 1 до 4\n");
                return;
            }

            Plant plant;
            switch (typeChoice)
            {
                case 1:
                    plant = new Plant();
                    break;
                case 2:
                    plant = new Tree();
                    break;
                case 3:
                    plant = new Flower();
                    break;
                case 4:
                    plant = new Rose();
                    break;
                default:
                    throw new InvalidOperationException("Неверный выбор типа растения");
            }

            Console.WriteLine("1. Ввести вручную");
            Console.WriteLine("2. Сгенерировать случайно");
            Console.Write("Ваш выбор: ");

            if (!int.TryParse(Console.ReadLine(), out int initChoice) || (initChoice != 1 && initChoice != 2))
            {
                Console.WriteLine("Неверный выбор метода инициализации.\n");
                return;
            }

            if (initChoice == 1)
                plant.Init();
            else
                plant.RandomInit();

            if (hashTable.Add(plant))
                Console.WriteLine("Растение успешно добавлено.\n");
            else
                Console.WriteLine("Такое растение уже существует в таблице.\n");
        }

        static void SearchPlantMenu(HashSet<Plant> hashTable)
        {
            Console.Write("Введите ID растения для поиска: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный формат ID.\n");
                return;
            }

            var plant = hashTable.Find(id);
            if (plant != null)
            {
                Console.WriteLine("Растение найдено:");
                plant.Show();
            }
            else
            {
                Console.WriteLine("Растение не найдено.\n");
            }
        }

        static void RemovePlantMenu(HashSet<Plant> hashTable)
        {
            Console.Write("Введите ID растения для удаления: ");
            if (!int.TryParse(Console.ReadLine(), out int id))
            {
                Console.WriteLine("Неверный формат ID.\n");
                return;
            }

            if (hashTable.Remove(id))
                Console.WriteLine("Растение успешно удалено\n");
            else
                Console.WriteLine("Растение не найдено в таблице\n");
        }
        static void AddRandomElements(HashSet<Plant> hashTable)
        {
            Console.Write("Введите количество элементов для добавления: ");
            if (int.TryParse(Console.ReadLine(), out int count) && count > 0)
            {
                for (int i = 0; i < 10; i++)
                {
                    var plant = new Plant(); // или другой тип
                    plant.RandomInit();
                    hashTable.Add(plant);
                }
                Console.WriteLine($"Добавлено {count} случайных растений.\n");
            }
            else
            {
                Console.WriteLine("Некорректный ввод. Введите положительное число.\n");
            }
        }
    }
}