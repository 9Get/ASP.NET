using System.ComponentModel.DataAnnotations;

namespace LR10.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "First name and last name are required")]
        public string? Initials { get; set; }
        [Required(ErrorMessage = "Email is required to fill out")]
        [EmailAddress(ErrorMessage = "Invalid email")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "The preferred consultation date is mandatory")]
        [FutureDate(ErrorMessage = "The preferred consultation date must be in the future")]
        [NonWeekendDay(ErrorMessage = "The desired consultation date cannot be on a weekend")]
        public DateTime? ConsultationDate { get; set; }
        [Required(ErrorMessage = "Choose a product for consultation")]
        [ProductNotAllowedOnMonday(ErrorMessage = "Product cannot be 'Basics' when ConsultationDate is Monday")]
        public string? Product { get; set; }

        public override string ToString()
        {
            return $"Initials: {Initials}.\nEmail: {Email}.\nConsultation date: {ConsultationDate}.\nChosen product: {Product}";
        }
    }

    public class FutureDateAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            return dt.Date > DateTime.Now.Date;
        }
    }

    public class NonWeekendDayAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            DateTime dt = (DateTime)value;
            return dt.DayOfWeek != DayOfWeek.Saturday && dt.DayOfWeek != DayOfWeek.Sunday;
        }
    }

    public class ProductNotAllowedOnMondayAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.ConsultationDate.HasValue && customer.ConsultationDate.Value.DayOfWeek == DayOfWeek.Monday)
            {
                if (value != null && value.ToString().Equals("Основи", StringComparison.OrdinalIgnoreCase))
                {
                    return new ValidationResult("Product cannot be 'Basics' when ConsultationDate is Monday");
                }
            }

            return ValidationResult.Success;
        }
    }
}