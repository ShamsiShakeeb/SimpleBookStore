using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.CommandFeature.Admin
{
    public interface IAdminCommandFeature
    {
        Task<ResponseModel> BookBulkUploadAsync(IFormFile file);
    }
}
