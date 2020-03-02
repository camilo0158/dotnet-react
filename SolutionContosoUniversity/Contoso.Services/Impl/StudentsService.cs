using System.Collections.Generic;
using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Contoso.Data;
using Contoso.Domain;
using Contoso.Domain.Models;
using System.Threading.Tasks;

namespace Contoso.Services.Impl
{
    public class StudentsService : IStudentsService
    {
        private readonly SchoolContext _context;

        public StudentsService(SchoolContext context)
        {
            _context = context;
        }

        public string NameSort { get; set; }
        public string DateSort { get; set; }
        public string CurrentFilter { get; set; }
        public string CurrentSort { get; set; }
        public PaginatedList<Student> StudentsPag { get; set; }

        public async Task<Student> CreateStudent(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
            return student;
        }

        public async Task<Student> GetStudent(int id) =>
        //Si se necesitan datos relacionados FirstOfDefault es la mejor opcion
            await _context.Students.Include(s => s.Enrollments)

                                    .ThenInclude(e => e.Course)
                                    .AsNoTracking()
                                    .FirstOrDefaultAsync(s => s.ID == id);

        public async Task<List<Student>> GetStudentsOrder(string sortOrder, string currentFilter, string searchString, int? pageIndex)
        {
            CurrentSort = sortOrder;
            NameSort = String.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            DateSort = sortOrder == "Date" ? "date_desc" : "Date";

            if(searchString != null)
            {
                pageIndex = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            CurrentFilter = searchString;

            IQueryable<Student> studentsIQ = from s in _context.Students
                                             select s;
                                             
            if (!String.IsNullOrEmpty(CurrentFilter))
            {
                studentsIQ = studentsIQ.Where(s => s.LastName.ToUpper().Contains(CurrentFilter.ToUpper()) ||
                     s.FirstMidName.ToUpper().Contains(CurrentFilter.ToUpper()));
            }

            switch (sortOrder)
            {
                case "name_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.LastName);
                    break;
                case "Date":
                    studentsIQ = studentsIQ.OrderBy(s => s.EnrollmentDate);
                    break;
                case "date_desc":
                    studentsIQ = studentsIQ.OrderByDescending(s => s.EnrollmentDate);
                    break;
                default:
                    studentsIQ = studentsIQ.OrderBy(s => s.LastName);
                    break;
            }
            int pageSize = 3;
            StudentsPag = await PaginatedList<Student>.CreateAsync(studentsIQ.AsNoTracking(), pageIndex ?? 1, pageSize);
            return StudentsPag;
        }

        public async Task<List<Student>> GetStudents() =>
            await _context.Students.AsNoTracking().ToListAsync();

        public async Task removeStudent(int id)
        {
            Student studentToRemove = await _context.Students.FindAsync(id);
            _context.Students.Remove(studentToRemove);
            await _context.SaveChangesAsync();

        }

        public async Task UpdateStudent(int id, Student student)
        {
            Student studentToUpdate = await _context.Students.FindAsync(id);
            studentToUpdate.FirstMidName = student.FirstMidName;
            studentToUpdate.LastName = student.LastName;
            studentToUpdate.EnrollmentDate = student.EnrollmentDate;
            _context.Students.Update(studentToUpdate);
            await _context.SaveChangesAsync();

        }
    }
}