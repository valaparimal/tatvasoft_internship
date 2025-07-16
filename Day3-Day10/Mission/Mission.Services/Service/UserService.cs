using Mission.Entities.ViewModel;
using Mission.Entities.ViewModel.Login;
using Mission.Entities.ViewModels.User;
using Mission.Repositories.IRepository;
using Mission.Services.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mission.Services.Service
{
    public class UserService(IUserRepository userRepository, JwtService jwtService) : IUserService
    {
        private readonly IUserRepository _userRepository = userRepository;
        private readonly JwtService _jwtService = jwtService;

        public async Task<List<UserResponseModel>> GetUsersAsync()
        {
            return await _userRepository.GetUsersAsync();
        }

        public async Task<bool> RegisterUserAsync(AddUserRequestModel model)
        {
            return await _userRepository.RegisterUserAsync(model);
        }

        public async Task<UserResponseModel?> GetLoginUserDetailById(int userId)
        {
            return await _userRepository.GetLoginUserDetailById(userId);
        }

        public async Task<bool> DeleteUser(int userId)
        {
            return await _userRepository.DeleteUser(userId);
        }

        public async Task<ResponseResult> UpdateUserAsync(UpdateUserRequestModel model, string imageUploadPath)
        {
            var (response, message) = await _userRepository.UpdateUserAsync(model,imageUploadPath);

            var result = new ResponseResult()
            {
                Message = message
            };

            if (!response)
                result.Result = ResponseStatus.Error;
            else
                result.Result = ResponseStatus.Success;

            return result;
        }
        public async Task<ResponseResult> LogiUser(UserLoginRequestModel model)
        {
            var (response, message) = await _userRepository.LogiUser(model);

            var result = new ResponseResult()
            {
                Message = message
            };

            if (response == null)
            {
                result.Result = ResponseStatus.Error;
            }
            else
            {
                result.Data = _jwtService.GenerateJwtToken(response);
                result.Result = ResponseStatus.Success;
            }

            return result;
        }

        
    }
}
