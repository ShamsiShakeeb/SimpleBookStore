//using SimpleBookStore.DAL.LogEntity;
//using SimpleBookStore.DAL.Repositories.LogRepository;
//using SimpleBookStore.Model.Request;

//namespace SimpleBookStore.BLL.Services.LogService
//{
//    public class LogService : ILogService
//    {
//        private readonly ILogRepository _logRepository;
//        public async Task InsertLog(LogRequestModel logs)
//        {
//            var model = new Logs()
//            {
//                Success = logs.Success,
//                Message = logs.Message,
//                ErrorMessage = logs.ErrorMessage,
//                Createdby = "System",
//                CreatedDate = DateTime.UtcNow.AddHours(6)
//            };
//            await _logRepository.InsertLog(model);
//        }
//    }
//}
