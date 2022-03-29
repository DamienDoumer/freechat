using Models.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class User : BaseModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Bio { get; set; }
        public int NumberOfConversations { get; set; }
        public int NumberOfMessagesSent { get; set; }
        public string ProfilePic { get; set; }
        public bool IsOnline { get; set; }

        public User()
        {

        }

        public User(string firstName, string secondName, string bio, string profilePic, int numberOfConversations, 
            int numberOfMessagesSent)
        {
            FirstName = firstName;
            LastName = secondName;
            NumberOfConversations = numberOfConversations;
            Bio = bio;
            ProfilePic = profilePic;
            NumberOfMessagesSent = numberOfMessagesSent;
        }
    }
}
