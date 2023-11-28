using System.Net.Mail;
using Domain.ValueObjects;

namespace UserManager.Domain.ValueObjects;

public class Email : IEmail
{
    public string Address { get; set; }

    public Email(string address)
    {
        if (string.IsNullOrWhiteSpace(address) || !IsValidEmail(address))
        {
            throw new ArgumentException("Invalid email address.");
        }

        Address = address;
    }

    public bool IsValidEmail(string address)
    {
        try
        {
            var mailAddress = new MailAddress(address);
            return mailAddress.Address == address && ContainsDomain(address);
        }
        catch
        {
            return false;
        }
    }

    public bool ContainsDomain(string address)
    {
        var domainPart = address.Split('@').LastOrDefault();
        return domainPart!.Contains('.');
    }
}