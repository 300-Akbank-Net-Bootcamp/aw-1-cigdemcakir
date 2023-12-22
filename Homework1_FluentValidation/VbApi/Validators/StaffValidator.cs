using FluentValidation;
using VbApi.Controllers;
using VbApi.Models;

namespace VbApi.Validators;

public class StaffValidator : AbstractValidator<Staff>
{
    public StaffValidator()
    {
        RuleFor(staff => staff.Name).ValidName();
        
        RuleFor(staff => staff.Email).ValidEmail();
        
        RuleFor(staff => staff.Phone).ValidPhone();

        RuleFor(staff => staff.HourlySalary)
            .InclusiveBetween(30, 400).WithMessage("Hourly salary must be between 30 and 400.");

    }
}