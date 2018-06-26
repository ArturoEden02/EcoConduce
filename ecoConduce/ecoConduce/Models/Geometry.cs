namespace ecoConduce.Models
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Geometry
    {
        [JsonProperty(PropertyName = "coordinates")]
        public List<double> Coordinates { get; set; }
    }
}
