using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using TJJ.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace IdentitySample.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        public string fname { get; set; }
        public string lname { get; set; }
        public string code_melli { get; set; }
        public string birthday_date { get; set; }
        //0 => Customer  , 1 => Seller ,  => 2 Seller and Customer
        public short user_type { get; set; }
        public string inviter_code { get; set; }

        [Column(TypeName = "datetime2")]
        public System.DateTime register_date_time { get; set; }

        public double gold_charge { get; set; }
        public double rial_charge { get; set; }

        public string dest_Account_Number { get; set; }
        public string dest_Card_Number { get; set; }
        public bool confirm_Account_Bank { get; set; }



        public virtual List<tbl_Tickets> tbl_Tickets { get; set; }
        public virtual List<tbl_Deposits> tbl_Deposits { get; set; }
        public virtual List<tbl_Request_Money> tbl_Requests { get; set; }
        public virtual List<tbl_User_Notifications> tbl_User_Notifications { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<tbl_Tickets> Tickets_tbl { get; set; }
        public virtual DbSet<tbl_Deposits> Deposits_tbl { get; set; }
        public virtual DbSet<tbl_Request_Money> Requests_tbl { get; set; }
        public virtual DbSet<tbl_User_Notifications> tbl_User_Notifications { get; set; }
        public IEnumerable ApplicationUsers { get; internal set; }

        static ApplicationDbContext()
        {
            // Set the database intializer which is run once during application start
            // This seeds the database with admin user credentials and admin role
            Database.SetInitializer<ApplicationDbContext>(new ApplicationDbInitializer());
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

    }
}