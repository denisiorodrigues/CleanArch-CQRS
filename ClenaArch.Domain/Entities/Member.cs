using ClenaArch.Domain.Validation;
using System.Text.Json.Serialization;

namespace ClenaArch.Domain.Entities;

public sealed class Member : Entity
{
    public string? FirstName { get; private set; }
    public string? LastName { get; private set; }
    public string? Gander { get; private set; }
    public string? Email { get; private set; }
    public bool? IsActive { get; private set; }

    public Member(string? firstName, string? lastName, string? gander, string? email, bool isActive)
    {
        ValidateDomain();

        FirstName = firstName;
        LastName = lastName;
        Gander = gander;
        Email = email;
        IsActive = isActive;
    }

    public Member()
    {
        
    }

    [JsonConstructor]
    public Member(int id, string? firstName, string? lastName, string? gander, string? email, bool isActive)
    {
        DomainValidation.When(id < 0, "Invalid Id, must be greater than 0");
        Id = id;
        FirstName = firstName;
        LastName = lastName;
        Gander = gander;
        Email = email;
        IsActive = isActive;

        ValidateDomain();
    }

    private void ValidateDomain()
    {
        DomainValidation.When(string.IsNullOrEmpty(FirstName), "First Name is required");
        DomainValidation.When(FirstName.Length < 3, "Invalid First Name, too short, minimum 3 caracters");
        
        DomainValidation.When(string.IsNullOrEmpty(LastName), "Last Name is required");
        DomainValidation.When(LastName.Length < 3, "Invalid Last Name, too short, minimum 3 caracters");
        
        DomainValidation.When(string.IsNullOrEmpty(Gander), "Gander is required");
        
        DomainValidation.When(string.IsNullOrEmpty(Email), "Email is required");
        DomainValidation.When(Email.Length > 250, "Invalid E-mail, too long, maximum 250 characters");
        DomainValidation.When(Email.Length < 6, "Invalid E-mail, too short, minimum 6 characters");

        DomainValidation.When(!IsActive.HasValue, "Must define activity");
    }
}
