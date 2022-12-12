
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamiroBApiNet.Domain.Modelos;

public class Root
{
    public Info info { get; set; }
    public List<RickAndMorty> results { get; set; }
}

