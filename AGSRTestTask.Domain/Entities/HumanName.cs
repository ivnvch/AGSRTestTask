
namespace AGSRTestTask.Domain.Entities;

public class HumanName
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string MiddleName { get; set; }
    public string Use { get; set; }
    
    private HumanName(){}
    public HumanName(string use, string lastName, string firstName, string middleName)
    {
        if (string.IsNullOrWhiteSpace(LastName))
            throw new ArgumentException("LastName is required");

        Use = use;
        LastName = lastName;
        MiddleName = middleName;
        FirstName = firstName;


    }
    
}