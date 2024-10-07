using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Fashion.Domin.ApplicationEnums;
using Fashion.Domin.Common;

namespace Fashion.Domin.Model
{
    public class NewDrops:BaseModel
    {
        [Display(Name = "Brand")]
        public Guid BrandId { get; set; }

        [ValidateNever]
        [ForeignKey("BrandId")]
        public Brand Brand { get; set; }

        [Display(Name = "Clothes")]
        public Guid ClothesID { get; set; }

        [ValidateNever]
        [ForeignKey("ClothesID")]
        public Clothes Clothes { get; set; }

        public string ClotheName { get; set; }
        public Sizes Sizes { get; set; }

        public double Price { get; set; }
        public int Quantities { get; set; }
        public string ClotheImage { get; set; }
    }
}
