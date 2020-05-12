﻿using AutoMapper;
using BjBygg.Application.Shared;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BjBygg.Application.Queries.DbSyncQueries
{
    public abstract class DbSyncHandler<T, Q, R> : IRequestHandler<Q, DbSyncResponse<R>>
        where T : BaseEntity where Q : DbSyncQuery<R> where R : DbSyncDto
    {
        private readonly AppDbContext _dbContext;
        private readonly IMapper _mapper;

        public DbSyncHandler(AppDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<DbSyncResponse<R>> Handle(Q request, CancellationToken cancellationToken)
        {
            List<T> entities;
            List<int> deletedEntities = new List<int>();

            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            var date = dtDateTime.AddSeconds(request.Timestamp ?? 0).ToLocalTime();
            var minDate = DateTime.Now.AddYears(-5);

            IQueryable<T> query = _dbContext.Set<T>();

            Boolean initialCall = (DateTime.Compare(date, minDate) < 0); //If last updated resource is older than 5 years

            if (initialCall)
                query = query.Where(x => DateTime.Compare(x.CreatedAt, minDate) > 0);
            else
            {
                query = query.IgnoreQueryFilters(); //Include deleted property to check for deleted entities
                query = query.Where(x => DateTime.Compare(x.UpdatedAt, date) > 0);
            }

            entities = await query.ToListAsync();

            if (!initialCall)
            {
                deletedEntities = entities.Where(x => x.Deleted == true).Select(x => x.Id).ToList(); //Add ids from deleted entities
                entities = entities.Where(x => x.Deleted == false).ToList(); //Remove deleted entities
            }

            return new DbSyncResponse<R>() {
                Entities = _mapper.Map<IEnumerable<R>>(entities),
                DeletedEntities = deletedEntities,
                Timestamp = DateTimeOffset.UtcNow.ToLocalTime().ToUnixTimeSeconds(),
            };
        }
    }
}
