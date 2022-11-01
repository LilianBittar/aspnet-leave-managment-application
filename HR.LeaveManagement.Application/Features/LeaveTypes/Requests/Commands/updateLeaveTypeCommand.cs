using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;

 public class UpdateLeaveTypeCommand: IRequest
    {
        public int Id { get; set; }
    }