using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;

 public class CreateLeaveTypeCommand : IRequest<BaseCommandResponse>
    {
        public CreateLeaveTypeDto CreateLeaveTypeDto { get; set; }

    }
