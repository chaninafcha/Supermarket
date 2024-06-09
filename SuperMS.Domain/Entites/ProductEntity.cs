using System.ComponentModel.DataAnnotations.Schema;

namespace SuperMS.Domain
{
    public class ProductEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        public string name { get; set; }
        public int category { get;set; }


        public virtual CategoriesEntity categoryNavigation { get; set; } = null!;


    }


}
