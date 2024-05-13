using YcLibrary.Models.Extentions;

namespace CoreLibrary.Models
{
    public class Client
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Key { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        public YcCredentials ycCredentials { get; set; }


        public void SetClient(Client client)
        {
            UserName = client.UserName;
            Password = client.Password;
            Key = client.Key;

            FirstName = client.FirstName;
            LastName = client.LastName;

            ycCredentials = client.ycCredentials;
        }
    }
}
