using System;
using System.Collections.Generic;
using System.Data;
using gregslistapi.Models;
using Dapper;

namespace gregslistapi.Repositories
{
    public class BurgerRepository
    {

        public readonly IDbConnection _db;

        public BurgerRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Burger> Get()
        {
            string sql = "SELECT * FROM burgers;";
            return _db.Query<Burger>(sql);
        }

        internal Burger Get(int Id)
        {
            string sql = "SELECT * FROM burgers WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Burger>(sql, new { Id });
        }

        internal Burger Create(Burger newBurger)
        {
            string sql = @"
      INSERT INTO burgers
      (name, description, price)
      VALUES
      (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newBurger);
            newBurger.Id = id;
            return newBurger;
        }

        internal Burger Edit(Burger burgerToEdit)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE burgers
      SET
          name = @Name,
          description = @Description,
          price = @Price
      WHERE id = @Id;
      SELECT * FROM burgers WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Burger>(sql, burgerToEdit);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM burgers WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}