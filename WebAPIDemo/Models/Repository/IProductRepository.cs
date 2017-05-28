using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAPIDemo.Models.Repository
{
    public interface IProductRepository
    {
        IEnumerable<Products> GetAll();
        Products GetById(int Id);

        void Create(Products p);
        void Update(Products p);

        void Delete(Products p);

        void Dispose();
    }
}