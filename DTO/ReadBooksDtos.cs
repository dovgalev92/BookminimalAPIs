using System.ComponentModel.DataAnnotations;
namespace BookMinAPIs.DTO
{
    public class ReadBooksDtos
    {
        public int BookId {get;set;}
        [Display(Name = "Автор книги")]
        public string Name {get;set;} = string.Empty;
        [Display(Name = "Название книги")]
        public string Title {get;set;} = string.Empty;
        [Display(Name = "Цена")]
        public decimal Price {get;set;}
    }
}