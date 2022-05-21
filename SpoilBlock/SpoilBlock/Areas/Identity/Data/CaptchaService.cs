
using Microsoft.Extensions.Options;
using SpoilBlock.Areas.Identity.Data;

namespace SpoilBlock.Areas.Identity.Data
{
    public class CaptchaService
    {
        private readonly IOptionsMonitor<CaptchaConfig> _config;
        public CaptchaService(IOptionsMonitor<CaptchaConfig> config){

            _config = config;
        }
        public async Task<bool> VerifyToken()
        {
            //var url = $"https://www.google.com/recaptcha/api/siteverify?secret={}";

            return false;
        }
    }
}
