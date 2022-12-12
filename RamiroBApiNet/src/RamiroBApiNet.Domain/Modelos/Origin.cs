
// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamiroBApiNet.Domain.Modelos;
public class Origin
{
    public string name { get; set; }
    public string url { get; set; }
}

