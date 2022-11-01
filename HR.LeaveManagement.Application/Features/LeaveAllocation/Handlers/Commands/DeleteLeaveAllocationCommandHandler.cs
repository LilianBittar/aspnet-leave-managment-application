using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Contracts.Persistence;
using MediatR;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;

namespace HR.LeaveManagement.Application.Features.LeaveAllocations.Handlers.Commands;

public class DeleteLeaveAllocationCommandHandler : IRequestHandler<DeleteLeaveAllocationCommand>
{
    private readonly IMapper mapper;
    private readonly ILeaveAllocationRepository leaveAllocationRepository;

    public DeleteLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository)
    {
        this.mapper = mapper;
        this.leaveAllocationRepository = leaveAllocationRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var leaveAllocation = await leaveAllocationRepository.Get(request.Id);

        if (leaveAllocation == null) throw new NotFoundException(nameof(LeaveAllocation), request.Id);

        await leaveAllocationRepository.Delete(leaveAllocation);
        return Unit.Value;
    }
}