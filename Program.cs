using System;
using System.Collections.Generic;
using library_for_lab10;
using System.Collections;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace lab11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("                    ЗАДАНИЕ 1");
            //Создание универсальной коллекции для хранения объектов иерархии классов
            ArrayList tools = new ArrayList();

            //Добавление объектов в коллекцию
            for (int i = 0; i < 5; i++)
            {
                Tool t = new Tool();
                tools.Add(t);
                t.RandomInit();
            }
            for (int i = 0; i < 5; i++)
            {
                HandTool h = new HandTool();
                tools.Add(h);
                h.RandomInit();
            }
            for (int i = 0; i < 5; i++)
            {
                ElectricTool e = new ElectricTool();
                tools.Add(e);
                e.RandomInit();
            }

            tools.Sort();
            foreach (object t in tools)
            {
                Console.WriteLine(t.ToString());
            }

            Console.WriteLine(tools.Count);
            Console.WriteLine(tools.Capacity);

            //Поиск и удаление
            Console.WriteLine("Введите элемент для удаления");
            Tool find = new Tool();
            find.Init();
            int pos = tools.IndexOf(find);
            if (pos >= 0)
            {
                Console.WriteLine($"Удаляем {tools[pos]}");
                tools.RemoveAt(pos);
            }
            else
                Console.WriteLine("Невозможно удалить!нет такого инстурмента!");

            Console.WriteLine();

            //Запросы к коллекции
            //1.Количество элементов определенного вида
            Console.WriteLine("1. Количество элементов определенного вида");
            int handCount1 = 0;
            int toolCount1 = 0;
            int electricCount1 = 0;
            foreach (Tool item in tools)
            {
                if (item.GetType() == typeof(HandTool))
                {
                    handCount1++;
                }
                else if (item.GetType() == typeof(ElectricTool))
                {
                    electricCount1++;
                }
                else if (item.GetType() == typeof(Tool))
                {
                    //Исключаем HandTool и ElectricTool(они прописаны выше)
                    if (!(item is HandTool) && !(item is ElectricTool))
                    {
                        toolCount1++;
                    }
                }
            }
            Console.WriteLine($"Количество ручных инстурментов: {handCount1}");
            Console.WriteLine($"Количество иинструментов: {toolCount1}");
            Console.WriteLine($"Количество электрических иинструментов: {toolCount1}");

            Console.WriteLine();

            //2.Печать элементов определенного вида
            Console.WriteLine("2. Печать элементов определенного вида");
            Console.WriteLine("Ручные инструменты:");
            foreach (object obj in tools)
            {
                if (obj.GetType() == typeof(HandTool))
                {
                    Console.WriteLine(obj.ToString());
                }
            }
            Console.WriteLine();

            //Пример из 10лабы
            //3.Максимальное время работы аккумуляторного электрического инструмента
            Console.Write("3. Максимальное время работы аккумуляторного электрического инструмента: ");

            ElectricTool e3 = new ElectricTool("батарея", "железо", "аккумулятор", 5, 5);
            tools.Add(e3);

            double maxValue = 0;
            foreach (object item in tools)
            {
                if (item is ElectricTool)
                {
                    ElectricTool electricTool = (ElectricTool)item;
                    if (electricTool.PowerSource == "аккумулятор" && electricTool.BatteryTime > maxValue)
                    {
                        maxValue = electricTool.BatteryTime;
                    }
                }
            }

            if (maxValue > 0)
            {
                Console.WriteLine($"{maxValue} мин.");
            }

            else
            {
                Console.WriteLine("не определено, так как инструментов с такими условиями нет.");
            }

            Console.WriteLine();

            ////Перебор элементов коллекции с помощью foreach
            //Console.WriteLine("Все инструменты:");
            //foreach (object t4 in tools)
            //{
            //    t4.ToString();
            //}

            //Клонирование коллекции
            ArrayList cloned = (ArrayList)tools.Clone();
            //foreach (object t in cloned)
            //{
            //    Console.WriteLine(t.ToString());
            //}

            // Глубокое копирование коллекции tools
            //ArrayList cloned = DeepCopy(tools);
            //// Вывод клонированной коллекции для проверки
            //Console.WriteLine("Клонированная коллекция:");
            //foreach (object t in cloned)
            //{
            //    Console.WriteLine(t.ToString());
            //}


            //Сортировка коллекции и поиск элемента
            tools.Sort();
            Tool searchTool = new Tool();
            Console.WriteLine("ПОИСК ЭЛЕМЕНТА");
            searchTool.Init();
            //Находим индекс объекта в коллекции
            int index = tools.IndexOf(searchTool);

            if (index != -1)
            {
                Console.WriteLine($"Элемент найден по индексу: {index+1}");
            }
            else
            {
                Console.WriteLine("Элемент не найден.");
            }


            //Задание 2

            Console.WriteLine("                    ЗАДАНИЕ 2");

            LinkedList<Tool> tools2 = new LinkedList<Tool>();

            //Добавление объектов в коллекцию
            for (int i = 0; i < 5; i++)
            {
                Tool t = new Tool();
                t.RandomInit();
                tools2.AddFirst(new LinkedListNode<Tool>(t));

            }
            for (int i = 0; i < 5; i++)
            {
                HandTool h = new HandTool();
                tools2.AddFirst(h);
                h.RandomInit();
            }
            for (int i = 0; i < 5; i++)
            {
                ElectricTool e = new ElectricTool();
                tools2.AddLast(e);
                e.RandomInit();
            }
            //Вывод элементов списка
            foreach (Tool t in tools2)
            {
                Console.WriteLine(t.ToString()); 
            }

            Console.WriteLine($"Количество инструментов = {tools2.Count}");

            // Клонирование коллекции tools(глубокое не требуется, элементы хранятся по значению(не по ссылке))
            LinkedList<Tool> cloned2 = new LinkedList<Tool>(tools2);

            //Поиск и удаление
            Console.WriteLine("Введите элемент для удаления. Сначала найдём его.Введите элемент: ");
            Tool find2 = new Tool();
            find2.Init(); 
            if (tools2.Contains(find2))
                Console.WriteLine("Найден");
            else
                Console.WriteLine("Не найден");
            LinkedListNode<Tool> node = tools2.Find(find2);
            if (node != null)
            {
                Console.WriteLine($"Удаляем {node.Value}");
                tools.Remove(node);
            }

            Console.WriteLine();

            // Запросы к коллекции
            // 1. Количество элементов определенного вида в изначальном массиве (без удаления, если было)
            Console.WriteLine("1. Количество элементов определенного вида");
            int handCount2 = 0;
            int toolCount2 = 0;
            int electricCount2 = 0;

            foreach (Tool item in cloned2)
            {
                Type type = item.GetType();
                if (type == typeof(HandTool))
                {
                    handCount2++;
                }
                else if (item is ElectricTool)
                {
                    electricCount2++;
                }
                else if (item is Tool)
                {
                    toolCount2++;
                }
            }

            Console.WriteLine($"Количество ручных инструментов: {handCount2}");
            Console.WriteLine($"Количество инструментов: {toolCount2}");
            Console.WriteLine($"Количество электрических инструментов: {electricCount2}");

            Console.WriteLine();

            // 2. Печать элементов определенного вида
            Console.WriteLine("2. Печать элементов определенного вида");
            Console.WriteLine("Ручные инструменты:");
            foreach (Tool t2 in cloned2)
            {
                Type type = t2.GetType();
                if (type == typeof(HandTool))
                {
                    Console.WriteLine(t2.ToString());
                }
            }

            //3.Максимальное время работы аккумуляторного электрического инструмента
            Console.Write("3. Максимальное время работы аккумуляторного электрического инструмента: ");

            ElectricTool toolAdd = new ElectricTool("батарея", "железо", "аккумулятор", 45, 5);
            cloned2.AddLast(toolAdd);
            double maxValue2 = 0;
            foreach (Tool item in cloned2)
            {
                if (item is ElectricTool electricTool && electricTool.PowerSource == "аккумулятор" && electricTool.BatteryTime >= maxValue2)
                {
                    maxValue2 = electricTool.BatteryTime;
                }
            }
            if (maxValue2 != 0)
                Console.WriteLine($"{maxValue2} мин.");
            else
                Console.WriteLine("Не определена, так как инструментов с такими условиями нет");


            Console.WriteLine();
            //Перебор элементов коллекции с помощью foreach
            //Console.WriteLine("Все инструменты:");
            //foreach (Tool t4 in tools2)
            //{
            //    t4.Print();
            //}


            //Сортировка списка
            // Копируем элементы из LinkedList<Tool> в List<Tool>
            List<Tool> tempList = new List<Tool>(tools2);
            tempList.Sort();
            //Обновление элементов в исходной LinkedList<Tool>, отсортированными элементами из List<Tool>
            var currentNode = tools2.First; //инициализируется как первый элемент в tools2 "текущая"
            foreach (var item in tempList)
            {
                currentNode.Value = item;
                currentNode = currentNode.Next;
            }

            Console.WriteLine("Отсортированная коллекция:");
            foreach (var item in tools2)
            {
                Console.WriteLine(item.ToString());
            }


            //Поиск в отсортированном листе(в базовом классе переопределены хеш и иквалс)
            Tool find3 = new Tool();
            find3.Init();
            if (cloned2.Contains(find3))
                Console.WriteLine("Найден");
            else
            {
                Console.WriteLine("Не найден");
            }

            Console.WriteLine("                    ЗАДАНИЕ 3");
            int numberOfElements = 1000;
            TestCollections collections = new TestCollections(numberOfElements);
            Console.WriteLine($"Количество элементов в handToolQueue: {collections.GetHandToolQueueCount()}");
            Console.WriteLine($"Количество элементов в stringQueue: {collections.GetStringQueueCount()}");
            Console.WriteLine($"Количество элементов в toolHashSet: {collections.GetToolHashSetCount()}");
            Console.WriteLine($"Количество элементов в stringHashSet: {collections.GetStringHashSetCount()}");

            if (collections.GetHandToolQueueCount() == collections.GetStringQueueCount() && collections.GetStringQueueCount() == collections.GetToolHashSetCount() && collections.GetToolHashSetCount() == collections.GetStringHashSetCount())
                Console.WriteLine($"Ура! Коллекции уникальны и в каждой {collections.GetHandToolQueueCount()} элементов");
            //// Вывод элементов коллекций
            //testCollections.PrintToolQueue();
            //testCollections.PrintToolHashSet();

            Console.WriteLine("Измерение времени коллекций:");
            TestCollections collection = new TestCollections(1000);
            collection.MeasureTime();
        }
    }
}
