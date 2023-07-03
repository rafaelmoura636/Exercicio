using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Questao2
{
    public class ResponsePartidas
    {
        public List<Dictionary<string, object>> Data { get; set; }

        [JsonProperty("total_pages")]
        public int TotalPages { get; set; }

    }
}
