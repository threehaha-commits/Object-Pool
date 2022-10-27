using System.Collections.Generic;
using UnityEngine;

namespace Threehaha{
    /// <summary>
    /// Returns an inactive array element. If there are no inactive items, then creates and returns a new one
    /// </summary>
    /// <typeparam name="T">Object</typeparam>
    public class DynamicPool<T> where T : Object
    {
        private readonly Queue<T> _items = new();
        private readonly T _item;
        
        /// <summary>
        /// The item that the pool will work with
        /// </summary>
        public DynamicPool(T item)
        {
            _item = item;
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
            //if pool is empty
            if (_items.Count == 0)
                return CreateNewItem();

            List<T> items = new List<T>(_items);
            var item = items.Find(x => (x as GameObject).activeInHierarchy == false);
            
            //if there are no inactive items
            if (item == null)
                return CreateNewItem();
            
            //found item
            return item;
        }

        //Create new item
        private T CreateNewItem()
        {
            _items.Enqueue(Object.Instantiate(_item));
            return _items.Peek();
        }
    }
}