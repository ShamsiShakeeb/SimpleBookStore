using KhatiExtendedEF.Repositories;
using KhatiExtendedEF.UnitOfWork;
using KhatiMediaTr;
using SimpleBookStore.DAL.LogEntity;
using SimpleBookStore.Model.Request;

namespace SimpleBookStore.CQ.Command.LogCommand
{
    public class AddLogCommand : IEventHandler
    {
        private readonly IRepository<Logs> _repositoryLog;
        private readonly IUnitOfWork<ILogEntity> _logUnitOfWork;
        public AddLogCommand(IRepository<Logs> repositoryLog,
            IUnitOfWork<ILogEntity> logUnitOfWork)
        {
            _repositoryLog = repositoryLog;
            _logUnitOfWork = logUnitOfWork;
        }
        public async Task Handler(LogRequestModel model)
        {
            await _logUnitOfWork.Commit(async () =>
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
            });
        }
    }
}
