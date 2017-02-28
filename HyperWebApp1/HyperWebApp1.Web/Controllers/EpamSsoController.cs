// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AccountController.cs" company="EPAM Systems">
//   Copyright 2015
// </copyright>
// <summary>
//   The AccountController.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace HyperWebApp1.Web.Controllers
{
    using System;
    using System.IdentityModel.Services;
    using System.Web.Mvc;
    using HyperWebApp1.Web.Implementation;

    /// <summary>
    /// Account Controller
    /// </summary>    
    [Authorize]
    public class EpamSsoController : Controller
    {
        public ActionResult SignIn()
        {
            if (User == null || !User.Identity.IsAuthenticated)
            {
                FederatedAuthentication.WSFederationAuthenticationModule.SignIn("");
                return new EmptyResult();
            }
            else
            {
                return View();
            }
        }

        public ActionResult SignOut()
        {
            AuthDataManager.CleanupCookies(Response);
            if (User == null || !User.Identity.IsAuthenticated)
            {
                return View();
            }
            else
            {
                var stsUri = FederatedAuthentication.WSFederationAuthenticationModule.Issuer;
                var backUrl = FederatedAuthentication.WSFederationAuthenticationModule.Realm;

                WSFederationAuthenticationModule.FederatedSignOut(new Uri(stsUri, UriKind.RelativeOrAbsolute), new Uri(backUrl, UriKind.RelativeOrAbsolute));
                return new EmptyResult();
            }
        }
    }
}