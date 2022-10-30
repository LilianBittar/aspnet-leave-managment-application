namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Queries;

public class GetLeaveRequestDetailRequest : IRequest<LeaveRequestDto>
{
    public int Id {get; set;}
    
}
