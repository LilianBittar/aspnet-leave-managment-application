namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;

 public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto LeaveTypeDto { get; set; }

    }
