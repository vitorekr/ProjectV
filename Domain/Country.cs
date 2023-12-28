using System.Text.Json.Serialization;

namespace ProjectV.Domain
{
    public class Country
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public int? CapitalId { get; set; } // Chave estrangeira para a cidade capital
        [JsonIgnore]
        public City? Capital { get; set; }  // Propriedade de navegação para a cidade capital

        public int ContinentId { get; set; } // Chave estrangeira para o continente
        public Continent? Continent { get; set; } // Propriedade de navegação para o continente
    }
}
