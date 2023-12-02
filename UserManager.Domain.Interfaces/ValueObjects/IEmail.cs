namespace Domain.ValueObjects;

public interface IEmail
{
    public string Address { get;  set; }
    bool IsValidEmail(string address);
    bool ContainsDomain(string address);
}