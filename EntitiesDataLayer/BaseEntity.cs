using EntitiesDataLayer.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntitiesDataLayer
{
    public class BaseEntity : IEntityBase
    {
        [Key]
        public int Id { get; set ; }
    }
}
