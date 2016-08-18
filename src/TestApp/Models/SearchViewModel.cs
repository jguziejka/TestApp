using System.ComponentModel.DataAnnotations;

namespace TestApp.Models
{
    public class SearchViewModel
    {
        [Required]
        [Display(Name = "Address")]
        public string Address { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "Zip Code")]
        [DataType(DataType.PostalCode)]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid Zip Code")]
        public string Zip { get; set; }
        [Display(Name = "Include Rent Estimate?")]
        public bool RentzEstimate { get; set; }
        public SearchResultsModel Results { get; set; }
    }
}
