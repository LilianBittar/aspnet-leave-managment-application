using AutoMapper;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

 public class DeleteLeaveTypeCommandHandler : IRequestHandler<DeleteLeaveTypeCommand>
    {
    
        private readonly IMapper _mapper;

        public DeleteLeaveTypeCommandHandler(IMapper mapper)
        {
            
            _mapper = mapper;
        }

        public async Task<Unit> Handle(DeleteLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var leaveType = await _unitOfWork.LeaveTypeRepository.Get(request.Id);

            if (leaveType == null)
                throw new NotFoundException(nameof(LeaveType), request.Id);

            await _unitOfWork.LeaveTypeRepository.Delete(leaveType);
            await _unitOfWork.Save();

            return Unit.Value;
        }
    }
