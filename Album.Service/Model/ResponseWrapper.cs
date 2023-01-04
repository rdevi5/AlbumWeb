using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Album.Service.Model
{   
    internal class ResponseWrapper<T>
    {
        [JsonPropertyName("results")]
        public T Results { get; set; }
    }
}
