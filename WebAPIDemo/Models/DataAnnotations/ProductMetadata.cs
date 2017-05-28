using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace WebAPIDemo.Models
{
    [MetadataType(typeof(ProductMetadata))]
    public partial class Products
    {
        public class ProductMetadata
        {
            [ScaffoldColumn(false)]
            public int ProductID { get; set; }
            [Required(ErrorMessage = "產品名稱不得空白")]
            [StringLength(40, MinimumLength = 3, ErrorMessage = "產品名稱長度介於3-40")]
            public string ProductName { get; set; }

            public Nullable<int> SupplierID { get; set; }
            public Nullable<int> CategoryID { get; set; }
            [StringLength(20)]
            public string QuantityPerUnit { get; set; }
            public Nullable<decimal> UnitPrice { get; set; }
            public Nullable<short> UnitsInStock { get; set; }
            public Nullable<short> UnitsOnOrder { get; set; }
            public Nullable<short> ReorderLevel { get; set; }
            public bool Discontinued { get; set; }
        }
    }
}