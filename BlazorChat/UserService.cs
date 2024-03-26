namespace BlazorChat
{
    public class UserService
    {
        public List<(string ConnectionId, string Username)> UserList = new List<(string ConnectionId, string Username)>();

        public void Add(string connectionId, string username)
        {
            UserList.Add((connectionId,username));
        }

        public void RemoveByName(string username)
        {
            UserList.Remove((GetConnectioIdByName(username),username));
        }

        public string GetConnectioIdByName(string username)
        {
            return UserList.FindLast(x => x.Username == username).ConnectionId;
        }

        public IEnumerable<(string ConnectionId, string Username)> GetAll()
        {
            return UserList;
        }
    }
}
