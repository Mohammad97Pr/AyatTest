using Abp.Domain.Entities.Auditing;
using AyatGroupTest.Authorization.Users;
using AyatGroupTest.Messages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyatGroupTest.Conversations
{
    public class Conversation : FullAuditedEntity
    {
        public long SenderUserId { get; set; }
        [ForeignKey(nameof(SenderUserId))]
        public virtual User Sender { get; set; }

        public long ReceiverUserId { get; set; }
        [ForeignKey(nameof(ReceiverUserId))]
        public virtual User Receiver { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }

}
