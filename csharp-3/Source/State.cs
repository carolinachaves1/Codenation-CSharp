using Newtonsoft.Json;
using System;

namespace Codenation.Challenge
{
    public class State
    {

        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("acronym")]
        public string Acronym { get; set; }
        [JsonProperty("territorialExtension")]
        public double TerritorialExtension { get; set; }

        public State()
        {
        }

        public State(string name, string acronym)
        {
            this.Name = name;
            this.Acronym = acronym;
        }

        public State(string name, string acronym, double territorialExtension) : this(name, acronym)
        {
            TerritorialExtension = territorialExtension;
        }
    }

}
