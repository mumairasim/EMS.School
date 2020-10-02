﻿using AutoMapper;
using SCHOOL.DATA.Infrastructure;
using SCHOOL.Services.Infrastructure;
using DBUserInfo = SCHOOL.DATA.Models.NonDbContextModels.UserInfo;
using DTOUserInfo = SCHOOL.DTOs.DTOs.UserInfo;
using DTOPerson = SCHOOL.DTOs.DTOs.Person;
using System;
using System.IO;
using SCHOOL.SERVICES.Infrastructure;

namespace SCHOOL.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IPersonService _personService;
        private IStoredProcCaller _storedProcCaller;
        private readonly IMapper _mapper;
        public AccountService(IStoredProcCaller storedProcCaller, IMapper mapper, IPersonService personService)
        {
            _storedProcCaller = storedProcCaller;
            _mapper = mapper;
            _personService = personService;

        }
        public DTOUserInfo GetUserInfo(string userName)
        {
            var resultDB = _storedProcCaller.GetUserInfo(userName);
            var userInfoDto = _mapper.Map<DBUserInfo, DTOUserInfo>(resultDB);
            if (!String.IsNullOrEmpty(userInfoDto.ImagePath))
            {
                userInfoDto.Image = System.IO.File.ReadAllBytes(userInfoDto.ImagePath);
                userInfoDto.ImageExtension = Path.GetExtension(userInfoDto.ImagePath);
            }
            return userInfoDto;
        }
        public void UpdateUserInfo(DTOUserInfo userInfo)
        {
            var person = _mapper.Map<DTOUserInfo, DTOPerson>(userInfo);
            _personService.Update(person);
        }
    }
}
