using System;
using System.Collections.Generic;
using System.Data;
using gregslistapi.Models;
using Dapper;

namespace gregslistapi.Repositories
{
    public class FriesRepository
    {
        public readonly IDbConnection _db;

        public FriesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Fries> Get()
        {
            string sql = "SELECT * FROM fries;";
            return _db.Query<Fries>(sql);
        }

        internal Fries Get(int Id)
        {
            string sql = "SELECT * FROM fries WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Fries>(sql, new { Id });
        }

        internal Fries Create(Fries newFries)
        {
            string sql = @"INSERT INTO fries
      (name, description, price)
      VALUES
      (@Name, @Description, @Price);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newFries);
            newFries.Id = id;
            return newFries;
        }
        internal Fries Edit(Fries editedFries)
        {
            string sql = @"
            UPDATE fries
            SET
            name = @Name
            description = @Description
            price = @Price
            WHERE id = @Id
            SELECT * FROM fries WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Fries>(sql, editedFries);
        }
        internal void Delete(int id)
        {
            string sql = "DELETE FROM fries WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}