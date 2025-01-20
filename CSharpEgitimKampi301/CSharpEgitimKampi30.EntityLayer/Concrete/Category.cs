using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi30.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryId { get; set; } // birincil anahtar oldugunu ve otomatik artan olması için sınıfın ismi birebir olacak sonuna id 

        public string CategoryName { get; set; }

        public bool CategoryStatus { get; set; }

        public List<Product> products { get; set; }
    }
}
