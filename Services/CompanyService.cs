public class CompanyService
{
    private readonly IConfiguration _config;
    public CompanyService(IConfiguration configuration)
    {
        _config = configuration;
    }

    public string GetMaxStaffCompanyName(List<Company> companies)
    {
        string maxStaffName = "";
        int staffNum = 0;
        int oldStaffNum = 0;
        foreach (var company in companies)
        {
            staffNum = int.Parse(company.Staff);
            maxStaffName = (oldStaffNum > staffNum) ?  maxStaffName: company.Name ;
            oldStaffNum = staffNum;
        }
        return maxStaffName;
    }
}
