using System.ComponentModel.DataAnnotations;
namespace BookMinAPIs.DTO
{
    public class UpdateBookDtos
    {
        [Required]
        public string Description {get;set;} = string.Empty;
        [Required]
        public decimal Price {get;set;}
    }
}