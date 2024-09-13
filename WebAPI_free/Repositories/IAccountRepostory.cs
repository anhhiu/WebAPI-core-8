using Microsoft.AspNetCore.Identity;
using WebAPI_free.Models;

namespace WebAPI_free.Repositories
{
    public interface IAccountRepostory
    {
        public Task<IdentityResult> SignUpAsync(SignUpModel model);
        public Task<string> SigninAsync(SignInModel model);
    }
}
