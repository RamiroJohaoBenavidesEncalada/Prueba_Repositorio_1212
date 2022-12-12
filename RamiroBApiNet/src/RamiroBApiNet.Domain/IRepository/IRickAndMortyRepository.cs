using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamiroBApiNet.Domain.Modelos;

namespace RamiroBApiNet.Domain.IRepository
{
    public interface IRickAndMortyRepository
    {
        Task<ICollection<RickAndMorty>> GetAll();

        Task<ICollection<Post>> GetAll2();

    }
}