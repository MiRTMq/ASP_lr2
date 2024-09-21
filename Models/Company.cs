
public class Company
{

    public string Name { get; set; } = "Name not set";

    public string Staff { get; set; } = "Staff not set";

    public string CompanyID { get; set; } = "Company ID not set";

    public string NetWorth { get; set; } = "Net worth not set";

    public Company(string Name, IConfiguration config)
    {

        this.Name = Name;
        this.CompanyID = config[$"{Name}:CompanyID"];
        this.Staff = config[$"{Name}:Staff"];
        this.NetWorth = config[$"{Name}:NetWorth"];
    }

    public override string ToString()
    {
        return $"{Name}\nID: {CompanyID}\nstaff: {Staff}\nnet worth: {NetWorth}$";
    }
}
