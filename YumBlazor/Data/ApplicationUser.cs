using Microsoft.AspNetCore.Identity;

namespace YumBlazor.Data
{
    // Add profile data for application users by adding properties to the ApplicationUser class

    // I think IdentityUser is the Model that is used to make a 1-1 with the table AspNetUsers in the DB

    // You can customize the IdentityUser class by creating a new class -
    // that inherits from it and adding additional properties as needed. -
    // For example, you might add a FirstName and LastName property to store the user's full name.
    public class ApplicationUser : IdentityUser
    {
    }

}
