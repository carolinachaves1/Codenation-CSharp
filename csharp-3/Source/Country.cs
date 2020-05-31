using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Codenation.Challenge
{
    public class Country
    {   
        
        public State[] Top10StatesByArea()
        {
            State[] top10StatesByArea = GenerateListOfCountry().Take(10).ToArray();

            return top10StatesByArea;
        }

        public List<State> GenerateListOfCountry()
        {
            const string path = @"C:\Users\bzzca\Codenation\csharp-3\Source\states.json";

            List<State> listOfStates = JsonConvert.DeserializeObject<List<State>>(File.ReadAllText(path, Encoding.UTF8));

            var orderedListOfStates = listOfStates.OrderByDescending(e => e.TerritorialExtension);
           
            return orderedListOfStates.ToList();
        }
    }
}
