using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using openRoads.Model;
using openRoadsWebAPI.Models;
using openRoadsWebAPI.Service;

namespace openRoadsWebAPI.Security
{
    public class BasicAuthenticationHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly IEmployeeService _userService;

        private readonly MyDbContext _context;

        public BasicAuthenticationHandler(
            IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            IEmployeeService userService,
            MyDbContext context)
            : base(options, logger, encoder, clock)
        {
            _userService = userService;
            _context = context;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.ContainsKey("Authorization"))
                return AuthenticateResult.Fail("Missing Authorization Header");

            EmployeeModel user = null;
            LoginData loginDataPerson = null;
            Person person = null;

            try
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(':');
                var username = credentials[0];
                var password = credentials[1];
                user = _userService.AuthenticateEmployee(username, password);
                loginDataPerson = _context.LoginData.FirstOrDefault(x => x.Username == username);
                person = _context.Person.FirstOrDefault(x => x.LoginDataId == loginDataPerson.LoginDataId);
            }
            catch
            {
                return AuthenticateResult.Fail("Invalid Authorization Header");
            }

            if (user == null)
                return AuthenticateResult.Fail("Invalid Username or Password");




            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier, loginDataPerson.Username),
                new Claim(ClaimTypes.Name, person.FirstName),
            };

            //foreach (var role in user.KorisniciUloge)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role.Uloga.Naziv));
            //}

            var employeeRoles = _context.EmployeeRoles.ToList();
            var employeeRolesList = _context.EmployeeEmployeeRoles.ToList();

            foreach (var x in employeeRolesList)
            {
                if (user.EmployeeId == x.EmployeeId)
                {
                    foreach (var y in employeeRoles)
                    {
                        if (x.EmployeeRolesId == y.EmployeeRolesId)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, y.Name));
                        }
                    }

                    break;
                }
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
