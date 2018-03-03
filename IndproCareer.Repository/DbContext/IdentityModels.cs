using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using IndproCareer.Entity;
using IndproCareer.Entity.Models;
using System.Security.Principal;
using System;
using Microsoft.Build.Framework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin;
using IndproCareer.Repository.DbContext;

namespace IndproCareer.Repository.DbContext
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser<int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public Genders Gender { get; set; }

        public string FullName { get { return FirstName + " " + LastName; } }
        public string RoleName { get; set; }

        [Required]
        public string Country { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string City { get; set; }

        public enum Genders
        {
            Male = 1,
            Female = 2,
            None = 3
        }


        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser, int> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
    
    public class CustomUserRole : IdentityUserRole<int> { }
    public class CustomUserClaim : IdentityUserClaim<int> { }
    public class CustomUserLogin : IdentityUserLogin<int> { }

    public class CustomRole : IdentityRole<int, CustomUserRole>
    {
        public CustomRole() { }
        public CustomRole(string name) { Name = name; }
    }

    public class CustomUserStore : UserStore<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public CustomUserStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class CustomRoleStore : RoleStore<CustomRole, int, CustomUserRole>
    {
        public CustomRoleStore(ApplicationDbContext context)
            : base(context)
        {
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, CustomRole, int, CustomUserLogin, CustomUserRole, CustomUserClaim>
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }


        
        public IDbSet<BasicDetail> BasicDetails { get; set; }
        public IDbSet<Branch> Branchs { get; set; }
        public IDbSet<Class> Classes { get; set; }
        public IDbSet<College> Colleges { get; set; }
        public IDbSet<Language> Languages { get; set; }
        public IDbSet<School> Schools { get; set; }
        public IDbSet<University> University { get; set; }
        public IDbSet<SendMail> SendMails { get; set; }
        public IDbSet<Visiter> Visiters { get; set; }
        public IDbSet<Register> Registers { get; set; }
        public IDbSet<Country> Countrys { get; set; }
        public IDbSet<State> States { get; set; }
        public IDbSet<Citi> Citis { get; set; }
        public IDbSet<Admission> Admissions { get; set; }
    }

}