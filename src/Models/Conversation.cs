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
		User _peer;
		public User Peer
		{
			get => _peer;
			set => SetProperty(ref _peer, value);
		}

		public Conversation()
		{
			UserIds = new string[2];
		}
	}
}
