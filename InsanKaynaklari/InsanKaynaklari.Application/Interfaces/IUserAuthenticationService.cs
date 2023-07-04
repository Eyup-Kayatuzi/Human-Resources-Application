using InsanKaynaklari.Domain.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsanKaynaklari.Application.Interfaces
{
    public interface IUserAuthenticationService
    {
        Task<Status> LoginAsync(LoginDto model);
        Task LogoutAsync();
    }
}
