using System.Collections.Generic;
using System.Threading.Tasks;
using Contoso.Domain.Models;

namespace Contoso.Services
{
    public interface IStudentsService
    {
        Task<List<Student>> GetStudents();
        Task<List<Student>> GetStudentsOrder(string sortOrder, string currentFilter, string searchString, int? pageIndex);
        Task<Student> GetStudent(int id);
        Task<Student> CreateStudent(Student student);
        Task UpdateStudent(int id, Student student);
        Task removeStudent(int id);
    }
}