using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.AI;

namespace ChatBotAPI
{
    [ApiController]
    [Route("api/chat")]
    public class ChatController : ControllerBase
    {
        private readonly ChatService _chatService;
        private IChatClient _chatClient;

        public ChatController(ChatService chatService)
        {
            _chatService = chatService;
            _chatClient = new OllamaChatClient(new Uri("http://localhost:11434/"), "qwen2.5-coder:3b");
            Console.WriteLine("ChatClient initialized");
        }

        [HttpPost("send")]
        // Note Question: Different between the async Task and GetBotResponse().result ? 
        public async Task<IActionResult> SendMessage([FromBody] Message userMessage)
        {
            if (string.IsNullOrWhiteSpace(userMessage.Text))
                return BadRequest("Message cannot be empty.");

            // Add user message to history
            var userMsg = _chatService.AddMessage(ChatRole.User, userMessage.Text);

            // Generate bot response
            string botReply = await GetBotResponse(_chatService.GetMessages());
            var botMsg = _chatService.AddMessage(ChatRole.System, botReply);
            Console.WriteLine("Bot reply: " + botReply);
            return Ok(new { user = userMsg, bot = botMsg });
        }

        [HttpGet("history")]
        public IActionResult GetMessageHistory([FromQuery] string? role = null)
        {
            if (!string.IsNullOrWhiteSpace(role))
            {
                if (role.Equals("user", StringComparison.OrdinalIgnoreCase))
                {
                    return Ok(_chatService.FilterMessagesByRole(ChatRole.User));
                }
                else if (role.Equals("system", StringComparison.OrdinalIgnoreCase))
                {
                    return Ok(_chatService.FilterMessagesByRole(ChatRole.System));
                }
                else
                {
                    return BadRequest("Invalid role. Use 'user' or 'system'.");
                }
            }
            return Ok(_chatService.GetMessages());
        }

        //Processing the response from the bot and adding to the chat history.
        private async Task<string> GetBotResponse(List<ChatMessage> chatHistory)
        {
            var response = "";
            await foreach (var item in
                _chatClient.GetStreamingResponseAsync(chatHistory))
            {
                Console.Write(item.Text);
                response += item.Text;
            }
            return response;
        }
    }
}
