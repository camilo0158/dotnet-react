using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Contoso.Services.Impl;
using Contoso.Services;
using Contoso.Domain.Models.ModelsView;

namespace Contoso.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {
        private readonly IAboutService _aboutService;

        public AboutController(IAboutService aboutService)
        {
            _aboutService = aboutService;
        }   

        [HttpGet]
        public async Task<ActionResult<List<EnrollmentDateGroup>>> Get(){
            return await _aboutService.GetEnrollmentDateGroups();
        }
            
    }
}