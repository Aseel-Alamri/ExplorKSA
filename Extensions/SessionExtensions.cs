using Microsoft.AspNetCore.Http;
using System;

namespace FinalWebApplication.Extensions // Adjust the namespace accordingly
{
    public static class SessionExtensions
    {
        public static void SetBool(this ISession session, string key, bool value)
        {
            session.SetString(key, value.ToString());
        }

        public static bool? GetBool(this ISession session, string key)
        {
            var value = session.GetString(key);
            if (value != null && bool.TryParse(value, out bool result))
            {
                return result;
            }
            return null;
        }


        public static void SetDecimal(this ISession session, string key, decimal value)
        {
            session.SetString(key, value.ToString());
        }

        public static decimal? GetDecimal(this ISession session, string key)
        {
            var value = session.GetString(key);
            return value != null ? (decimal?)decimal.Parse(value) : null;
        }
    }
}
