using _3.Library3;
class Program
{
    public static void Main()
    {
        WordsFrequency.PrintCalculatedFrequency("каждое слово по два раза. КАЖДОЕ СЛОВО ПО ДВА РАЗА и еще какие-то слова");
        TestForeach();
        TestSorting();
    }

    /// <summary>
    /// Метод для проверки перебора массива с помощью foreach.
    /// </summary>
    public static void TestForeach()
    {
        var dynamicArray = new DynamicArray<int>();
        for (var i = 0; i < 10; i++)
        {
            dynamicArray.Add(i);
        }
        foreach (var item in dynamicArray)
        {
            Console.Write(item + " ");
        }
        Console.WriteLine();
    }

    /// <summary>
    /// Метод для проверки упорядочивания массива.
    /// </summary>
    public static void TestSorting()
    {
        int[] array = { 10, 9, 8, 12, 4, 0, 6, 3 };
        var sort = new ArbitaryArraySorting();
        sort.SortArray<int>(array, ArbitaryArraySorting.CompareIntArray);
        sort.SortingIsDone += (s, e) => Console.WriteLine("Сортировка завершена");
        foreach (var item in array)
        {
            Console.Write(item + " ");
        }
    }
    //private static void Sort_SortingIsDone
    //(object? sender, EventArgs e)
    //{
    //    Console.WriteLine("\nСортировка завершена");
    //}
}
