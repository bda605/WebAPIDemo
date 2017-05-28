using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using WebAPIDemo.Models.Repository;
namespace WebAPIDemo.Models
{
    public class ProductRepository:IProductRepository
    {
        private NorthwindEntities db;
        public ProductRepository() 
        {
            db = new NorthwindEntities();
        }
        public IEnumerable<Products> GetAll() 
        {
            return db.Products.AsEnumerable();
        }
        public Products GetById(int Id) 
        {
            return db.Products.Find(Id);
        }

        public void Create(Products p) 
        {
            db.Products.Add(p);
            db.SaveChanges();
        }
        public void Update(Products p) 
        {
            db.Entry(p).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void Delete(Products p) 
        {
            db.Entry(p).State = EntityState.Deleted;
            db.SaveChanges();
        }
        public void Dispose() 
        {
            db.Dispose();
        }
    }
}