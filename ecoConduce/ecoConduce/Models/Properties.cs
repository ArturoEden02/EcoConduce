namespace ecoConduce.Models
{
    using Newtonsoft.Json;
    public class Properties
    {
        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "parent_feature_id")]
        public int ParentFeatureId { get; set; }

        [JsonProperty(PropertyName = "number")]
        public int Number { get; set; }

        [JsonProperty(PropertyName = "power")]
        public int Power { get; set; }

        [JsonProperty(PropertyName = "power_calculated")]
        public bool PowerCalculated { get; set; }

        [JsonProperty(PropertyName = "range")]
        public int Range { get; set; }

        [JsonProperty(PropertyName = "distance")]
        public int Distance { get; set; }

        [JsonProperty(PropertyName = "charging_enabled")]
        public bool ChargingEnabled { get; set; }
    }
}
