namespace HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;

 public class CreateLeaveRequestCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveRequestDto LeaveRequestDto { get; set; }

    }
