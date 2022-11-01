using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType;
using HR.LeaveManagment.Application.Features.LeaveType.Requests.Queries;
using MediatR;

namespace HR.LeaveManagment.Application.Features.LeaveTypes.Handlers.Queries;

public class GetLeaveTypeListRequestHandler : IRequestHandler<GetLeaveTypeListRequestHandler, List<LeaveTypeDto>>
{

    private readonly ILeaveTypeRepository _leaveTypeRepository;
    private readonly IMapper _mapper;

    public GetLeaveTypeListRequestHandler(ILeaveTypeRepository leaveTypeRepository, IMapper mapper)
    {
        this._leaveTypeRepository = leaveTypeRepository;
        this._mapper = mapper;
    }
  
    public async Task<List<LeaveTypeDto>> Handle(GetLeaveTypeListRequestHandler request, CancellationToken cancellationToken)
    {
         var LeaveTypes = await _leaveTypeRepository.GetAllAsync();
        return _mapper.Map<List<LeaveTypeDto>>(LeaveTypes);
    }
}
