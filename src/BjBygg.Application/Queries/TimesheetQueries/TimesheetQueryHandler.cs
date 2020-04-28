﻿using AutoMapper;
using BjBygg.Application.Shared;
using CleanArchitecture.Core.Entities;
using CleanArchitecture.Infrastructure.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TimeZoneConverter;

namespace BjBygg.Application.Queries.TimesheetQueries
{
    public class TimesheetQueryHandler : IRequestHandler<TimesheetQuery, IEnumerable<TimesheetDto>>
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public TimesheetQueryHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<IEnumerable<TimesheetDto>> Handle(TimesheetQuery request, CancellationToken cancellationToken)
        {
            var query = _dbContext.Set<Timesheet>().AsQueryable();

            if(request.MissionId != null)
                query = query.Where(x => x.MissionId == request.MissionId);

            if (request.UserName != null)
                query = query.Where(x => x.UserName == request.UserName);

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var startDate = dtDateTime.AddSeconds(request.StartDate ?? 0).ToLocalTime();

            if(request.EndDate == null)
                query = query.Where(x => x.StartTime.Date >= startDate.Date);
            else
            {
                var endDate = dtDateTime.AddSeconds(request.EndDate ?? 0).ToLocalTime();
                query = query.Where(x => x.StartTime.Date >= startDate.Date && x.StartTime.Date <= endDate.Date);
            }
           

            return _mapper.Map<IEnumerable<TimesheetDto>>(await query.ToListAsync());
        }

    }
}