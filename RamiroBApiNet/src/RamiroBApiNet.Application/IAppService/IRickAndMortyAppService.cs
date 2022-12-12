using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamiroBApiNet.Application.Dtos;

namespace RamiroBApiNet.Application.AppService
{
    public interface IRickAndMortyAppService
    {
        Task<ICollection<RickAndMortyDto>> GetAll();
        Task<ICollection<PostDto>> GetAll2();

        Task<PostDto> CreateAsync(PostCrearActualizarDto postCrAcDto);
        Task<PostDto> UpdateAsync(PostCrearActualizarDto postCrAcDto,string id);

        Task<string> DeleteAsync(string id);
    }
}