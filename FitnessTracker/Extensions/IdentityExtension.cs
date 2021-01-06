using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;

namespace FitnessTracker.Extensions
{
    public static class IdentityExtension
    {
        /// <summary>
        /// Gets the current users height.
        /// </summary>
        /// <param name="identity"></param>
        /// <returns>Height as a string or empty string if null</returns>
        public static string GetUserHeight(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Height");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserFirstName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("FirstName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserLastName(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("LastName");
            return (claim != null) ? claim.Value : string.Empty;
        }

        public static string GetUserWeight(this IIdentity identity)
        {
            var claim = ((ClaimsIdentity)identity).FindFirst("Weight");
            return (claim != null) ? claim.Value : string.Empty;
        }
    }
}