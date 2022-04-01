using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeChat.Services.MockDataStores
{
    public class UserDataStores : IDataStore<User>
    {
        readonly List<User> _users;

        public UserDataStores()
        {
            _users = new List<User>();

            _users.Add(new User("Alfredo", "Stephano", "I like chatting online and making new friends on social media",
                "alfredo.jpg", 5, 230)
            { Id = Guid.NewGuid().ToString(), IsOnline = true });
            _users.Add(new User("Carelle", "du Pont", "Chatting is sooooo fun and, you can come and talk to me if you are bored or in need of some random conversation."
                , "carelle.jpg", 10, 1500)
            { Id = Guid.NewGuid().ToString() });
            _users.Add(new User("Rebeca", "Wong", "I'm funny, I like playing baket ball and watching movies. I like talking here too. Lets have a talk",
                "rebeca.jpg", 15, 100)
            { Id = Guid.NewGuid().ToString() });
            _users.Add(new User("John", "Wong", "I'm funny, I like playing baket ball and watching movies. I like talking here too. Lets have a talk",
                "john.jpg", 2, 10)
            { Id = Guid.NewGuid().ToString() });
            _users.Add(new User("Rea", "Mogolar", "Lets chat and have fun !!!", "rea.jpg", 5, 230)
            { Id = Guid.NewGuid().ToString() });
        }

        public Task<bool> AddItemAsync(User item)
        {
            _users.Add(item);
            return Task.FromResult(true);
        }

        public Task<bool> DeleteItemAsync(string id)
        {
            var user = _users.Where(u => u.Id == id);
            if (!user.Any())
                return Task.FromResult(false);
            _users.Remove(user.FirstOrDefault());
            return Task.FromResult(true);
        }

        public Task<User> GetItemAsync(string id)
        {
            return Task.FromResult(_users.Where(u => u.Id == id).FirstOrDefault());
        }

        public Task<IEnumerable<User>> GetItemsAsync(bool forceRefresh = false)
        {
            return Task.FromResult((IEnumerable<User>)_users);
        }

        public Task<bool> UpdateItemAsync(User item)
        {
            var user = _users.Where(u => u.Id == item.Id);
            if (!user.Any())
                return Task.FromResult(false);

            _users.Remove(_users.Where(u => u.Id == item.Id).FirstOrDefault());
            _users.Add(item);
            return Task.FromResult(true);
        }
    }
}
