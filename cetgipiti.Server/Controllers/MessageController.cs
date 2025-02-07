using cetgipiti.Server.Data.Entities;
using cetgipiti.Server.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.SemanticKernel;

namespace cetgipiti.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        [HttpPost("ask")]
        public async Task<IActionResult> Ask([FromBody] RequestMessage request)
        {
            if (string.IsNullOrWhiteSpace(request.MessageRequest))
                return BadRequest("Question cannot be empty.");

            var response = await _messageService.MessageResponse(request);
            return Ok(new { response });
        }
    }
}
