using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Data;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using SimpleInjector;
using OWSData.Models.StoredProcs;
using OWSShared.Interfaces;
using OWSData.Repositories.Interfaces;
using System.ComponentModel;
using OWSCustomApi.Requests.Users;
using OWSData.Models.Composites;

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
    }
}