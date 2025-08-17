using KhatiMediaTr;
using SimpleBookStore.CQ.Command.BookCommand;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.CQFeature.CommandFeature.Admin
{
    public class AdminCommandFeature : IAdminCommandFeature
    {
        private readonly IMediaTr<AddBooksFromExcel, Task<(bool success, string message, string errorMessage)>> _addBookExcel;
        public AdminCommandFeature(IMediaTr<AddBooksFromExcel, Task<(bool success, string message, string errorMessage)>> addBookExcel)
        {
            _addBookExcel = addBookExcel;
        }
        public async Task<ResponseModel> BookBulkUploadAsync(IFormFile file)
        {
            var result = await _addBookExcel.Send(new object[] { file });
            return new ResponseModel()
            {
                Success = result.success,
                Message = result.message,
                ErrorMessage = result.errorMessage
            };
        }
    }
}
