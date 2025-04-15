using System.Security.Claims;

namespace Assembly.Projecto.Final.WebAPI.Extensions
{
    public static class ClaimsPrincipalExtentsion
    {
        public static string? GetId(this ClaimsPrincipal user) 
        {
            return user.FindFirst("id").Value; 
        }

        public static string? GetRole(this ClaimsPrincipal user) 
        {
            return user.FindFirst("Role").Value;
        }

        public static string? GetEmail(this ClaimsPrincipal user)
        {
            return user.FindFirst("Role").Value;
        }
    }
}
