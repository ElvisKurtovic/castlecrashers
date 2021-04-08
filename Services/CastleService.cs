using System;
using System.Collections.Generic;
using castlecrashers.Models;
using castlecrashers.Repositories;

namespace castlecrashers.Services
{
    public class CastleService
    {
        private readonly CastleRepository _repo;

        public CastleService(CastleRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Castle> Get()
        {
            return _repo.Get();
        }

        internal Castle Get(int id)
        {
            Castle castle = _repo.Get(id);
            if (castle == null)
            {
                throw new Exception("invalid id");
            }
            return castle;
        }

        internal Castle Create(Castle newCastle)
        {
            return _repo.Create(newCastle);
        }
        internal Castle Edit(Castle editCastle)
        {
            Castle original = Get(editCastle.Id);

            original.Name = editCastle.Name != null ? editCastle.Name : original.Name;
            original.Description = editCastle.Description != null ? editCastle.Description : original.Description;

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            // original.Price = editCastle.Price != null ? editCastle.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Castle Delete(int id)
        {
            Castle original = Get(id);
            _repo.Delete(id);
            return original;
        }


    }
}