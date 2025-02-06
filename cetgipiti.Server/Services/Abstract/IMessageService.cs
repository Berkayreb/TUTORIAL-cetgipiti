using cetgipiti.Server.Data.Entities;

namespace cetgipiti.Server.Services.Abstract
{
    public interface IMessageService
    {
        public Task<ResponseMessage> MessageResponse(RequestMessage requestMessage);
    }
}
