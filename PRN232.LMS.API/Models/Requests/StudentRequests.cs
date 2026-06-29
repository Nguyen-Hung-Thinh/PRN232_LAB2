using System.ComponentModel.DataAnnotations;

namespace PRN232.LMS.API.Models.Requests;

public class CreateStudentRequest
{
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Phone]
    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    [Required]
    [RegularExpression(@"^(SE|CE|IA|AI)\d{5}$",
        ErrorMessage = "StudentCode must match FPT style format like SE19886.")]
    [CustomValidation(typeof(StudentValidationRules), nameof(StudentValidationRules.ValidateFptStyleCode))]
    public string StudentCode { get; set; } = null!;

    [Required]
    public DateTime DateOfBirth { get; set; }
}

public class UpdateStudentRequest
{
    [Required]
    [StringLength(100)]
    public string FullName { get; set; } = null!;

    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;

    [Phone]
    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }
}

public class PatchStudentRequest
{
    [StringLength(100)]
    public string? FullName { get; set; }

    [EmailAddress]
    public string? Email { get; set; }

    [Phone]
    [StringLength(15)]
    public string? PhoneNumber { get; set; }

    public DateTime? DateOfBirth { get; set; }
}

public static class StudentValidationRules
{
    public static ValidationResult ValidateFptStyleCode(string? value, ValidationContext context)
    {
        return !string.IsNullOrWhiteSpace(value) &&
               System.Text.RegularExpressions.Regex.IsMatch(value, @"^(SE|CE|IA|AI)\d{5}$")
            ? ValidationResult.Success!
            : new ValidationResult("StudentCode must match FPT style format like SE19886.");
    }
}

