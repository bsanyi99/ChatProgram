namespace Client
{
    internal class Users
    {
        public string username { get; set; }
        public string password { get; set; }

        public Users(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        public override bool Equals(object obj)
        {
            Users user = (Users)obj;
            if (this.username.Equals(user.username))
            {
                return true;
            }
            return false;
        }
    }
}