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

namespace WebAPIDemo.Controllers.APIs
{
    public class ProductController : ApiController
    {
        private NorthwindEntities db = new NorthwindEntities();
        public IEnumerable<Products> GetProducts()
        {
            return db.Products.AsEnumerable();
        }

        public Products GetProduct(int id)
        {
            Products product = db.Products.Find(id);
            if (product == null) throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));     
            return product;
        }

        public HttpResponseMessage PutProduct(int id, Products product)
        {
            if (ModelState.IsValid && id == product.ProductID)
            {
                db.Entry(product).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
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
                db.Products.Add(product);
                db.SaveChanges();
                HttpResponseMessage reponse = Request.CreateResponse(HttpStatusCode.Created, product);
                reponse.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = product.ProductID }));
                return reponse;
            }
            else {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }
        }
        public HttpResponseMessage DeleteProduct(int Id) 
        {
            Products product = db.Products.Find(Id);
            if (product == null) return Request.CreateResponse(HttpStatusCode.NotFound);
            db.Products.Remove(product);

            try
            {
                db.SaveChanges();
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
