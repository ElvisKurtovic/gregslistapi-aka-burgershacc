using System;
using System.Collections.Generic;
using gregslistapi.Models;
using gregslistapi.Repositories;

namespace gregslistapi.Services
{
    public class BurgerService
    {
        private readonly BurgerRepository _repo;

        public BurgerService(BurgerRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Burger> Get()
        {
            return _repo.Get();
        }

        internal Burger Get(int id)
        {
            Burger burger = _repo.Get(id);
            if (burger == null)
            {
                throw new Exception("invalid id");
            }
            return burger;
        }

        internal Burger Create(Burger newBurger)
        {
            return _repo.Create(newBurger);
        }
        internal Burger Edit(Burger editBurger)
        {
            Burger original = Get(editBurger.Id);

            original.Name = editBurger.Name != null ? editBurger.Name : original.Name;
            original.Description = editBurger.Description != null ? editBurger.Description : original.Description;

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            original.Price = editBurger.Price != null ? editBurger.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Burger Delete(int id)
        {
            Burger original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}