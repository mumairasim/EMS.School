using SCHOOL.DTOs.DTOs;
using DTOUserInfo = SCHOOL.DTOs.DTOs.UserInfo;


namespace SCHOOL.Services.Infrastructure
{
    public interface IAccountService
    {
        UserInfo GetUserInfo(string userName);
        void UpdateUserInfo(DTOUserInfo userInfo);
    }
}
