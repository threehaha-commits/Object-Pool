using System.Collections.Generic;
using UnityEngine;

namespace Threehaha{
    /// <summary>
    /// Combines a static and dynamic pool. Creates a specified number of items and creates new ones if necessary
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public class CombinePool<T> where T : Object
    {
        private readonly List<T> _items;
        private readonly T _item;

        public CombinePool(int size, T item)
        {
            _item = item;
            _items = new List<T>(new T[size]);
            ItemsCreate(item);
        }

        //Creates a specified number of items and writes them to an array
        private void ItemsCreate(T item)
        {
            for (int i = 0; i < _items.Count; i++)
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
        /// Returns an inactive item. If there is no such, then creates and returns a new one
        /// </summary>
        private T FindItem()
        {
            //Find inactive item
            foreach (var item in _items)
            {
                if ((item as GameObject).activeInHierarchy == false)
                    return item;
            }

            return CreateNewItem();
        }

        //Create new item
        private T CreateNewItem()
        {
            var item = Object.Instantiate(_item);
            _items.Add(item);
            return item;
        }
    }
}