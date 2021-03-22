using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookiFy.Data.Models
{
    public class Order
    {
        [BindNever]
        public int OrderId { get; set; }
        public List<OrderDetail> OrderLines { get; set; }
        [Display(Name = "FirstName")]
        [StringLength(50)]
        [Required(ErrorMessage = "ITS REQUIRED")]
        public string FirstName { get; set; }
        [Display(Name = "LastName")]
        [StringLength(50)]
        [Required(ErrorMessage = "ITS REQUIRED")]
        public string LastName { get; set; }
        [Display(Name = "PhoneNumber")]

        [Required(ErrorMessage = "ITS REQUIRED")]
        public long PhoneNumber { get; set; }
        public int OrderTotal { get; set; }
        public DateTime OrderPlaced { get; set; }
    }
}
