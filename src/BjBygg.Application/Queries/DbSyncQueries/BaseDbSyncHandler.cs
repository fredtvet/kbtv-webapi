﻿using AutoMapper;
using BjBygg.Application.Shared;
using CleanArchitecture.Core.Exceptions;
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
    public abstract class BaseDbSyncHandler<TQuery, TEntity, TDto> : IRequestHandler<TQuery, DbSyncResponse<TDto>>
        where TQuery : DbSyncQuery<TDto> where TEntity : BaseEntity where TDto : DbSyncDto
    {
        private readonly IMapper _mapper;
        private readonly AppDbContext _dbContext;
        private readonly bool _checkMinDate;

        public BaseDbSyncHandler(AppDbContext dbContext, IMapper mapper, bool checkMinDate = true)
        {
            _mapper = mapper;
            _dbContext = dbContext;
            _checkMinDate = checkMinDate;

            _dbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }
        public async Task<DbSyncResponse<TDto>> Handle(TQuery request, CancellationToken cancellationToken)
        {
            var date = GetDateFromTimestamp(request.Timestamp ?? 0);

            if(_checkMinDate) 
                date = CheckMinSyncDate(date, request.InitialNumberOfMonths ?? 48);

            var isInitial = request.Timestamp == null ? true : false;

            IQueryable<TEntity> query = _dbContext.Set<TEntity>();

            if (!isInitial)
                query = query.IgnoreQueryFilters(); //Include deleted property to check for deleted entities

            query = GetEntitiesLaterThan(date, query);

            query = AppendQuery(query, request);

            return CreateSyncResponse(await query.ToListAsync(), isInitial);
        }

        protected virtual IQueryable<TEntity> AppendQuery(IQueryable<TEntity> query, TQuery request)
        {
            return query;
        }

        private DbSyncResponse<TDto> CreateSyncResponse(IEnumerable<TEntity> entities, bool isInitial)
        {
            List<int> deletedEntities = new List<int>();

            if (!isInitial)
            {
                deletedEntities = entities.Where(x => x.Deleted == true).Select(x => x.Id).ToList(); //Add ids from deleted entities
                entities = entities.Where(x => x.Deleted == false).ToList(); //Remove deleted entities
            }

            return new DbSyncResponse<TDto>(_mapper.Map<IEnumerable<TDto>>(entities), deletedEntities);
        }

        private DateTime CheckMinSyncDate(DateTime date, int maxNumberOfMonths)
        {
            var minDate = DateTime.UtcNow.AddMonths(-maxNumberOfMonths);
            //If date is older than min date, return min date. 
            if (DateTime.Compare(date, minDate) < 0) return minDate;
            else return date;
        }

        private DateTime GetDateFromTimestamp(double timestamp)
        {
            System.DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
            return dtDateTime.AddSeconds(timestamp);
        }

        private IQueryable<T> GetEntitiesLaterThan<T>(DateTime date, IQueryable<T> query) where T : BaseEntity
        {
            return query.Where(x => DateTime.Compare(x.UpdatedAt, date) >= 0);
        }
    }
}
