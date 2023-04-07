﻿using OWSCustomAPI.DTOs;
using OWSData.Models.Composites;
using OWSData.Repositories.Implementations.MSSQL;
using OWSData.Repositories.Interfaces;
using OWSShared.Interfaces;
using System;
using System.Threading.Tasks;

namespace OWSCustomAPI.Requests.Users
{
    public class LogoutRequest
    {
        private readonly LogoutDTO _logoutDTO;
        private readonly IHeaderCustomerGUID _customerGuid;
        private readonly IUsersRepository _usersRepository;

        public LogoutRequest(LogoutDTO logoutDTO, IUsersRepository usersRepository, IHeaderCustomerGUID customerGuid)
        {
            _logoutDTO = logoutDTO;
            _customerGuid = customerGuid;
            _usersRepository = usersRepository;
        }

        public async Task<SuccessAndErrorMessage> Handle()
        {
            return await _usersRepository.Logout(_customerGuid.CustomerGUID, _logoutDTO.UserSessionGUID);
        }
    }
}
