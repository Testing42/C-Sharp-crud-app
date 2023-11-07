using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulkybookweb.Models
{
    public class Category
    {
        /*the key below only worked after hitting ctrl + . then hitting enter on using System.ComponentModel.DataAnnotations;
         The [key] makes Id the primary key still makes it an identity column. KEy is called an attribute
         */
        [Key]
        public int Id { get; set; }
        //required is another attribute that makes Name a required field.
        [Required]
        public string Name { get; set; }
        //The DisplayName changes how other views and controllers will precieve the Data Name
        [DisplayName("Display Order")]
        [Range(1,100,ErrorMessage ="Display Order must be between 1 and 100 only!!")]
        public int DisplayOrder { get; set; }

        //Below is how you set a default for a property.
        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
