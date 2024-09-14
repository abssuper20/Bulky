using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models
{
    public class Company
    {
        public int Id { get; set; }
        [Required]
        public string name { get; set; }
        public string? streetAddress { get; set; }
        public string? city { get; set; }
        public string? state { get; set; }
        public string? postalCode { get; set; }
        public string? phoneNumber { get; set; }
    }
}
