using Microsoft.AspNetCore.Http;
using SimpleBookStore.DAL.StoreEntity;
using SimpleBookStore.Model.Request;
using SimpleBookStore.Model.Response;

namespace SimpleBookStore.BLL.Services.BookService
{
    public interface IBookService
    {
        Task<List<Book>> GetBookList();
        Task<List<BookInfoResponseModel>> GetBookDetailInfo();
        Task<ResponseModel> BuyBookAsync(BuyBookRequestModel model);
        Task<ResponseModel> ParseBooksFromExcelAsync(IFormFile file);
    }
}
