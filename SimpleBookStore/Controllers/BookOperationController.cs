using Microsoft.AspNetCore.Mvc;
using SimpleBookStore.CQFeature.CommandFeature.Admin;
using SimpleBookStore.CustomFiltering;

namespace SimpleBookStore.Controllers
{
    [ApiController]
    [AuthorizationFilter("SuperAdmin")]
    [Route("api/[controller]/[action]")]
    public class BookOperationController : ControllerBase
    {
        private readonly IAdminCommandFeature _adminCommandFeature;
        public BookOperationController(IAdminCommandFeature adminCommandFeature)
        {
            _adminCommandFeature = adminCommandFeature;
        }

        [HttpPost]
        public async Task<IActionResult> BookBulkUpload(IFormFile file)
        {
            if (!ModelState.IsValid)
                return BadRequest(new { Errors = ModelState.Values.SelectMany(v => v.Errors) });

            var result = await _adminCommandFeature.BookBulkUploadAsync(file);
            if (!result.Success)
                return BadRequest(result);
            return Ok(result);
        }
    }
}
