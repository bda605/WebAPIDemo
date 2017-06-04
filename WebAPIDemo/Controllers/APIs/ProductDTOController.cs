using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;
using System.Data;

using WebAPIDemo.Models;
namespace WebAPIDemo.Controllers.APIs
{
    public class ProductDTOController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        IQueryable<ProductDTO> MapProducts()
        {
            return from p in db.Products
                   select new ProductDTO
                   {
                       ProductId = p.ProductID,
                       ProductName = p.ProductName,
                       QuantityPerUnit = p.QuantityPerUnit,
                       UnitPrice = p.UnitPrice
                   };
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            return MapProducts().AsEnumerable();
        }

        public ProductDTO GetProduct(int id)
        {
            var product = (from p in MapProducts()
                           where p.ProductId == id
                           select p).FirstOrDefault();

            if (product == null)
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));

            return product;
        }
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
