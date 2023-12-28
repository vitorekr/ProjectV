namespace ProjectV.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public int CountryId { get; set; } // Chave estrangeira para o país
        public Country? Country { get; set; } // Propriedade de navegação para o país
        public bool IsCapital { get; set; }
    }
}
