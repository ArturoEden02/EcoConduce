namespace ecoConduce.Models
{
    using Newtonsoft.Json;

    public class Scooter
    {
        #region Properties

        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "geometry")]
        public Geometry Geometry { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Properties Properties { get; set; }

        #endregion
    }
}
