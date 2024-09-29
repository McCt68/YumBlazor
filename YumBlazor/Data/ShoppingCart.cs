using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class ShoppingCart
    {
        // These are columns in the table
        public int ShoppingCartId { get; set; }
        
        // In Entity Framework .NET Identity, a Guid (Globally Unique Identifier) -
        // is a unique 128-bit value used to identify entities in your application. -
        // It's a universally unique identifier that ensures each entity has a distinct, -
        // non-repeatable identifier, even if the entities are created on -
        // different systems or at different times.

        // / I Think this is the property i must call to access User -
        // Like ShoppingCartId.UserId.PropertyName from ASPNet User
         
        [ForeignKey("UserId")] // I Think it will always refer to the Id Column. Even i change the name here ??
        public string UserId { get; set; }
        public ApplicationUser User { get; set; } // Navigation Property use to represent the current user

        
        [ForeignKey("ProductId")] // This refers to the Primary key in Product
        public int ProductId { get; set; }
        public Product Product { get; set; } // Navigation Property use to reference the Product


        public int Count { get; set; }
    }
}
