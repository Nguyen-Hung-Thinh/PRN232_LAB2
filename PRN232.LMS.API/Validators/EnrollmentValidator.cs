using FluentValidation;
using PRN232.LMS.API.Models.Requests;

namespace PRN232.LMS.API.Validators;

public class CreateEnrollmentRequestValidator : AbstractValidator<CreateEnrollmentRequest>
{
    public CreateEnrollmentRequestValidator()
    {
        RuleFor(x => x.StudentId)
            .GreaterThan(0).WithMessage("StudentId must be a positive integer.");

        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage("CourseId must be a positive integer.");

        RuleFor(x => x.EnrollDate)
            .NotEmpty().WithMessage("EnrollDate is required.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.")
            .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");
    }
}

public class UpdateEnrollmentRequestValidator : AbstractValidator<UpdateEnrollmentRequest>
{
    public UpdateEnrollmentRequestValidator()
    {
        RuleFor(x => x.StudentId)
            .GreaterThan(0).WithMessage("StudentId must be a positive integer.");

        RuleFor(x => x.CourseId)
            .GreaterThan(0).WithMessage("CourseId must be a positive integer.");

        RuleFor(x => x.EnrollDate)
            .NotEmpty().WithMessage("EnrollDate is required.");

        RuleFor(x => x.Status)
            .NotEmpty().WithMessage("Status is required.")
            .MaximumLength(50).WithMessage("Status must not exceed 50 characters.");
    }
}
