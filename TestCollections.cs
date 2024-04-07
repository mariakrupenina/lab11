using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using library_for_lab10;

namespace lab11
{
    public class TestCollections
    {
        HandTool first, middle, last;

        Queue<HandTool> handToolQueue = new Queue<HandTool>();
        Queue<string> stringQueue = new Queue<string>();
        HashSet<Tool> toolHashSet = new HashSet<Tool>();
        HashSet<string> stringHashSet = new HashSet<string>();

        
        public TestCollections(int numberOfElements)
        {
            int count = 0; // Счетчик добавленных элементов

            while (count < numberOfElements)
            {
                try
                {
                    HandTool handTool = new HandTool();
                    handTool.RandomInit();

                    string toolString = handTool.ToString(); //строковое представление базового класса

                    //Проверяем наличие рандомного элемента в уникальных коллекциях
                    if (!toolHashSet.Contains(handTool) && !stringHashSet.Contains(toolString))
                    {
                        toolHashSet.Add(handTool.GetBase);
                        stringHashSet.Add(toolString);
                        stringQueue.Enqueue(toolString);
                        handToolQueue.Enqueue(handTool);

                        count++; //Увеличиваетя счетчик только если элемент был успешно добавлен
                    }

                    if (count == 1)
                        first = (HandTool)handTool;
                    if (count == numberOfElements / 2)
                        middle = (HandTool)handTool;
                    if (count == numberOfElements - 1)
                        last = (HandTool)handTool;
                }
                catch
                {
     //
                }
            }
        }


        // Метод для вывода элементов очереди на экран
        public void PrintToolQueue()
        {
            Console.WriteLine("Элементы в очереди:");
            foreach (var tool in handToolQueue)
            {
                Console.WriteLine(tool);
            }

            Console.WriteLine(handToolQueue.Count());
        }

        // Метод для вывода элементов хеш-множества на экран
        public void PrintToolHashSet()
        {
            Console.WriteLine("Элементы в хеш-множестве (HashSet<Tool>):");
            foreach (var tool in toolHashSet)
            {
                Console.WriteLine(tool);
            }
            Console.WriteLine($"Количество инструментов: {toolHashSet.Count()}");
        }

        public int GetHandToolQueueCount()
        {
            return handToolQueue.Count;
        }

        public int GetStringQueueCount()
        {
            return stringQueue.Count;
        }

        public int GetToolHashSetCount()
        {
            return toolHashSet.Count;
        }

        public int GetStringHashSetCount()
        {
            return stringHashSet.Count;
        }

        public void MeasureTime()
        {
            MeasureSearchTime(first, "Первый");
            MeasureSearchTime(middle, "Средний");
            MeasureSearchTime(last, "Последний");
            MeasureSearchTime(new HandTool(), "Несуществующий");
        }

        private void MeasureSearchTime(HandTool tool, string description)
        {
            Console.WriteLine($"Поиск {description} элемента");

            Stopwatch sw = Stopwatch.StartNew();

            bool isFindInHandToolQueue = handToolQueue.Contains(tool);
            bool isFindInStringQueue = stringQueue.Contains(tool.ToString());
            bool isFindInToolHashSet = toolHashSet.Contains(tool.GetBase);
            bool isFindInStringHashSet = stringHashSet.Contains(tool.ToString());

            sw.Stop();

            PrintSearchResult(isFindInHandToolQueue, sw.ElapsedTicks);
            PrintSearchResult(isFindInStringQueue, sw.ElapsedTicks);
            PrintSearchResult(isFindInToolHashSet, sw.ElapsedTicks);
            PrintSearchResult(isFindInStringHashSet, sw.ElapsedTicks);
        }

        private void PrintSearchResult(bool isFound, long elapsedTicks)
        {
            if (isFound)
                Console.WriteLine($"Элемент найдён за {elapsedTicks}");
            else
                Console.WriteLine($"Элемент не найдён за {elapsedTicks}");
        }
    }
    }