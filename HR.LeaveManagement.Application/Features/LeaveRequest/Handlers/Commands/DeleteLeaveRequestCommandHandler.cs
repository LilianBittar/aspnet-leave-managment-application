using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Application.Features.LeaveRequest.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Handlers.Commands;

public class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
{

    private readonly IMapper mapper;
    private readonly ILeaveRequestRepository leaveRequestRepository;

    public DeleteLeaveRequestCommandHandler(IMapper mapper, ILeaveRequestRepository leaveRequestRepository)
    {
        this.mapper = mapper;
        this.leaveRequestRepository = leaveRequestRepository;
    }

    public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
    {
        var leaveRequest = await leaveRequestRepository.Get(request.Id);

        if (leaveRequest == null) throw new NotFoundException(nameof(LeaveRequest), request.Id);

        await leaveRequestRepository.Delete(leaveRequest);
        return Unit.Value;
    }
}
