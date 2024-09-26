using System.ComponentModel.DataAnnotations;

namespace YumBlazor.Data
{
    // I have a reference to this class in the Products table by using a foreign key
    // I can then when I have a Product use the category.name to access this anem in here
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter name..")]
        public string Name { get; set; }
    }
}
