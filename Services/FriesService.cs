using System;
using System.Collections.Generic;
using gregslistapi.Models;
using gregslistapi.Repositories;

namespace gregslistapi.Services
{
    public class FriesService
    {
        private readonly FriesRepository _repo;

        public FriesService(FriesRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Fries> Get()
        {
            return _repo.Get();
        }

        internal Fries Get(int id)
        {
            Fries fries = _repo.Get(id);
            if (fries == null)
            {
                throw new Exception("invalid id");
            }
            return fries;
        }

        internal Fries Create(Fries newFries)
        {
            return _repo.Create(newFries);
        }
        internal Fries Edit(Fries editFries)
        {
            Fries original = Get(editFries.Id);

            original.Name = editFries.Name != null ? editFries.Name : original.Name;
            original.Description = editFries.Description != null ? editFries.Description : original.Description;

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            original.Price = editFries.Price != null ? editFries.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Fries Delete(int id)
        {
            Fries original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}