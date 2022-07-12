using System.Collections;

namespace _3.Library3
{
    /// <summary>
    /// Массив для хранения элементов любого типа.
    /// Содержит функции добавления, вставки, удаления элементов.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DynamicArray<T> : IEnumerable<T>
    {
        const int DEFAULT_ARRAY_SIZE = 8;
        int amountOfElements = 0;
        T[] dynamicArray;

        public T this[int i]
        {
            get { return dynamicArray[i]; }
            set { dynamicArray[i] = value; }
        }

        public DynamicArray()
        {
            dynamicArray = new T[DEFAULT_ARRAY_SIZE];
        }

        public DynamicArray(int size)
        {
            if (size < 0)
            {
                throw new ArgumentOutOfRangeException("Размер массива не может быть отрицательным", nameof(size));
            }
            dynamicArray = new T[size];
        }

        public DynamicArray(IEnumerable<T> collection)
        {
            if (collection == null)
            {
                throw new ArgumentNullException("Переданная коллекция пустая", nameof(collection));
            }
            dynamicArray = new T[collection.Count()];
            for (var i = 0; i < collection.Count(); i++)
            {
                dynamicArray[i] = collection.ElementAt(i);
            }
            amountOfElements = collection.Count();
        }
        /// <summary>
        /// Добавляет элемент массив.
        /// </summary>
        /// <param name="item"></param>
        public void Add(T item)
        {
            if (amountOfElements == dynamicArray.Length)
            {
                var newArray = new T[dynamicArray.Length * 2];
                for (var i = 0; i < dynamicArray.Length; i++)
                {
                    newArray[i] = dynamicArray[i];
                }
                dynamicArray = newArray;
            }
            dynamicArray[amountOfElements] = item;
            amountOfElements++;
        }

        /// <summary>
        /// Добавляет коллекцию элементов в конец массива.
        /// </summary>
        /// <param name="collection"></param>
        public void AddRange(IEnumerable<T> collection)
        {
            if (collection is null)
            {
                throw new ArgumentNullException("Переданная коллекция пустая", nameof(collection));
            }

            if (Capacity < Length + collection.Count())
            {
                var newArray = new T[Length + collection.Count()];
                for (var i = 0; i < Length; i++)
                {
                    newArray[i] = GetElement(i);
                }
                dynamicArray = newArray;
            }
            for (var i = 0; i < collection.Count(); i++)
            {
                Add(collection.ElementAt(i));
            }
        }

        /// <summary>
        /// Удаляет элемент по указанному индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public bool RemoveAt(int index)
        {
            if (index >= amountOfElements || index < 0)
            {
                throw new ArgumentOutOfRangeException("Нет элемента с таким индексом", nameof(index));
            }
            for (var i = index; i < amountOfElements; i++)
            {
                dynamicArray[i] = dynamicArray[i + 1];
            }
            amountOfElements--;
            return true;
        }

        /// <summary>
        /// Удаляет элемент массива, равный переданному в параметре. 
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public bool Remove(T item)
        {
            if (item == null)
            {
                throw new ArgumentNullException("Переданный элемент - null", nameof(item));
            }
            for (var i = 0; i < amountOfElements; i++)
            {
                if (GetElement(i).Equals(item))
                {
                    return RemoveAt(i);
                }
            }
            return false;
        }

        /// <summary>
        /// Вставляет элемент по указанному индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <param name="item"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public void Insert(int index, T item)
        {
            if (index > amountOfElements || index < 0)
            {
                throw new ArgumentOutOfRangeException("Невозможно добавить элемент в указанную позицию", nameof(index));
            }
            if (index == amountOfElements)
            {
                Add(item);
            }
            else
            {
                for (var i = amountOfElements + 1; i > index; i--)
                {
                    dynamicArray[i] = dynamicArray[i - 1];
                }
                dynamicArray[index] = item;
                amountOfElements++;
            }
        }

        /// <summary>
        /// Возвращает количество элементов массива.
        /// </summary>
        public int Length
        {
            get { return amountOfElements; } 
        }

        /// <summary>
        /// Возвращает длину внутреннего массива.
        /// </summary>
        /// <returns></returns>
        public int Capacity
        {
            get { return dynamicArray.Length; }
        }

        /// <summary>
        /// Возвращает элемент по указанному индексу.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public T GetElement(int index)
        {
            if (index < 0 || index >= amountOfElements)
            {
                throw new ArgumentOutOfRangeException("неверный индекс", nameof(index));
            }
            return dynamicArray[index];
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(dynamicArray);
        }

        /// <summary>
        /// Переопределяет метод Equals для сравнения массивов по их соддержимому.
        /// </summary>
        /// <returns></returns>
        public override bool Equals(object? obj)
        {
            if ((obj == null) || (!this.GetType().Equals(obj.GetType())))
            {
                return false;
            }
            DynamicArray<T> Array = (DynamicArray<T>)obj;
            if (this.Length != Array.Length)
            {
                return false;
            }
            for (var i = 0; i < Length; i++)
            {
                if (!this.GetElement(i).Equals(Array.GetElement(i)))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// Реализация функции для foreach.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<T> GetEnumerator()
        {
            for (var i = 0; i < Length; i++)
            {
                yield return this.GetElement(i);
            }
        }

        /// <summary>
        /// Реализация функции для foreach.
        /// </summary>
        /// <returns></returns>
        IEnumerator IEnumerable.GetEnumerator()
        {
            return dynamicArray.GetEnumerator();
        }
    }
}

