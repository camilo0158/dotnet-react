using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Contoso.Data;
using System.Threading.Tasks;
using Contoso.Domain.Models.ModelsView;

namespace Contoso.Services.Impl
{
    public class AboutService : IAboutService
    {
        private readonly SchoolContext _context;

        public AboutService(SchoolContext context)
        {
            _context = context;
        }

        public async Task<List<EnrollmentDateGroup>> GetEnrollmentDateGroups()
        {
            IQueryable<EnrollmentDateGroup> data = 
                from student in _context.Students
                group student by student.EnrollmentDate into dateGroup
                select new EnrollmentDateGroup()
                {
                    EnrollmentDate = dateGroup.Key,
                    StudentsCount = dateGroup.Count()
                };

            return await data.AsNoTracking().ToListAsync();
        }
    }
}