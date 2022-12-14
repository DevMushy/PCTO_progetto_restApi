using TodoApi.Models;

namespace TodoApi.IService
{
    public interface IAuthentication
    {
        
        public UserModel? Authenticate(UserLogin userLogin);
        public string Generate(UserModel user,IConfiguration _config);
    }
}