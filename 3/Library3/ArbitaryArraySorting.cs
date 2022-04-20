namespace _3.Library3
{
    public class ArbitaryArraySorting
    {
        public event EventHandler SortingIsDone;

        /// <summary>
        /// Метод для упорядочивания массива произвольного типа.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="array">Массив, который нужно отсортировать.</param>
        /// <param name="compareMethod">Метод сравнения.</param>
        public void SortArray<T>(T[] array, Func<T, T, int> compareMethod)
        {
            for (var i = 0; i < array.Length; i++)
            {
                for (var j = 0; j < array.Length; j++)
                {
                    if (compareMethod(array[j], array[i]) > 0)
                    {
                        var temp = array[i];
                        array[i] = array[j];
                        array[j] = temp;
                    }
                }
            }
            if (SortingIsDone == null)
            {
                throw new ArgumentNullException("событие = null", nameof(SortingIsDone));
            }
            SortingIsDone(this, null);

        }

        /// <summary>
        /// Метод для сравнения двух значений типа int.
        /// </summary>
        /// <param name="firstValue"></param>
        /// <param name="secondValue"></param>
        /// <returns></returns>
        public static int CompareIntArray(int firstValue, int secondValue)
        {
            if (firstValue == null)
            {
                return -1;
            }
            if (secondValue == null)
            {
                return 1;
            }
            return firstValue.CompareTo(secondValue);
        }
    }
}
