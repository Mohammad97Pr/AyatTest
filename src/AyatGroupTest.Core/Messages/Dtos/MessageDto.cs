using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyatGroupTest.Messages.Dtos
{
    public class MessageDto
    {
        public long FromUserId { get; set; }
        public long ToUserId { get; set; }
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
