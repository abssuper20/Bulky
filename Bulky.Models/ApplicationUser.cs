using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Name { get; set; }
        public string? streetAddress { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? postalCode { get; set; }
    }
}
