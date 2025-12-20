using System.ComponentModel.DataAnnotations;

namespace MauiBlazorApp.Models
{
    /*
     * User Model Class
     * 
     * Demonstrates:  Data Annotations for Validation
     * - Required:  Ensures field is not empty
     * - StringLength: Validates minimum and maximum length
     * - EmailAddress: Validates email format
     * - Range: Validates numeric range
     * - RegularExpression: Custom pattern validation
     * - Url: Validates URL format
     */
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 50 characters")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Age is required")]
        [Range(18, 120, ErrorMessage = "Age must be between 18 and 120")]
        public int Age { get; set; }

        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Url(ErrorMessage = "Invalid URL format")]
        public string? ImageUrl { get; set; }

        [StringLength(200, ErrorMessage = "Address cannot exceed 200 characters")]
        public string? Address { get; set; }

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}