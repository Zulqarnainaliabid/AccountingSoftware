using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using AccountingApp.Api.Resources;
using AccountingApp.Api.Validations;
using AccountingApp.Core.Models;
using AccountingApp.Core.Services;

namespace AccountingApp.Api.Controllers
{
    public class BaseController : ControllerBase
    {
        public BaseController()
        {
        }
        protected string UserId 
        { 
            get 
            { 
                return User.FindFirstValue(ClaimTypes.NameIdentifier); 
            } 
        }
        protected Guid UserIdGuid
        {
            get
            {
                return Guid.Parse(UserId);
            }
        }
    }
}