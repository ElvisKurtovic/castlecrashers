using System;
using System.Collections.Generic;
using System.Data;
using castlecrashers.Models;
using Dapper;

namespace castlecrashers.Repositories
{
    public class CastleRepository
    {

        public readonly IDbConnection _db;

        public CastleRepository(IDbConnection db)
        {
            _db = db;
        }

        internal IEnumerable<Castle> Get()
        {
            string sql = "SELECT * FROM castles;";
            return _db.Query<Castle>(sql);
        }

        internal Castle Get(int Id)
        {
            string sql = "SELECT * FROM castles WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Castle>(sql, new { Id });
        }

        internal Castle Create(Castle newCastle)
        {
            string sql = @"
      INSERT INTO castles
      (name, description)
      VALUES
      (@Name, @Description);
      SELECT LAST_INSERT_ID();";
            int id = _db.ExecuteScalar<int>(sql, newCastle);
            newCastle.Id = id;
            return newCastle;
        }

        internal Castle Edit(Castle castleToEdit)
        {

            //After you go an update it make sure to go and select it again
            string sql = @"
      UPDATE castles
      SET
          name = @Name,
          description = @Description
      WHERE id = @Id;
      SELECT * FROM castles WHERE id = @Id;";
            return _db.QueryFirstOrDefault<Castle>(sql, castleToEdit);

        }

        internal void Delete(int id)
        {
            string sql = "DELETE FROM castles WHERE id = @id;";
            _db.Execute(sql, new { id });
            return;
        }
    }
}