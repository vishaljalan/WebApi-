using WebApplication1_feb16.Models;

namespace WebApplication1_feb16.DataAccess
{
    public interface IAuth
    {
        public UserDTO LoginUser(UserDTO user);

        public UserDTO RegisterUser(UserDTO user);
    }
}
