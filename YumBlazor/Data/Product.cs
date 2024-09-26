using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace YumBlazor.Data
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Range(0.01, 1000)]
        public decimal Price { get; set; }

        public string? Description { get; set; }
        public string? SpecialTag { get; set; }

        public string? ImageUrl { get; set; }

        // Etablishing a Foreign Key. 
        // This is referencing to the Id from the Category Model
        // It allows me to goto the CategoryId for this Product -
        // Then I can get like Category.Name / Category.Price / Category.PropertyName Etc.. 
        public int CategoryId { get; set; } // This is the Foreign key ??

        [ForeignKey("CategoryId")] // This is relating to the primary key in the Category table
        public Category Category { get; set; } // I don't think i need to annotate this when the name is the same as the object type


        // With the Foreign key I think i can goto the Category property of this model -
        // And get the fields from that property like -
        // Category.Id / Category.Name / Category.FieldName etc..

        // I use it in home.razor like this

        /*
         * @* string name = categoryId.Category.Name; 
                    <p>@name</p> *@
         * */
    }
}
