using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Perfactcv.Api.Resources;
using Perfactcv.Api.Validations;
using Perfactcv.Core.Models;
using Perfactcv.Core.Services;

namespace Perfactcv.Api.Controllers
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
    }
}