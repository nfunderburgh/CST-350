using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Act_2.Models
{
    public class MovieModel
    {
        public int Id { get; set; }
        [DisplayName("Movie Name")]
        public string Title { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }
        [DisplayName("Air Time")]
        public DateTime AirDate { get; set; }

        public MovieModel(int id, string title, decimal price, DateTime airDate)
        {
            Id = id;
            Title = title;
            Price = price;
            AirDate = airDate;
        }

        public MovieModel()
        {

        }
    }
}
