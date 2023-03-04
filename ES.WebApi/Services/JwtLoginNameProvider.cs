using ES.Application.Infrastructure;

namespace ES.WebApi.Services
{
    public class JwtLoginNameProvider : ILoginNameProvider
    {
        readonly IHttpContextAccessor _httpContextAccessor;

        public JwtLoginNameProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string CurrentLoginName { get => _httpContextAccessor.HttpContext.User.Claims.Where(c => c.Type.ToLower() == "name").Select(c => c.Value).FirstOrDefault(); }
    }
}
