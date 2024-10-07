using Fashion.Domin.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Domin.ViewModel
{
    public class NewDropVM
    {

        public NewDrops NewDrops { get; set; }
        public IEnumerable<SelectListItem> BrandList { get; set; }
        public IEnumerable<SelectListItem> ClothesList { get; set; }
        public IEnumerable<SelectListItem> SizesList { get; set; }
     

    }
}
