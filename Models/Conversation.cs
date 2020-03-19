using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class Conversation : BaseModel
    {
        public string[] UserIds { get; set; }
		private Message _lastMessage;
		public Message LastMessage
		{
			get { return _lastMessage; }
			set { SetProperty(ref _lastMessage, value); }
		}
		public User Peer { get; set; }

		public Conversation()
		{
			UserIds = new string[2];
		}
	}
}
