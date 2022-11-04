using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

 public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
    
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public DeleteLeaveTypeCommandHandler(IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            
            this._mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await leaveTypeRepository.Get(request.Id);

            if (leaveType == null) throw new NotFoundException(nameof(LeaveType), request.Id);

            await leaveTypeRepository.Delete(leaveType);
            return Unit.Value;
        }
    }
