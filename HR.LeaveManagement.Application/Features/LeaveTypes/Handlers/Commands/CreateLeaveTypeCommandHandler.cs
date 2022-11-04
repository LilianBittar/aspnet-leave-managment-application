using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveType.Validators;
using HR.LeaveManagement.Application.Response;
using HR.LeaveManagement.Domain;
using HR.LeaveManagment.Application.Features.LeaveTypes.Requests.Commands;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveTypes.Handlers.Commands;

 public class CreateLeaveTypeCommandHandler : IRequestHandler<CreateLeaveTypeCommand, BaseCommandResponse>
    {
      
        private readonly IMapper _mapper;
       private readonly ILeaveTypeRepository leaveTypeRepository;
        public CreateLeaveTypeCommandHandler( IMapper mapper, ILeaveTypeRepository leaveTypeRepository)
        {
            
            this._mapper = mapper;
            this.leaveTypeRepository = leaveTypeRepository;
        }

        public async Task<BaseCommandResponse> Handle(CreateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveTypeDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateLeaveTypeDto);

        if (validationResult.IsValid)
        {
            var leaveType = _mapper.Map<LeaveType>(request.CreateLeaveTypeDto);
            leaveType = await leaveTypeRepository.Add(leaveType);

            response.Success = true;
            response.Message = "Creation Successful";
            response.Id = leaveType.Id;
        }
        else
        {
            response.Success = false;
            response.Message = "Creation Failed";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        return response;
        }
    }