using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Gof.Api.Core.Infrastructure;
using Gof.Api.Data;
using Gof.Api.Domain;
using Gof.Api.Dto;

namespace Gof.Api.Feature
{
    using Gof.Api.Core;
    using Gof.Api.Core.Infrastructure;
    using Gof.Api.Domain;
    using Gof.Api.Dto;
    using Gof.Api.Data;


    public class UserFilterHandler : ICommandHandler<UserFilterCommand, IList<UserInfo>>
    {
        private readonly DataContext _dataContext;
        public UserFilterHandler(DataContext dataContext)
        {
            this._dataContext = dataContext;
        }

        public async Task<IList<UserInfo>> Handle(UserFilterCommand command)
        {
            var users = this._dataContext.Get<User>();
            var usersInfo = users.Select(u => new UserInfo()
            {
                UserId = u.Id,
                Name = u.Name,
                PhoneNumber = u.PhoneNumber,
                Password = u.Password
            }).ToList();
            return await Task.FromResult(usersInfo);
        }
    }
}