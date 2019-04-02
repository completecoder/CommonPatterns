using CompleteCoder.Common.Contracts;
using CompleteCoder.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;

namespace CompleteCoder.Common.DataPersistence
{
    /// <summary>
    /// This class is dependant on System.Runtime.Caching, so you need to ensure you add this to your project's references.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InMemoryRepository<T> : IRepository<T> where T : BaseEntity
    {
        ObjectCache cache = MemoryCache.Default;
        List<T> items;
        string className;

        public InMemoryRepository()
        {
            className = typeof(T).Name;

            items = cache[className] as List<T>;
            if (items == null)
            {
                items = new List<T>();
            }
        }

        public void DoSomthing()
        {

        }

        public void Commit()
        {
            cache[className] = items;
        }

        public void Insert(T t)
        {
            items.Add(t);
        }

        public void Update(T t)
        {
            T tToUpdate = items.Find(i => i.Id == t.Id); //find the product we want tp update in the list

            if (tToUpdate != null)
            {
                tToUpdate = t;
            }
            else
            {
                throw new Exception(className + " with Id " + t.Id + " Not found!");
            }
        }

        public T Find(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                return t;
            }
            else
            {
                throw new Exception(className + " with Id " + Id + " Not found!");
            }
        }

        public IQueryable<T> Collection()
        {
            return items.AsQueryable();
        }

        public void Delete(string Id)
        {
            T t = items.Find(i => i.Id == Id);
            if (t != null)
            {
                items.Remove(t);
            }
            else
            {
                throw new Exception(className + " with Id " + Id + " Not found!");
            }
        }
    }
}

