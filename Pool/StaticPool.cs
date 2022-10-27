using UnityEngine;

namespace Threehaha
{
    /// <summary>
    /// Creates a pool with the specified size. If the search for the desired item fails, it will return the first element of the array
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public class StaticPool<T> where T : Object
    {
        private readonly T[] _items;

        public StaticPool(int size, T item)
        {
            _items = new T[size];
            ItemsCreate(item);
        }

        //Creates a specified number of items and writes them to an array
        private void ItemsCreate(T item)
        {
            for (int i = 0; i < _items.Length; i++)
            {
                var newItem = Object.Instantiate(item);
                _items[i] = newItem;
            }
        }

        public T Pull()
        {
            var newItem = FindItem();
            (newItem as GameObject).SetActive(true);
            return newItem;
        }

        /// <summary>
        /// Returns inactive item. If there are none returns the first element of the array
        /// </summary>
        private T FindItem()
        {
            var item = Find();

            if (item == null)
                return _items[0];

            return item;
        }

        /// <summary>
        /// Find and return inactive item
        /// </summary>
        /// <returns>return null if all items is active</returns>
        private T Find()
        {
            foreach (var item in _items)
            {
                if ((item as GameObject).activeInHierarchy == false)
                {
                    (item as GameObject).SetActive(true);
                    return item;
                }
            }

            return null;
        }
    }
}