using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Message : BaseModel
    {
        public string Content { get; set; }
        public string ConversationId { get; set; }
        public bool ISent { get; set; }

        public bool ISentPreviousMessage { get; set; }

        public Message ReplyTo { get; set; }
        public string SenderId { get; set; }
        public User Sender { get; set; }
    }
}
