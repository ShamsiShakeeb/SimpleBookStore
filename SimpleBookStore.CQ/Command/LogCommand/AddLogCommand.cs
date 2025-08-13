using KhatiExtendedEF.Repositories;
using KhatiMediaTr;
using SimpleBookStore.DAL.LogEntity;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.CQ.Command.LogCommand
{
    public class AddLogCommand : IEventHandler
    {
        private readonly IRepository<Logs> _repositoryLog;
        public AddLogCommand(IRepository<Logs> repositoryLog)
        {
            _repositoryLog = repositoryLog;
        }
        public async Task Handler(LogRequestModel model)
        {
            await _repositoryLog.InsertAsync(
                new Logs()
                {
                    Success = model.Success,
                    Message = model.Message,
                    ErrorMessage = model.ErrorMessage,
                    Createdby = "System",
                    CreatedDate = DateTime.UtcNow.AddHours(6)
                });
        }
    }
}
