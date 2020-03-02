using System.Collections.Generic;
using System.Threading.Tasks;
using Contoso.Domain.Models.ModelsView;

namespace Contoso.Services
{
    public interface IAboutService
    {
        Task<List<EnrollmentDateGroup>> GetEnrollmentDateGroups(); 
    }
}