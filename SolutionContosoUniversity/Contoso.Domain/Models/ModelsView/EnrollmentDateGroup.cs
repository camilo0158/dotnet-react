using System;
using System.ComponentModel.DataAnnotations;

namespace Contoso.Domain.Models.ModelsView
{
    public class EnrollmentDateGroup
    {
        [DataType(DataType.Date)]
        public DateTime? EnrollmentDate { get; set; }        
        public int StudentsCount { get; set; }        
    }
}