using System;
using System.Collections.Generic;
using castlecrashers.Models;
using castlecrashers.Repositories;

namespace castlecrashers.Services
{
    public class KnightService
    {
        private readonly KnightRepository _repo;

        public KnightService(KnightRepository repo)
        {
            _repo = repo;
        }

        internal IEnumerable<Knight> Get()
        {
            return _repo.GetAll();
        }

        internal Knight Get(int id)
        {
            Knight knight = _repo.GetById(id);
            if (knight == null)
            {
                throw new Exception("invalid id");
            }
            return knight;
        }

        internal Knight Create(Knight newKnight)
        {
            return _repo.Create(newKnight);
        }
        internal Knight Edit(Knight editKnight)
        {
            Knight original = Get(editKnight.Id);

            original.Name = editKnight.Name != null ? editKnight.Name : original.Name;
            original.Age = editKnight.Age != null ? editKnight.Age : original.Age;

            //NOTE if you need to null check a number, you can use the Elvis operator on the type in the class. 
            // original.Price = editKnight.Price != null ? editKnight.Price : original.Price;

            return _repo.Edit(original);
        }

        internal Knight Delete(int id)
        {
            Knight original = Get(id);
            _repo.Delete(id);
            return original;
        }

        internal IEnumerable<Knight> GetByCastleId(int id)
        {
            return _repo.GetByCastleId(id);
        }


    }
}