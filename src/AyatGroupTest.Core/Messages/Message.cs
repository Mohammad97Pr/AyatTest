using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using AyatGroupTest.Conversations;
using System.Threading.Tasks;

namespace AyatGroupTest.Messages
{
    public class Message : FullAuditedEntity<long>
    {
        public int ConversationId { get; set; }
        [ForeignKey(nameof(ConversationId))]
        public virtual Conversation Conversation { get; set; }
        public string Content { get; set; }

    }
}
