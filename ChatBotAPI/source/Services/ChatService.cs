using Microsoft.Extensions.AI;
namespace ChatBotAPI
{
    public class ChatService
    {
        private readonly List<ChatMessage> _messages = new();

        public List<ChatMessage> GetMessages() => _messages;

        // Adding new message to the list of messages
        public ChatMessage AddMessage(ChatRole role, string messageContext)
        {
            var message = new ChatMessage(role, messageContext);
            _messages.Add(message);
            return message;
        }

        public List<ChatMessage> FilterMessagesByRole(ChatRole role)
        {
            return _messages.Where(message => message.Role == role).ToList();
        }
    }
}