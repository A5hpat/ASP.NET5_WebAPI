using System;
using System.Collections.Generic;
using System.Linq;

namespace webapiAPP.Model
{
    public class TestRepo
    {
        readonly List<Todo> _items = new List<Todo>(){
            new Todo { Id = 1, Title = "First Item" }
        };

        public IEnumerable<Todo> AllItems
        {
            get
            {
                return _items;
            }
        }

        public Todo GetById(int id)
        {
            return _items.FirstOrDefault(x => x.Id == id);
        }

        public void Add(Todo item)
        {
            item.Id = 1 + _items.Max(x => (int?)x.Id) ?? 0;
            _items.Add(item);
        }

        public bool TryDelete(int id)
        {
            var item = GetById(id);
            if (item == null)
            {
                return false;
            }
            _items.Remove(item);
            return true;
        }

    }
}