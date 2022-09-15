using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDataLayer
{
    public class CategoryEntity: BaseEntity
    {
        public CategoryEntity()
        {
            Products = new List<ProductEntity>();
        }
        public string CategoryName { get; set; }
        public ICollection<ProductEntity> Products { get; set; }
    }
}
