using cetgipiti.Server.Data.Entities;
using cetgipiti.Server.Services.Abstract;
using Microsoft.SemanticKernel;

namespace cetgipiti.Server.Services.Concrete
{
    public class MessageService : IMessageService
    {
        private readonly Kernel _kernel;
        public MessageService(Kernel kernel)
        {
            _kernel = kernel;
        }
        public async Task<ResponseMessage> MessageResponse(RequestMessage requestMessage)
        {
            try
            {
                var response =await _kernel.InvokePromptAsync(requestMessage.MessageRequest!);
                return new ResponseMessage
                {
                    MessageResponse = response.ToString(),
                    MessageDate = DateTime.Now
                };

                 
            }
            catch (Exception ex)
            {

                return (new ResponseMessage
                {
                    MessageResponse = ex.Message,
                    MessageDate = DateTime.Now
                });
            }
           
        }
    }
}
