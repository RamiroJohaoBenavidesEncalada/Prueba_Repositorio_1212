using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RamiroBApiNet.Domain.IRepository;
using RamiroBApiNet.Domain.Modelos;
using System.Text.Json;
using RestSharp;

namespace RamiroBApiNet.Infraestructure.Repository
{
    public class RickAndMortyRepository : IRickAndMortyRepository
    {
        public async Task<ICollection<RickAndMorty>> GetAll()
        {
            var client = new RestSharp.RestClient("https://rickandmortyapi.com/api");
            var request = new RestSharp.RestRequest("/character");
            var response = await client.GetAsync(request);
            var responseContent = response.Content;
            //var list = new List<RickAndMorty>();
            var resultEntity = JsonSerializer.Deserialize<Root>(responseContent);
            return resultEntity.results;
        }

        public async Task<ICollection<Post>> GetAll2()
        {
            var url = "https://jsonplaceholder.typicode.com/posts";
            HttpClient client = new HttpClient();

            var httpResponse = await client.GetAsync(url);

            var content = await httpResponse.Content.ReadAsStringAsync();
            System.Console.WriteLine("Contenido Json");
            System.Console.WriteLine(content);

            var posts = JsonSerializer.Deserialize<List<Post>>(content);

            return posts;

        }
        
    }
}