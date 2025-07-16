using Mission.Entities.ViewModel.Login;
using Mission.Entities.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Repositories.IRepository
{
    public interface IUserRepository
    {
        Task<(UserLoginResponseModel? response, string message)> LogiUser(UserLoginRequestModel model);
        Task<List<UserResponseModel>> GetUsersAsync();

        Task<bool> RegisterUserAsync(AddUserRequestModel model);

        Task<UserResponseModel?> GetLoginUserDetailById(int userId);

        Task<(bool response, string message)> UpdateUserAsync(UpdateUserRequestModel model, string imageUploadPath);

        Task<bool> DeleteUser(int userId);
    }
}
