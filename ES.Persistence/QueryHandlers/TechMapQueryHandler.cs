using ES.Application.Dtos;
using ES.Application.Queries;
using ES.Application.UseCases;
using ES.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ES.Persistence.QueryHandlers
{
    public class TechMapQueryHandler : IHandler<TechMapQuery, IEnumerable<TechMapDto>>
    {
        private readonly EsDbContext _dbContext;

        public TechMapQueryHandler(EsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<TechMapDto>> HandleAsync(TechMapQuery query, CancellationToken cancellation)
        {
            var techMapQuery = _dbContext.Set<TechMap>().AsQueryable(); // составляем SQL запрос SELECT * FROM TechMap

            techMapQuery = techMapQuery.Where(a => a.SupplierId == query.SupplierId && a.State == Domain.EntityState.None);

            var res = await techMapQuery.Select(x => new TechMapDto()
            {
                Id = x.Id,
                SupplierId = x.SupplierId,
                Name = x.Name,
                TechMapJobs = x.TechMapJobs.OrderBy(y => y.JobCompleteDate).Select(y => new TechMapJobsDto()
                {
                    JobName = y.JobName,
                    JobDescription = y.JobDescription,
                    JobDuration = y.JobDuration,
                    JobDependence = y.JobDependence,
                    JobResources = y.JobResources,
                    JobCompleteDate = y.JobCompleteDate,
                    TechMapId = y.TechMapId,
                    Id = y.Id,
                }).ToArray(),
                CriticalPath = new TechMapCriticalPathDto() 
                { 
                    TotalDuration = x.CriticalPath.TotalDuration, 
                    TechMapJobs = x.CriticalPath.TechMapJobs.OrderBy(y => y.Index).Select(y => new TechMapJobsDto() 
                    {
                        JobName = y.JobName,
                        JobDescription = y.JobDescription,
                        JobDuration = y.JobDuration,
                        JobDependence = y.JobDependence,
                        JobResources = y.JobResources,
                        JobCompleteDate = y.JobCompleteDate,
                        TechMapId = y.TechMapId,
                        Id = y.Id,
                    }).ToArray(),
                    TechMapId = x.CriticalPath.TechMapId,
                    Id = x.CriticalPath.Id
                },
            }).GetListPageQuery(query).ToListAsync();



            return res;
        }
    }
}
