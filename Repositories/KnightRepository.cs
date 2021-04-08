using System;
using System.Collections.Generic;
using System.Data;
using Dapper;
using castlecrashers.Models;

namespace castlecrashers.Repositories
{
    public class KnightRepository
    {
        private readonly IDbConnection _db;

        public KnightRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Knight> GetAll()
        {
            string sql = "SELECT * FROM knights;";
            return _db.Query<Knight>(sql);
        }

        internal Knight GetById(int id)
        {
            string sql = "SELECT * FROM knights WHERE id = @id;";
            return _db.QueryFirstOrDefault<Knight>(sql, new { id });
        }

        internal Knight Create(Knight newKnight)
        {
            string sql = @"
      INSERT INTO knights
      (name, age, castleId)
      VALUES
      (@Name, @Age, @CastleId);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newKnight);
            newKnight.Id = id;
            return newKnight;
        }

        internal Knight Edit(Knight data)
        {
            string sql = @"
      UPDATE knights
      SET
        name = @Name,
        age = @Age
      WHERE id = @Id;
      SELECT * FROM knights WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Knight>(sql, data);
        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM knights WHERE id = @id LIMIT 1;";
            _db.Execute(sql, new { id });
        }

        internal IEnumerable<Knight> GetByCastleId(int id)
        {
            // string sql = "SELECT * FROM knights WHERE castleId = @id;";

            // return _db.Query<Knight>(sql, new { id });


            string sql = @"
              SELECT 
              k.*,
              c.*
              FROM knights k
              JOIN castles c ON k.castleId = c.id
              WHERE castleId = @id;";

            return _db.Query<Knight, Castle, Knight>(sql, (knight, castle) =>
            {
                knight.Castle = castle;
                return knight;
            }, new { id }, splitOn: "id");

        }
    }
}
