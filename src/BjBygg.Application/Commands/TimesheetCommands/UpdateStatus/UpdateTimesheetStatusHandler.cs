using AutoMapper;
using BjBygg.Application.Shared;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Core.Enums;
using CleanArchitecture.Core.Exceptions;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BjBygg.Application.Commands.TimesheetCommands.UpdateStatus
{
    public class UpdateTimesheetStatusHandler : IRequestHandler<UpdateTimesheetStatusCommand, TimesheetDto>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public UpdateTimesheetStatusHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<TimesheetDto> Handle(UpdateTimesheetStatusCommand request, CancellationToken cancellationToken)
        {
            if (request.Status == TimesheetStatus.Open && request.Role != "Leder") //Only allow leaders to change hours to open
                throw new ForbiddenException("Du kan ikke �pne bekreftede timer");

            var timesheet = await _dbContext.Set<Timesheet>().FindAsync(request.Id);

            if (timesheet.UserName != request.UserName && request.Role != "Leder") //Only allow edit of own hours, except leader
                throw new UnauthorizedException("Time tilh�rer ikke bruker");

            timesheet.Status = request.Status;

            _dbContext.Entry(timesheet).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();

            return _mapper.Map<TimesheetDto>(timesheet);
        }
    }
}