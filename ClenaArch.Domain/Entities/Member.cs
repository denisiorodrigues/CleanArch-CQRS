using ClenaArch.Domain.Validation;
using System.Text.Json.Serialization;

namespace ClenaArch.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gender { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member(string? firstName, string? lastName, string? gender, string? email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);

        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = active;
    }

    public Member()
    {
        
    }

    [JsonConstructor]
    public Member(int id, string? firstName, string? lastName, string? gender, string? email, bool? active)
    {
        DomainValidation.When(id < 0, "Invalid Id, must be greater than 0");
        Id = id;
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    public void Update(string firstName, string lastName, string gender, string email, bool? active)
    {
        ValidateDomain(firstName, lastName, gender, email, active);
    }

    private void ValidateDomain(string firstName, string lastName, string gender, string email, bool? active)
    {
        DomainValidation.When(string.IsNullOrEmpty(firstName), "First Name is required");
        DomainValidation.When(lastName.Length < 3, "Invalid First Name, too short, minimum 3 caracters");
        
        DomainValidation.When(string.IsNullOrEmpty(lastName), "Last Name is required");
        DomainValidation.When(lastName.Length < 3, "Invalid Last Name, too short, minimum 3 caracters");
        
        DomainValidation.When(string.IsNullOrEmpty(gender), "Gender is required");
        
        DomainValidation.When(string.IsNullOrEmpty(email), "Email is required");
        DomainValidation.When(email.Length > 250, "Invalid E-mail, too long, maximum 250 characters");
        DomainValidation.When(email.Length < 6, "Invalid E-mail, too short, minimum 6 characters");

        DomainValidation.When(!active.HasValue, "Must define activity");

        
        FirstName = firstName;
        LastName = lastName;
        Gender = gender;
        Email = email;
        IsActive = active;
    }
}
