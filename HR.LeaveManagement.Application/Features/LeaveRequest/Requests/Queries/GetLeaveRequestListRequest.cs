using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Queries;

  public class GetLeaveRequestListRequest : IRequest<List<LeaveRequestListDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }