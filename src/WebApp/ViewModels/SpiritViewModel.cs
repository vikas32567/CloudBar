using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;
using WebApp.Context;

namespace WebApp.ViewModels
{
    public class SpiritViewModel
    {
        public long Id { get; set; }

        [JsonProperty("name")]
        [MaxLength(100, ErrorMessage = "{0} should not be longer than {1} characters")]
        [MinLength(5, ErrorMessage = "{0} should be longer than {1} characters")]
        public string Name { get; set; }

        [JsonProperty("price")]
        [Required(ErrorMessage = "Enter the spirit's price.")]
        [Range(10, 500, ErrorMessage = "Accepting only spirits in price range INR 10 - 500")]
        public decimal Price { get; set; }

        [JsonProperty("stock")]
        public int Stock { get; set; }


        public SpiritViewModel()
        {
            
        }

        public SpiritViewModel(Spirit spirit)
        {
            Id = spirit.Id;
            Name = spirit.Name;
            Price = spirit.Price;
            Stock = spirit.Stock;
        }

        public Spirit ToSpirit()
        {
            var spirit = new Spirit();

            spirit.Id = Id;
            spirit.Name = Name;
            spirit.Price = Price;
            spirit.Stock = Stock;

            return spirit;
        }

    }
}