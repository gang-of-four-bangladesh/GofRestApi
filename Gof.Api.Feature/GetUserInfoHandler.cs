using System.Threading.Tasks;
using Gof.Api.Core;
using Gof.Api.Dto;
using Gof.Api.Core.Infrastructure;
using Gof.Api.Domain;
using Gof.Api.Data;
using Gof.Api.Data;
using Gof.Api.Feature;

namespace Gof.Api.Feature
{
    public class GetUserInfoHandler : ICommandHandler<GetUserInfoCommand, UserInfo>
    {
        private DataContext _dataContext;

        public GetUserInfoHandler(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }
        public async Task<UserInfo> Handle(GetUserInfoCommand command)
        {
            var user = this._dataContext.Find<User>(command.UserId);
            return await Task.FromResult(
             new UserInfo()
             {
                 UserId = user.Id,
                 Name = user.Name,
                 Password = user.Password,
                 PhoneNumber = user.PhoneNumber
             });
        }
    }
}