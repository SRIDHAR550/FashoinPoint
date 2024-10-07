using Fashion.Domin.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fashion.Domin.Model
{
    public class Brand:BaseModel
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string BrandLogo { get; set; }
    }
}
