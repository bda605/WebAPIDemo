using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebAPIDemo.Models;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
 using WebAPIDemo.Models.Repository;
namespace WebAPIDemo.Controllers.APIs
{
    public class ProductController : ApiController
    {
        private IProductRepository _product;

        ProductController() 
        {
            _product = new ProductRepository();
        }
        ProductController(IProductRepository r) 
        {
            _product = r;
        }

        private NorthwindEntities db = new NorthwindEntities();
        public IEnumerable<Products> GetProducts()
        {
            return _product.GetAll();
        }

        public Products GetProduct(int id)
        {
            Products product = _product.GetById(id);
            if (product == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));     
            return product;
        }

        public HttpResponseMessage PutProduct(int id, Products product)
        {
            if (ModelState.IsValid && id == product.ProductID)
            {
 
                try
                {
                    _product.Update(product);
                }
                catch (DbUpdateException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        [WebAPIDemo.Filters.ValidateModel]
        public HttpResponseMessage PostProduct(Products product)
        {
            if (product == null) return Request.CreateResponse(HttpStatusCode.BadRequest);
            if (ModelState.IsValid)
            {
                _product.Create(product);
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.Created, product);
                reponse.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.ProductID }));
                return reponse;
            }
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        public HttpResponseMessage DeleteProduct(int id) 
        {
            Products product = _product.GetById(id);
            if (product == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            try
            {
                _product.Delete(product);
            }
            catch (DbUpdateException) 
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, product);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
