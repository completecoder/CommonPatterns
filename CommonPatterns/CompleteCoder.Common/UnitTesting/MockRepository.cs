using CompleteCoder.Common.Contracts;
using CompleteCoder.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CompleteCoder.Common.UnitTesting
{
    public class MockRepository<T> : IRepository<T> where T : BaseEntity
    {
        List<T> items = new List<T>();

        public void Commit()
        {
            //do nothing
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
                throw new Exception("object Not found!");
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
                throw new Exception("object Not found!");
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
                throw new Exception("object Not found!");
            }
        }
    }
}
