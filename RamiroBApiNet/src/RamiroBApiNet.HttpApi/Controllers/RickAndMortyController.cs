using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RamiroBApiNet.Application.AppService;
using RamiroBApiNet.Application.Dtos;

namespace RamiroBApiNet.HttpApi.Controllers
{   
    [ApiController]
    [Route("[controller]")]
    public class RickAndMortyController : ControllerBase
    {
        private readonly ILogger<RickAndMortyController> _logger;
        private readonly IRickAndMortyAppService service;

        public RickAndMortyController(IRickAndMortyAppService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<ICollection<RickAndMortyDto>> GetAll()
        {
            return await service.GetAll();
        }
        [HttpGet("/post")]
        public async Task<ICollection<PostDto>> GetAll2()
        {
            return await service.GetAll2();
        }
        [HttpPost]
        public async Task<PostDto> CreateAsync(PostCrearActualizarDto postCrAcDto)
        {
            return await service.CreateAsync(postCrAcDto);
        }
        [HttpPut]
        public async Task<PostDto> UpdateAsync(PostCrearActualizarDto postCrAcDto,string id)
        {
            return await service.UpdateAsync(postCrAcDto,id);
        }

        [HttpDelete]
        public async Task<string> DeleteAsync(string id)
        {
            return await service.DeleteAsync(id);
        }
    }
        
}
