using System.ComponentModel.DataAnnotations;

namespace MonolithDS.Domain.Shopping.Shipping
{
    public class ShippingDetails
    {
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }
    }
}
