namespace RequestManagementSystem.Application.Helper.HistoryDescriptions;

public class RequestStatusList
{
    public static Dictionary<int, string> status = new Dictionary<int, string>
    {
        { 1, "Open" },
        { 2, "In Execution" },
        { 3, "Rejected" },
        { 4, "Waiting" },
        { 5, "Approved" },
        { 6, "Close" }
    };

}
