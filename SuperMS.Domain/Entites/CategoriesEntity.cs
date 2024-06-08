using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMS.Domain
{
    public class CategoriesEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public virtual ICollection<ProductEntity>  Products { get; set; }
    }
}
