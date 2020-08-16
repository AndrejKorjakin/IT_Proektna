using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BundleGames.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

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

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<BundleGames.Models.Korisnik> Korisniks { get; set; }

        public System.Data.Entity.DbSet<BundleGames.Models.Game> Games { get; set; }

        public System.Data.Entity.DbSet<BundleGames.Models.WishlistGame> Wishlists { get; set; }

        public System.Data.Entity.DbSet<BundleGames.Models.PopustGames> PopustGames { get; set; }

        public System.Data.Entity.DbSet<BundleGames.Models.ShoppingCart> ShoppingCarts { get; set; }

        public System.Data.Entity.DbSet<BundleGames.Models.Store> Stores { get; set; }
    }
}