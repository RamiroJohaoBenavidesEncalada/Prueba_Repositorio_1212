using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using RamiroBApiNet.Application.Dtos;
using RamiroBApiNet.Domain.IRepository;
using RamiroBApiNet.Domain.Modelos;

namespace RamiroBApiNet.Application.AppService
{
    public class RickAndMortyAppService : IRickAndMortyAppService
    {
        private readonly IRickAndMortyRepository repository;

        public RickAndMortyAppService(IRickAndMortyRepository repository)
        {
            this.repository = repository;
        }
        public async Task<ICollection<RickAndMortyDto>> GetAll()
        {
            var resultList = await repository.GetAll();
            // Mapeo Entidad -> Dto
            var entityDtoList = resultList.Select(i => new RickAndMortyDto()
            {
                id = i.id,
                name = i.name
            });

            return entityDtoList.ToList();
        }

        public async Task<ICollection<PostDto>> GetAll2()
        {
            var listaPost = await repository.GetAll2();

            var listaPostDto = listaPost.Select(x => new PostDto()
                                        {
                                            userId=x.userId,
                                            id=x.id,
                                            title=x.title,
                                            body=x.body
                                        }
                                        );
            return listaPostDto.ToList();
        }

        public async Task<PostDto> CreateAsync(PostCrearActualizarDto postCrAcDto)
        {
            var url = "https://jsonplaceholder.typicode.com/posts";
            var client = new HttpClient();

            var post = new Post();
            post.userId=postCrAcDto.userId;
            post.title=postCrAcDto.title;
            post.body=postCrAcDto.body;

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8,"application/json");

            var httpResponse = await client.PostAsync(url, content);

            var result =await httpResponse.Content.ReadAsStringAsync();

            var postResult = JsonSerializer.Deserialize<Post>(result);

            var postDto = new PostDto();
            postDto.id=postResult.id;
            postDto.userId=postResult.userId;
            postDto.title=postResult.title;
            postDto.body=postResult.body;

            return postDto;

        }

        public async Task<PostDto> UpdateAsync(PostCrearActualizarDto postCrAcDto, string id)
        {
            var url = "https://jsonplaceholder.typicode.com/posts/";
            url = url + id;
            
            var client = new HttpClient();

            var post = new Post();
            post.userId=postCrAcDto.userId;
            post.title=postCrAcDto.title;
            post.body=postCrAcDto.body;

            var data = JsonSerializer.Serialize<Post>(post);
            HttpContent content = new StringContent(data, System.Text.Encoding.UTF8,"application/json");

            var httpResponse = await client.PutAsync(url, content);

            var result =await httpResponse.Content.ReadAsStringAsync();

            var putResult = JsonSerializer.Deserialize<Post>(result);

            var postDto = new PostDto();
            postDto.id=putResult.id;
            postDto.userId=putResult.userId;
            postDto.title=putResult.title;
            postDto.body=putResult.body;

            return postDto;

        }

        public async Task<string> DeleteAsync(string id)
        {
            var url = "https://jsonplaceholder.typicode.com/posts/";
            url = url + id;
            
            var client = new HttpClient();

            //var post = new Post();
            //post.userId=postCrAcDto.userId;
            //post.title=postCrAcDto.title;
            //post.body=postCrAcDto.body;

            //var data = JsonSerializer.Serialize<Post>(post);
            //HttpContent content = new StringContent(data, System.Text.Encoding.UTF8,"application/json");

            var httpResponse = await client.DeleteAsync(url);

            var result =await httpResponse.Content.ReadAsStringAsync();

            return result;

        }

    }
}