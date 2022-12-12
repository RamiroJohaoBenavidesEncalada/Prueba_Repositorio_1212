using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamiroBApiNet.Application.Dtos
{
    public class PostDto
    {
        public int userId { get; set; }
        public int id { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
    public class PostCrearActualizarDto
    {
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }
    }
}