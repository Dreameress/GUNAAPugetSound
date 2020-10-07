using System;
using Entities.Models;
using GUNAAPugetSound.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GUNAAPugetSound.Controllers
{
    public class BaseController : ControllerBase
    {
        public Account Account => (Account)HttpContext.Items["Account"];
    }
}
