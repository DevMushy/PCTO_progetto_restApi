namespace TodoApi.Models
{
    public class UserConstants
    {
        public static List<UserModel> Users = new List<UserModel>()
        {
            new UserModel() { Username = "Mirko", EmailAddress = "mirko@email.com", Password = "12345", GivenName = "mirko", Surname = "boh", Role = "Administrator" },
            new UserModel() { Username = "Adam", EmailAddress = "adam@email.com", Password = "67890", GivenName = "Adam", Surname = "wa", Role = "User" },
        };
    }
}