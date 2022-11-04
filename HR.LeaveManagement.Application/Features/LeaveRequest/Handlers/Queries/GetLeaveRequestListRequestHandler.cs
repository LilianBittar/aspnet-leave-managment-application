using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveRequest;
using HR.LeaveManagment.Application.Features.LeaveRequest.Requests.Queries;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Queries;

public class GetLeaveRequestListRequestHandler : IRequestHandler<GetLeaveRequestListRequest, List<LeaveRequestListDto>>
{
    private readonly IMapper mapper;
    private readonly ILeaveRequestRepository leaveRequestRepository;

    public GetLeaveRequestListRequestHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        this.mapper = mapper;
        this.leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestListRequest request, CancellationToken cancellationToken)
    {
        var leaveRequests = await leaveRequestRepository.GetLeaveRequestsWithDetails();
        return mapper.Map<List<LeaveRequestListDto>>(leaveRequests);
    }
}