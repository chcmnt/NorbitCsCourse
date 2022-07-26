namespace _3.Library3
{
    public class ArbitaryArraySorting
    {
        public delegate int CompareMethod<T> (T first, T second);

        public event EventHandler SortingIsDone;

        /// <summary>
        /// Вызов события SortingIsDone.
        /// </summary>
        public void InvokeSortingIsDone()
        {
            SortingIsDone.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Метод для упорядочивания массива произвольного типа.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Массив, который нужно отсортировать.</param>
        /// <param name="compareMethod">Метод сравнения.</param>
        public void SortArray<T>(T[] array, CompareMethod<T> compare)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length; j++)
                {
                    if (compare(array[i], array[j]) > 0)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }

        /// <summary>
        /// Метод для сравнения двух значений типа int.
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <returns></returns>
        public static int CompareIntArray(int firstValue, int secondValue)
        {
            if (firstValue < secondValue)
            {
                return 1;
            } 
            if (firstValue > secondValue)
            {
                return -1;
            }
            return 0;
        }
    }
}
