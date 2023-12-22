using FluentValidation;
using VbApi.Controllers;
using VbApi.Models;

namespace VbApi.Validators;

public class EmployeeValidator : AbstractValidator<Employee>
{
    public EmployeeValidator()
    {
        RuleFor(staff => staff.Name).ValidName();
        
        RuleFor(staff => staff.Email).ValidEmail();
        
        RuleFor(staff => staff.Phone).ValidPhone();

        RuleFor(employee => employee.DateOfBirth)
            .Must(date => date <= DateTime.Today)
            .WithMessage("Birthdate cannot be today or in the future.");
        
        RuleFor(employee => employee.DateOfBirth)
            .Must(ValidateAge)
            .When(employee => employee.DateOfBirth <= DateTime.Today)
            .WithMessage("Age must be 65 or less.");

        RuleFor(employee => employee.HourlySalary)
            .Must((employee, salary) => ValidateSalary(employee, salary))
            .WithMessage("Minimum hourly salary is not valid.");
    }

    private bool ValidateAge(DateTime date)
    {
        var age = DateTime.Today.Year - date.Year;
        
        if (date.Date > DateTime.Today.AddYears(-age)) age--;
        
        return age <= 65;
    }

    private bool ValidateSalary(Employee employee, double salary)
    {
        var minJuniorSalary = 50;
        
        var minSeniorSalary = 200;
        
        var isSenior = DateTime.Today.Year - employee.DateOfBirth.Year > 30;

        return isSenior ? salary >= minSeniorSalary : salary >= minJuniorSalary;
    }
}