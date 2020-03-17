using System;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Xml;
using DomodedovoTestApp.Logic.Repositories;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DomodedovoTestApp.Models
{
    public class ApplicationUser : IUser
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public string PasswordHash { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }

        public override string ToString()
        {
            return string.Format("Id={0} PasswordHash={1}", Id, (PasswordHash == null ? string.Empty : PasswordHash));
        }
    }
    

    public class ApplicationDbContext : 
        IUserStore<ApplicationUser>, 
        IUserPasswordStore<ApplicationUser>, 
        IUserLockoutStore<ApplicationUser, object>,
        IUserTwoFactorStore<ApplicationUser, object>
	{
        public ApplicationDbContext()
		{
		}

		#region IUserStore implementation

        public Task<ApplicationUser> FindByIdAsync(string userId)
		{
            if (string.IsNullOrEmpty(userId)) return Task.FromResult<ApplicationUser>(null);
			
            var userInfo = new UsersRepository().GetUserInfo(null, userId);
            ApplicationUser u = null;
            if (userInfo != null)			
			{
                u = new ApplicationUser { Id = userId, UserName = userId, PasswordHash = userInfo.PasswordHash };
			}

            return Task.FromResult<ApplicationUser>(u);
		}

        public Task<ApplicationUser> FindByNameAsync(string userName)
		{
			return FindByIdAsync(userName);
			
		}

        public Task CreateAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

        public Task DeleteAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

        public Task UpdateAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IUserPasswordStore implementation

        public Task<string> GetPasswordHashAsync(ApplicationUser user)
		{
			string hash = user.PasswordHash;
			return Task.FromResult<string>(hash);
		}

        public Task<bool> HasPasswordAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

        public Task SetPasswordHashAsync(ApplicationUser user, string passwordHash)
		{
			throw new NotImplementedException();
		}

		#endregion

		#region IUserLockoutStore implementation

        public Task<int> GetAccessFailedCountAsync(ApplicationUser user)
		{
            return Task.FromResult(0);
		}

        public Task<bool> GetLockoutEnabledAsync(ApplicationUser user)
		{
			return Task.FromResult<bool>(false);
		}

        public Task<DateTimeOffset> GetLockoutEndDateAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

        public Task<int> IncrementAccessFailedCountAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

        public Task ResetAccessFailedCountAsync(ApplicationUser user)
		{
			throw new NotImplementedException();
		}

        public Task SetLockoutEnabledAsync(ApplicationUser user, bool enabled)
		{
			throw new NotImplementedException();
		}

        public Task SetLockoutEndDateAsync(ApplicationUser user, DateTimeOffset lockoutEnd)
		{
			throw new NotImplementedException();
		}

        public Task<ApplicationUser> FindByIdAsync(object userId)
		{
			throw new NotImplementedException();
		}

		#endregion

        #region IUserTwoFactorStore implementation

        public Task SetTwoFactorEnabledAsync(ApplicationUser user, bool enabled)
        {
            throw new NotImplementedException();
        }

        public Task<bool> GetTwoFactorEnabledAsync(ApplicationUser user)
        {
            return Task.FromResult(false);
        }

        #endregion IUserTwoFactorStore implementation


        public void Dispose()
        {
        }
    }
}