﻿using System;
using System.Globalization;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using ProjectWork.Web.Models;
using ProjectWork.Web.Infrastructure;
using ProjectWork.Web.Infrastructure.Core;
using ProjectWork.Services;
using ProjectWork.Data;
using ProjectWork.Entities;
using System.Net.Http;
using System.Net;

namespace ProjectWork.Web.Controllers
{
    [Authorize(Roles ="Admin")]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiControllerBase
    {
        private readonly IMembershipService _membershipService;

        public AccountController(IMembershipService membershipService, IEntityBaseRepository<Error> _errorsRepository,IUnitOfWork _unitOfWork)
            :base(_errorsRepository,_unitOfWork)
        {
            _membershipService = membershipService;
        }

        //[AllowAnonymous]
        //[Route("authenticate")]
        //[HttpPost]
        //public HttpResponseMessage Login(HttpRequestMessage request, LoginViewModel user)
        //{
        //    return CreateHttpResponse(request, () =>
        //    {
        //        HttpResponseMessage response = null;
        //        if (ModelState.IsValid)
        //        {
        //            MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);
        //            if (_userContext.User != null)
        //            {
        //                response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
        //            }
        //            else
        //            {
        //                response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
        //            }

        //        }
        //        else
        //        {
        //            response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
        //        }

        //        return response;
        //    });
        //}

        [AllowAnonymous]
        [Route("register")]
        [HttpPost]
        public HttpResponseMessage Register(HttpRequestMessage request,RegistrationViewModel user)
        {
            return CreateHttpResponse(request, () => {
                HttpResponseMessage response = null;

                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, new { success = false });
                }
                else
                {
                    Entities.User _user = _membershipService.CreateUser(user.Username, user.Email, user.Password, new int[] { 1 });

                    if (_user != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }
                }

                return response;
            });
        }

        [AllowAnonymous]
        [Route("authenticate")]
        [HttpPost]
        public HttpResponseMessage Authenticate(HttpRequestMessage request, LoginViewModel user)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (ModelState.IsValid)
                {
                    MembershipContext _userContext = _membershipService.ValidateUser(user.Username, user.Password);
                    if (_userContext.User != null)
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = true });
                    }
                    else
                    {
                        response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                    }

                }
                else
                {
                    response = request.CreateResponse(HttpStatusCode.OK, new { success = false });
                }

                return response;
            });
        }

    }
}
