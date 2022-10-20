using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace TelegramClone.Utils
{
    public class CustomUserIdProvider : IUserIdProvider
    {
        public virtual string GetUserId(HubConnectionContext connection)
        {
            
            Debug.WriteLine($"connection name: {connection.User.Identity.Name}");
            string a;
            Debug.WriteLine($"auth header: {connection.GetHttpContext().Request.Headers.TryGetValue("Authorization", out StringValues v)}");
            Debug.WriteLine($"ishttpcontext: {connection.GetHttpContext() != null}");
            return connection.GetHttpContext().User.Identity.Name;
        }
    }
}
