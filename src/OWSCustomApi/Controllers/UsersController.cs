using OWSCustomApi.Requests.Users;
using Microsoft.AspNetCore.Mvc;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using Microsoft.AspNetCore.Mvc.Filters;
using OWSData.Models.StoredProcs;
using OWSData.Models.Composites;
using SimpleInjector;
using OWSCustomAPI.DTOs;
using OWSCustomAPI.Requests.Users;

namespace OWSCustomApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {
        private readonly IHeaderCustomerGUID _customerGuid;
        private readonly ICharactersRepository _charactersRepository;
        private readonly IUsersRepository _usersRepository;
    
        public UsersController(IUsersRepository usersRepository, ICharactersRepository charactersRepository, IHeaderCustomerGUID customerGuid)
        {
            _usersRepository = usersRepository;
            _charactersRepository = charactersRepository;
            _customerGuid = customerGuid;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (_customerGuid.CustomerGUID == Guid.Empty)
            {
                context.Result = new UnauthorizedResult();
            }
        }

        [HttpPost]
        [Route("UpdateCharacterCosmetics")]
        public async Task UpdateCharacterCosmetics([FromBody] UpdateCharacterCosmeticsRequest request)
        {
            request.SetData(_customerGuid, _charactersRepository);
            await request.Handle();

            return;
        }

        [HttpPost]
        [Route("Logout")]
        [Produces(typeof(SuccessAndErrorMessage))]
        public async Task<SuccessAndErrorMessage> Logout([FromBody] LogoutDTO request)
        {
            LogoutRequest logoutRequest = new LogoutRequest(request, _usersRepository, _customerGuid);
            return await logoutRequest.Handle();
        }
    }
}