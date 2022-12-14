using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Persistence;
using HR.LeaveManagement.Application.DTOs.LeaveAllocation.Validators;
using HR.LeaveManagement.Application.Features.LeaveAllocation.Requests.Commands;
using HR.LeaveManagement.Application.Response;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveAllocation.Handlers.Commands;

 public class CreateLeaveAllocationCommandHandler : IRequestHandler<CreateLeaveAllocationCommand, BaseCommandResponse>
    {
        private readonly IMapper mapper;
        private readonly ILeaveAllocationRepository leaveAllocationRepository;
        private readonly ILeaveTypeRepository leaveTypeRepository;

        public CreateLeaveAllocationCommandHandler(IMapper mapper, ILeaveAllocationRepository leaveAllocationRepository, ILeaveTypeRepository leaveTypeRepository)
    {
        this.mapper = mapper;
        this.leaveAllocationRepository = leaveAllocationRepository;
        this.leaveTypeRepository = leaveTypeRepository;
    }

        public async Task<BaseCommandResponse> Handle(CreateLeaveAllocationCommand request, CancellationToken cancellationToken)
    {
        var response = new BaseCommandResponse();
        var validator = new CreateLeaveAllocationDtoValidator(leaveTypeRepository);
        var validationResult = await validator.ValidateAsync(request.CreateLeaveAllocationDto);

        if (validationResult.IsValid)
        {
            var leaveAllocation = mapper.Map<HR.LeaveManagement.Domain.LeaveAllocation>(request.CreateLeaveAllocationDto);
            leaveAllocation = await leaveAllocationRepository.Add(leaveAllocation);

            response.Id = leaveAllocation.Id;
            response.Success = true;
            response.Message = "Allocations Successful";
        }
        else
        {
            response.Success = false;
            response.Message = "Allocations Failed!";
            response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
        }
        return response;
    }
    }
