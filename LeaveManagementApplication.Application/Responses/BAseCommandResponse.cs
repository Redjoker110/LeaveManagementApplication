namespace LeaveManagementApplication.Application.Responses;

public class BAseCommandResponse
{
    public int id { get; set; }
    public bool Success { get; set; } = true;
    public string Message { get; set; }

    public List<string> Error { get; set; }
}