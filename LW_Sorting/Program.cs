using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;
using System;

namespace Сортировки
{
    class Program
    {
        static void Main()
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            List<string> Track_List = new List<string> { "Russia", "USA", "China", "Germany", "Ausrtia", "Australia", "Canada", "Iran", "Iraq", "France", "Italy", "Poland", "Ukraine", "Spain", "Great Britain", "Ireland", "Mexico", "Brazil", "Denmark", "Japan" };
            Track[] trackArray = new Track[20];
            Random random = new Random();
            int[] sortArray = null;
            int[] controlArray = { -7714, -7008, -6531, -3749, -2725, -2289, 1110, 4991, 7816, 8517 };
            int a = -1;
            int comparisons, swaps;
            TimeSpan elapsedTime;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите действие: ");
                Console.WriteLine("1 - Заполнить данные для сортировки");
                Console.WriteLine("2 - Сортировка простыми вставками");
                Console.WriteLine("3 - Сортировка простым обменом");
                Console.WriteLine("4 - Сортировка простым выбором");
                Console.WriteLine("5 - Пирамидальная сортировка");
                Console.WriteLine("6 - Быстрая сортировка");
                Console.WriteLine("7 - Характеристики сортировок");
                Console.WriteLine("8 - Выход;");
                int.TryParse(Console.ReadLine(), out int sw);
                switch (sw)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Что сортируем?\n0 - Массив чисел\n1 - Массив записей");
                        int.TryParse(Console.ReadLine(), out a);
                        if (a == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("Введите длинну массива");
                            if (int.TryParse(Console.ReadLine(), out int n) && n >= 0)
                            {
                                sortArray = RandomGenerator.GenerateRandomNumbers(n);
                                Console.WriteLine($"В массив добавленно {sortArray.Length} чисел");
                            }
                        }
                        else if (a == 1)
                        {
                            for (int i = 0; i < 20; i++)
                            {
                                Track track = new Track
                                {
                                    Departure = Track_List[random.Next(Track_List.Count)],
                                    Destination = Track_List[random.Next(Track_List.Count)],
                                    TrackNumber = random.Next(1000, 10000)
                                };
                                trackArray[i] = track;
                            }
                            Console.Clear();
                            Console.WriteLine("Массив записей создан");
                            foreach (Track track in trackArray)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error");
                        }
                        break;
                    case 2:
                        Console.Clear();
                        Console.WriteLine("Array to sort:\n0 - numbers\n1 - track numbers");
                        int.TryParse(Console.ReadLine(), out int s);
                        Console.Clear();
                        if (s == 0 && sortArray.Length > 0)
                        {
                            int n = sortArray.Length;
                            int[] array = new int[n];
                            Array.Copy(sortArray, array, n);
                            InsertionSortWithStatsInts(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                        }
                        else if (s == 1 && trackArray.Length > 0)
                        {
                            int n = trackArray.Length;
                            Track[] array = new Track[n];
                            Array.Copy(trackArray, array, n);
                            InsertionSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                            Console.WriteLine("\nSourse array:");
                            foreach (Track track in trackArray)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                            Console.WriteLine("\nSorted array:");
                            foreach (Track track in array)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error");
                        }

                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Array to sort:\n0 - numbers\n1 - track numbers");
                        int.TryParse(Console.ReadLine(), out s);
                        Console.Clear();
                        if (s == 0 && sortArray.Length > 0)
                        {
                            int n = sortArray.Length;
                            int[] array = new int[n];
                            Array.Copy(sortArray, array, n);
                            BubbleSortWithStatsInts(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                        }
                        else if (s == 1 && trackArray.Length > 0)
                        {
                            int n = trackArray.Length;
                            Track[] array = new Track[n];
                            Array.Copy(trackArray, array, n);
                            BubbleSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                            Console.WriteLine("\nSourse array:");
                            foreach (Track track in trackArray)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                            Console.WriteLine("Sorted array:");
                            foreach (Track track in array)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error");
                        }
                        break;
                    case 4:
                        Console.Clear();
                        Console.WriteLine("Array to sort:\n0 - numbers\n1 - track numbers");
                        int.TryParse(Console.ReadLine(), out s);
                        Console.Clear();
                        if (s == 0 && sortArray.Length > 0)
                        {
                            int n = sortArray.Length;
                            int[] array = new int[n];
                            Array.Copy(sortArray, array, n);
                            SelectionSortWithStatsInts(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                        }
                        else if (s == 1 && trackArray.Length > 0)
                        {
                            int n = trackArray.Length;
                            Track[] array = new Track[n];
                            Array.Copy(trackArray, array, n);
                            SelectionSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                            Console.WriteLine("\nSourse array:");
                            foreach (Track track in trackArray)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                            Console.WriteLine("Sorted array:");
                            foreach (Track track in array)
                            {
                                Console.WriteLine($"Deparure: {track.Departure}, Destination: {track.Destination}, Track Number: {track.TrackNumber}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error");
                        }
                        break;
                    case 5:
                        Console.Clear();
                        Console.WriteLine("Array to sort:\n0 - numbers\n1 - track numbers");
                        int.TryParse(Console.ReadLine(), out s);
                        Console.Clear();
                        if (s == 0 && sortArray.Length > 0)
                        {
                            int n = sortArray.Length;
                            int[] array = new int[n];
                            Array.Copy(sortArray, array, n);
                            HeapSortWithStatsInts(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                        }
                        else if (s == 1 && trackArray.Length > 0)
                        {
                            int n = trackArray.Length;
                            Track[] array = new Track[n];
                            Array.Copy(trackArray, array, n);
                            HeapSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                            Console.WriteLine("\nSourse array:");
                            foreach (Track track in trackArray)
                            {
                                Console.WriteLine($"Deparure:  {track.Departure} , Destination:  {track.Destination} , Track Number: {track.TrackNumber}");
                            }
                            Console.WriteLine("Sorted array:");
                            foreach (Track track in array)
                            {
                                Console.WriteLine($"Deparure:  {track.Departure} , Destination:  {track.Destination} , Track Number: {track.TrackNumber}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error");
                        }
                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("Array to sort:\n0 - numbers\n1 - track numbers");
                        int.TryParse(Console.ReadLine(), out s);
                        Console.Clear();
                        Stopwatch stopwatch = new Stopwatch();
                        if (s == 0 && sortArray.Length > 0)
                        {
                            int n = sortArray.Length;
                            int[] array = new int[n];
                            Array.Copy(sortArray, array, n);
                            stopwatch.Start();
                            QuickSortWithStatsInts(array, out comparisons, out swaps);
                            stopwatch.Stop();
                            elapsedTime = stopwatch.Elapsed;
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                        }
                        else if (s == 1 && trackArray.Length > 0)
                        {
                            int n = trackArray.Length;
                            Track[] array = new Track[n];
                            Array.Copy(trackArray, array, n);
                            stopwatch.Start();
                            QuickSortWithStatsTracks(array, out comparisons, out swaps);
                            stopwatch.Stop();
                            elapsedTime = stopwatch.Elapsed;
                            Console.Clear();
                            Console.WriteLine("Comparisons: " + comparisons);
                            Console.WriteLine("Swaps: " + swaps);
                            Console.WriteLine("Time: " + elapsedTime.TotalMilliseconds);
                            Console.WriteLine("\nSourse array:");
                            foreach (Track track in trackArray)
                            {
                                Console.WriteLine($"Deparure:  {track.Departure} , Destination:  {track.Destination} , Track Number: {track.TrackNumber}");
                            }
                            Console.WriteLine("Sorted array:");
                            foreach (Track track in array)
                            {
                                Console.WriteLine($"Departure:{track.Departure}, Destination{track.Destination}, Track number{track.TrackNumber}");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Error");
                        }
                        break;
                    case 7:
                        using (var p = new ExcelPackage(@"C:\Users\alexs\source\repos\LW_Sorting\LW_Sorting\bin\Debug\net6.0\LW_sort.xlsx"))
                        {
                            ExcelWorksheet worksheet = p.Workbook.Worksheets["List_1"];
                            Stopwatch stopwatchQuickSort = new Stopwatch();
                            int[] comp = new int[5];
                            int[] swap = new int[5];
                            TimeSpan[] time = new TimeSpan[5];
                            Console.Clear();
                            Console.WriteLine("Array to sort:\n0 - numbers\n1 - track numbers");
                            int.TryParse(Console.ReadLine(), out s);
                            Console.Clear();
                            if (s == 0 && sortArray.Length > 0)
                            {
                                worksheet.Cells["A1"].Value = "Numbers";
                                int n = sortArray.Length;
                                worksheet.Cells["B3"].Value = n;
                                worksheet.Cells["C3:E7"].Value = null;
                                int[] array = new int[n];
                                Array.Copy(sortArray, array, n);
                                InsertionSortWithStatsInts(array, out comp[0], out swap[0], out time[0]);
                                Console.WriteLine($"comp: {comp[0]}, swap: {swap[0]}, time: {time[0]}");
                                worksheet.Cells["C3"].Value = comp[0];
                                worksheet.Cells["D3"].Value = swap[0];
                                worksheet.Cells["E3"].Value = time[0].TotalMilliseconds;

                                Array.Copy(sortArray, array, n);
                                BubbleSortWithStatsInts(array, out comp[1], out swap[1], out time[1]);
                                Console.WriteLine($"comp: {comp[1]}, swap: {swap[1]}, time: {time[1]}");

                                worksheet.Cells["C4"].Value = comp[1];
                                worksheet.Cells["D4"].Value = swap[1];
                                worksheet.Cells["E4"].Value = time[1].TotalMilliseconds;

                                Array.Copy(sortArray, array, n);
                                SelectionSortWithStatsInts(array, out comp[2], out swap[2], out time[2]);
                                Console.WriteLine($"comp: {comp[2]}, swap: {swap[2]}, time: {time[2]}");

                                worksheet.Cells["C5"].Value = comp[2];
                                worksheet.Cells["D5"].Value = swap[2];
                                worksheet.Cells["E5"].Value = time[2].TotalMilliseconds;

                                Array.Copy(sortArray, array, n);
                                HeapSortWithStatsInts(array, out comp[3], out swap[3], out time[3]);
                                Console.WriteLine($"comp: {comp[3]}, swap: {swap[3]}, time: {time[3]}");

                                worksheet.Cells["C6"].Value = comp[3];
                                worksheet.Cells["D6"].Value = swap[3];
                                worksheet.Cells["E6"].Value = time[3].TotalMilliseconds;

                                Array.Copy(sortArray, array, n);
                                stopwatchQuickSort.Start();
                                QuickSortWithStatsInts(array, out comp[4], out swap[4]);
                                stopwatchQuickSort.Stop();
                                time[4] = stopwatchQuickSort.Elapsed;
                                Console.WriteLine($"comp: {comp[4]}, swap: {swap[4]}, time: {time[4]}");

                                worksheet.Cells["C7"].Value = comp[4];
                                worksheet.Cells["D7"].Value = swap[4];
                                worksheet.Cells["E7"].Value = time[4].TotalMilliseconds;

                                Console.WriteLine("Array of numbers has been sorted!");
                            }
                            else if (s == 1 && trackArray.Length > 0)
                            {
                                worksheet.Cells["A1"].Value = "Tracks";
                                int n = trackArray.Length;
                                worksheet.Cells["B3"].Value = n;
                                worksheet.Cells["C3:E7"].Value = null;
                                Track[] array = new Track[n];
                                Array.Copy(trackArray, array, n);

                                InsertionSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                                worksheet.Cells["C3"].Value = comparisons;
                                worksheet.Cells["D3"].Value = swaps;
                                worksheet.Cells["E3"].Value = elapsedTime.TotalMilliseconds;


                                Array.Copy(trackArray, array, n);
                                BubbleSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                                worksheet.Cells["C4"].Value = comparisons;
                                worksheet.Cells["D4"].Value = swaps;
                                worksheet.Cells["E4"].Value = elapsedTime.TotalMilliseconds;

                                Array.Copy(trackArray, array, n);
                                SelectionSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                                worksheet.Cells["C5"].Value = comparisons;
                                worksheet.Cells["D5"].Value = swaps;
                                worksheet.Cells["E5"].Value = elapsedTime.TotalMilliseconds;

                                Array.Copy(trackArray, array, n);
                                HeapSortWithStatsTracks(array, out comparisons, out swaps, out elapsedTime);
                                worksheet.Cells["C6"].Value = comparisons;
                                worksheet.Cells["D6"].Value = swaps;
                                worksheet.Cells["E6"].Value = elapsedTime.TotalMilliseconds;

                                Array.Copy(trackArray, array, n);
                                stopwatchQuickSort.Start();
                                QuickSortWithStatsTracks(array, out comparisons, out swaps);
                                stopwatchQuickSort.Stop();
                                elapsedTime = stopwatchQuickSort.Elapsed;
                                worksheet.Cells["C7"].Value = comparisons;
                                worksheet.Cells["D7"].Value = swaps;
                                worksheet.Cells["E7"].Value = elapsedTime.TotalMilliseconds;

                                Console.WriteLine("Array of Tracks has been sorted!");
                            }
                            else
                            {
                                Console.Clear();
                                Console.WriteLine("Error");
                            }

                            p.Save();
                        }
                        break;

                }
            }
            while (Console.ReadKey(true).Key != ConsoleKey.Escape);



        }
        public static void InsertionSortWithStatsInts(int[] array, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {
            comparisons = 0;
            swaps = 0;


            Stopwatch stopwatch = new Stopwatch();

            int n = array.Length;

            stopwatch.Start();

            for (int i = 1; i < n; i++)
            {
                int key = array[i];
                int j = i - 1;
                comparisons++;

                while (j >= 0 && array[j] > key)
                {
                    array[j + 1] = array[j];
                    j--;

                    comparisons++;
                    swaps++;
                }

                array[j + 1] = key;
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;

        }
        public static void InsertionSortWithStatsTracks(Track[] trackArray, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {
            int n = trackArray.Length;
            comparisons = 0;
            swaps = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 1; i < n; i++)
            {
                Track key = trackArray[i];
                int j = i - 1;
                comparisons++;

                while (j >= 0 && trackArray[j].TrackNumber > key.TrackNumber)
                {
                    trackArray[j + 1] = trackArray[j];
                    j--;

                    comparisons++;
                    swaps++;
                }

                trackArray[j + 1] = key;
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;

        }




        public static void BubbleSortWithStatsInts(int[] array, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {

            comparisons = 0;
            swaps = 0;

            Stopwatch stopwatch = new Stopwatch();

            int n = array.Length;

            stopwatch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Увеличение счетчика сравнений
                    comparisons++;

                    if (array[j] > array[j + 1])
                    {
                        // Меняем элементы местами
                        int temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                        swaps++; // Увеличение счетчика перестановок
                    }
                }
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
        }


        public static void BubbleSortWithStatsTracks(Track[] trackArray, out int comparisons, out int swaps, out TimeSpan elapsedTime)

        {
            comparisons = 0;
            swaps = 0;
            int n = trackArray.Length;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Увеличение счетчика сравнений
                    comparisons++;

                    if (trackArray[j].TrackNumber > trackArray[j + 1].TrackNumber)
                    {
                        // Меняем элементы местами
                        Track temp = trackArray[j];
                        trackArray[j] = trackArray[j + 1];
                        trackArray[j + 1] = temp;
                        swaps++; // Увеличение счетчика перестановок
                    }
                }
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;

        }



        public static void SelectionSortWithStatsInts(int[] array, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {


            comparisons = 0;
            swaps = 0;

            Stopwatch stopwatch = new Stopwatch();

            int n = array.Length;

            stopwatch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    // Увеличение счетчика сравнений
                    comparisons++;

                    if (array[j] < array[minIndex])
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    // Меняем элементы местами
                    int temp = array[i];
                    array[i] = array[minIndex];
                    array[minIndex] = temp;
                    swaps++; // Увеличение счетчика перестановок
                }
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
        }

        public static void SelectionSortWithStatsTracks(Track[] trackArray, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {

            int n = trackArray.Length;
            comparisons = 0;
            swaps = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < n - 1; i++)
            {
                int minIndex = i;

                for (int j = i + 1; j < n; j++)
                {
                    // Увеличение счетчика сравнений
                    comparisons++;

                    if (trackArray[j].TrackNumber < trackArray[minIndex].TrackNumber)
                    {
                        minIndex = j;
                    }
                }

                if (minIndex != i)
                {
                    // Меняем элементы местами
                    Track temp = trackArray[i];
                    trackArray[i] = trackArray[minIndex];
                    trackArray[minIndex] = temp;
                    swaps++; // Увеличение счетчика перестановок
                }
            }

            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;

        }


        public static void HeapSortWithStatsInts(int[] array, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {
            int n = array.Length;
            comparisons = 0;
            swaps = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Построение начальной max-кучи
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                HeapifyInts(array, n, i, ref comparisons, ref swaps);
            }

            // Извлечение элементов из кучи и сортировка
            for (int i = n - 1; i >= 0; i--)
            {
                // Меняем корень (максимальный элемент) с последним элементом
                int temp = array[0];
                array[0] = array[i];
                array[i] = temp;
                swaps++; // Увеличение счетчика перестановок

                // Вызываем Heapify на уменьшенной куче
                HeapifyInts(array, i, 0, ref comparisons, ref swaps);
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
        }

        private static void HeapifyInts(int[] array, int n, int root, ref int comparisons, ref int swaps)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // Увеличение счетчика сравнений
            comparisons++;

            if (left < n && array[left] > array[largest])
            {
                largest = left;
            }

            // Увеличение счетчика сравнений
            comparisons++;

            if (right < n && array[right] > array[largest])
            {
                largest = right;
            }

            if (largest != root)
            {
                // Меняем корень (root) с largest
                int swap = array[root];
                array[root] = array[largest];
                array[largest] = swap;
                swaps++; // Увеличение счетчика перестановок

                // Рекурсивно вызываем Heapify для поддерева
                HeapifyInts(array, n, largest, ref comparisons, ref swaps);
            }
        }
        public static void HeapSortWithStatsTracks(Track[] trackArray, out int comparisons, out int swaps, out TimeSpan elapsedTime)
        {
            int n = trackArray.Length;
            comparisons = 0;
            swaps = 0;
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            // Построение начальной max-кучи
            for (int i = n / 2 - 1; i >= 0; i--)
            {
                HeapifyTracks(trackArray, n, i, ref comparisons, ref swaps);
            }

            // Извлечение элементов из кучи и сортировка
            for (int i = n - 1; i >= 0; i--)
            {
                // Меняем корень (максимальный элемент) с последним элементом
                Track temp = trackArray[0];
                trackArray[0] = trackArray[i];
                trackArray[i] = temp;
                swaps++; // Увеличение счетчика перестановок

                // Вызываем Heapify на уменьшенной куче
                HeapifyTracks(trackArray, i, 0, ref comparisons, ref swaps);
            }
            stopwatch.Stop();
            elapsedTime = stopwatch.Elapsed;
        }

        private static void HeapifyTracks(Track[] trackArray, int n, int root, ref int comparisons, ref int swaps)
        {
            int largest = root;
            int left = 2 * root + 1;
            int right = 2 * root + 2;

            // Увеличение счетчика сравнений
            comparisons++;

            if (left < n && trackArray[left].TrackNumber > trackArray[largest].TrackNumber)
            {
                largest = left;
            }

            // Увеличение счетчика сравнений
            comparisons++;

            if (right < n && trackArray[right].TrackNumber > trackArray[largest].TrackNumber)
            {
                largest = right;
            }

            if (largest != root)
            {
                // Меняем корень (root) с largest
                Track temp = trackArray[root];
                trackArray[root] = trackArray[largest];
                trackArray[largest] = temp;
                swaps++; // Увеличение счетчика перестановок

                // Рекурсивно вызываем Heapify для поддерева
                HeapifyTracks(trackArray, n, largest, ref comparisons, ref swaps);
            }
        }
        public static void QuickSortWithStatsInts(int[] array, out int comparisons, out int swaps)
        {
            int n = array.Length;
            comparisons = 0;
            swaps = 0;

            QuickSortInts(array, 0, n - 1, ref comparisons, ref swaps);

        }

        private static void QuickSortInts(int[] array, int low, int high, ref int comparisons, ref int swaps)
        {
            if (low < high)
            {
                int partitionIndex = PartitionInts(array, low, high, ref comparisons, ref swaps);

                QuickSortInts(array, low, partitionIndex - 1, ref comparisons, ref swaps);
                QuickSortInts(array, partitionIndex + 1, high, ref comparisons, ref swaps);
            }
        }

        private static int PartitionInts(int[] array, int low, int high, ref int comparisons, ref int swaps)
        {
            int pivot = array[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                // Увеличение счетчика сравнений
                comparisons++;

                if (array[j] < pivot)
                {
                    i++;

                    // Меняем элементы местами
                    int temp = array[i];
                    array[i] = array[j];
                    array[j] = temp;
                    swaps++; // Увеличение счетчика перестановок
                }
            }

            // Меняем элементы местами
            int temp2 = array[i + 1];
            array[i + 1] = array[high];
            array[high] = temp2;
            swaps++; // Увеличение счетчика перестановок

            return i + 1;
        }
        public static void QuickSortWithStatsTracks(Track[] trackArray, out int comparisons, out int swaps)
        {
            int n = trackArray.Length;
            comparisons = 0;
            swaps = 0;

            QuickSortTracks(trackArray, 0, n - 1, ref comparisons, ref swaps);

        }

        private static void QuickSortTracks(Track[] trackArray, int low, int high, ref int comparisons, ref int swaps)
        {
            if (low < high)
            {
                int partitionIndex = PartitionTracks(trackArray, low, high, ref comparisons, ref swaps);

                QuickSortTracks(trackArray, low, partitionIndex - 1, ref comparisons, ref swaps);
                QuickSortTracks(trackArray, partitionIndex + 1, high, ref comparisons, ref swaps);
            }
        }

        private static int PartitionTracks(Track[] trackArray, int low, int high, ref int comparisons, ref int swaps)
        {
            Track pivot = trackArray[high];
            int i = low - 1;

            for (int j = low; j < high; j++)
            {
                // Увеличение счетчика сравнений
                comparisons++;

                if (trackArray[j].TrackNumber < pivot.TrackNumber)
                {
                    i++;

                    // Меняем элементы местами
                    Track temp = trackArray[i];
                    trackArray[i] = trackArray[j];
                    trackArray[j] = temp;
                    swaps++; // Увеличение счетчика перестановок
                }
            }

            // Меняем элементы местами
            Track temp2 = trackArray[i + 1];
            trackArray[i + 1] = trackArray[high];
            trackArray[high] = temp2;
            swaps++; // Увеличение счетчика перестановок

            return i + 1;
        }

        public class Track
        {
            public string Departure { get; set; }
            public string Destination { get; set; }
            public int TrackNumber { get; set; }

        }
        public class RandomGenerator
        {
            public static int[] GenerateRandomNumbers(int n)
            {
                Random random = new Random();
                int[] randomNumbers = new int[n];

                for (int i = 0; i < n; i++)
                {
                    randomNumbers[i] = random.Next(-10000, 10001);
                }

                return randomNumbers;
            }


        }
    }
}


//using (var p = new ExcelPackage(@"C:\Users\alexs\source\repos\LW_Sorting\LW_Sorting\bin\Debug\net6.0\LW_sort.xlsx"))
//{
//    ExcelWorksheet worksheet = p.Workbook.Worksheets["List_1"];
//    worksheet.Cells["A1:B2"].Value = null;
//    p.Save();
//}