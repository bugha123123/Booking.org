﻿using Hotel.org.ApplicationDBContext;
using Hotel.org.Interface;
using Hotel.org.Models;
using Microsoft.EntityFrameworkCore;

namespace Hotel.org.Service
{
    public class SupportService : ISupportService
    {
        private readonly AppDbContext _appDbContext;
        private readonly IAccountService _accountService;

        public SupportService(AppDbContext appDbContext, IAccountService accountService)
        {
            _appDbContext = appDbContext;
            _accountService = accountService;
        }

        public async Task AddSupportMessage(Support support)
        {
            var user = await _accountService.GetLoggedInUserAsync();

            if (user != null)
            {
                var SupportMessage = new Support()
                {
                    Subject = support.Subject,
                    Message = support.Message,
                    User = user,
                    UserId = user.Id,
                    AddedBy = user.Email
                    

                };

                await _appDbContext.Supports.AddAsync(SupportMessage);
                await _appDbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Support>> GetSupportList()
        {
            var user = await _accountService.GetLoggedInUserAsync();

            if (user == null)
            {
                return null;
            };

            var SupportList = await _appDbContext.Supports.Where(u => u.AddedBy == user.Email).ToListAsync();
            return SupportList;
        }
    }
}
