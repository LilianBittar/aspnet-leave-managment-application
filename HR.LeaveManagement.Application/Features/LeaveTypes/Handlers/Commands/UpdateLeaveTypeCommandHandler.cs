
using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Exceptions;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
       
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository leaveTypeRepository;
        public UpdateLeaveTypeCommandHandler( IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
           
            this._mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator = new UpdateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.LeaveTypeDto);

        if (!validationResult.IsValid) throw new ValidationException(validationResult);

        var leaveType = await leaveTypeRepository.Get(request.LeaveTypeDto.Id);
            _mapper.Map(request.LeaveTypeDto, leaveType);
            await leaveTypeRepository.Update(leaveType);
            return Unit.Value;
        }
    }
