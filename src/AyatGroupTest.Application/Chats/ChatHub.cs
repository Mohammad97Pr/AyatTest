using Abp.Application.Services;
using Abp.AspNetCore.SignalR.Hubs;
using Abp.Domain.Repositories;
using Abp.RealTime;
using AyatGroupTest.Authorization.Users;
using AyatGroupTest.Conversations;
using AyatGroupTest.Messages;
using AyatGroupTest.Messages.Dtos;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyatGroupTest.Chats
{
    public class ChatHub : AbpCommonHub, IApplicationService
    {
        private readonly IRepository<User, long> _userRepository;
        private readonly IRepository<Message, long> _messageRepository;
        private readonly IRepository<Conversation> _conversationRepository;

        public ChatHub(IOnlineClientManager onlineClientManager,
            IOnlineClientInfoProvider clientInfoProvider,
            IRepository<User, long> userRepository,
            IRepository<Message, long> messageRepository,
            IRepository<Conversation> conversationRepository)
            : base(onlineClientManager, clientInfoProvider)
        {
            _userRepository = userRepository;
            _messageRepository = messageRepository;
            _conversationRepository = conversationRepository;
        }

        public override async Task OnConnectedAsync()
        {
            var userId = base.Context.ConnectionId;
            if (!string.IsNullOrEmpty(userId))
            {
                User user = await _userRepository.GetAsync(long.Parse(userId));
                user.IsOnline = true;
                await _userRepository.UpdateAsync(user);
            }

            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            var userId = base.Context.ConnectionId;
            if (!string.IsNullOrEmpty(userId))
            {
                var user = await _userRepository.GetAsync(long.Parse(userId));
                user.IsOnline = false;
                await _userRepository.UpdateAsync(user);
            }

            await base.OnDisconnectedAsync(exception);
        }

        public async Task SendMessage(long fromUserId, long toUserId, string content)
        {
            var conversation = await _conversationRepository.GetAll().Where(x => x.SenderUserId == fromUserId && x.ReceiverUserId == toUserId).FirstOrDefaultAsync();
            if (conversation is null)
            {
                conversation = new()
                {
                    SenderUserId = fromUserId,
                    ReceiverUserId = toUserId,
                    Messages = new List<Message>()
                    {
                       new() {Content=content }
                    }
                };
                await _conversationRepository.InsertAsync(conversation);
            }
            else
            {
                var message = new Message
                {
                    ConversationId = conversation.Id,
                    Content = content,
                };
                await _messageRepository.InsertAsync(message);

            }

            await Clients.User(toUserId.ToString()).SendAsync("ReceiveMessage", fromUserId, content);
        }

        public async Task<List<MessageDto>> GetChatHistory(long withUserId)
        {
            var currentUserId = long.Parse(Context.UserIdentifier);
            var conversation = await _conversationRepository.FirstOrDefaultAsync(c =>
                (c.SenderUserId == currentUserId && c.ReceiverUserId == withUserId) ||
                (c.SenderUserId == withUserId && c.ReceiverUserId == currentUserId));

            if (conversation == null)
            {
                return new List<MessageDto>();
            }

            var messages = conversation.Messages.Select(m => new MessageDto
            {
                FromUserId = m.Conversation.SenderUserId,
                ToUserId = m.Conversation.ReceiverUserId,
                Content = m.Content,
                Timestamp = m.CreationTime
            }).ToList();

            return messages;
        }
    }
}
