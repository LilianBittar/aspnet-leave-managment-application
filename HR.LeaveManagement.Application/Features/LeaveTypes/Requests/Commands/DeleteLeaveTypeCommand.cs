using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;

 public class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }