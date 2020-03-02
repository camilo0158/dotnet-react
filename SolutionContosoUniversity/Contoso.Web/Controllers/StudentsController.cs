using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Contoso.Services.Impl;
using Contoso.Services;
using Contoso.Domain.Models;

namespace Contoso.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentsService _studentService;

        public StudentsController(IStudentsService studentsService)
        {
            _studentService = studentsService;
        }

        [HttpGet]
        public async  Task<ActionResult<List<Student>>> Get(){           
            return await _studentService.GetStudents();
        }
           

        
        [HttpGet("{sortOrder}/{currentFilter}/{pageIndex}")]
        public async Task<ActionResult<List<Student>>> Get(string sortOrder, string currentFilter, string searchString, int? pageIndex) =>
            await _studentService.GetStudentsOrder(sortOrder, currentFilter, searchString, pageIndex);
        

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = await _studentService.GetStudent(id);
            if(student == null)
            {
                return NotFound();
            }
            return student;
        }
        
        [HttpPost]
        public async Task<ActionResult<Student>> Create(Student student)
        {
            var emptyStudent = new Student();
            if(await TryUpdateModelAsync<Student>(emptyStudent,
               "student",
               s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
            {
                await _studentService.CreateStudent(student);  
            }
                      
            return student;
        }
        
        [HttpPut]
        public async Task<ActionResult> Update(Student student)
        {
            Student studentToUpdate = await _studentService.GetStudent(student.ID);
            if(studentToUpdate == null){
                return NotFound();
            }            
            await _studentService.UpdateStudent(student.ID, student);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            Student student = await _studentService.GetStudent(id);

            if(student == null)
            {
                return NotFound();
            }
            await _studentService.removeStudent(id);
            return NoContent();
        }
    }
}