using Microsoft.AspNetCore.Http;

namespace LeaveManagementApplication.Application.ViewModels.Email;

public class EmailMessageModel
{
    public List<string> To { get; set; }
    public string Subject { get; set; }
    public string Content { get; set; }
    public IFormFileCollection Attachments { get; set; }
}