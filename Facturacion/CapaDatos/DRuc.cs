using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace CapaDatos
{
    public class DRuc
    {
        public string Ruc { get; set; }
        [JsonProperty("RAZÓN SOCIAL")]
        public string RazonSocial { get; set; }
    }
}
