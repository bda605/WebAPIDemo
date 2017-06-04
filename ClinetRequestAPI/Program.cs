using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
namespace ClinetRequestAPI
{
    class Program
    {
        static void Main(string[] args)
        {
            //GetAll
            HttpClient clinet = new HttpClient();
            clinet.BaseAddress = new Uri("Http://localhost:25878/");
            clinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = clinet.GetAsync("api/product/").Result;
            if (response.IsSuccessStatusCode)
            {
                var products = response.Content.ReadAsAsync<IEnumerable<Products>>().Result;
                foreach (var p in products)
                {
                    Console.WriteLine("Id:{0}  Name:{1} ", p.ProductID.ToString(), p.ProductName.ToString());
                }
            }
            else
            {

                Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            }
            //GetSingle
            //HttpClient clinet = new HttpClient();
            //clinet.BaseAddress = new Uri("Http://localhost:25878/");
            //clinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //HttpResponseMessage response = clinet.GetAsync("api/product/1").Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    var product = response.Content.ReadAsAsync<Products>().Result;
            //    Console.WriteLine("Id:{0} Name:{1}", product.ProductID, product.ProductID);
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}


            //Create Post
            //HttpClient clinet = new HttpClient();
            //clinet.BaseAddress = new Uri("Http://localhost:25878/");
            //clinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Product postData = new Product { ProductName = "Chai 5", 
            //    SupplierID = 1, CategoryID = 1, QuantityPerUnit = "10 boxes x 20 bags",
            //    UnitPrice = 144, UnitsInStock = 39, UnitsOnOrder = 0, ReorderLevel = 10, Discontinued = false };
            //Uri productUri = null;
            //var response = clinet.PostAsJsonAsync("api/product", postData).Result;
            //if (response.IsSuccessStatusCode)
            //{
            //    productUri = response.Headers.Location;
            //    Console.WriteLine("New Product Url:{0}", productUri.ToString());
            //}
            //else {
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}

            //HttpClient clinet = new HttpClient();
            //clinet.BaseAddress = new Uri("Http://localhost:25878/");
            //clinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //Product putData = new Product { UnitPrice = 128, ProductID = 80 };
            //var response = clinet.PutAsJsonAsync("api/Product/80", putData).Result;
            //Uri productUri = null;
            //if (response.IsSuccessStatusCode)
            //{
            //    productUri = response.Headers.Location;
            //    Console.WriteLine("New Product Url:{0}", productUri.ToString());
            //}
            //else
            //{
            //    Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);
            //}
            //Delete
            //HttpClient clinet = new HttpClient();
            //clinet.BaseAddress = new Uri("Http://localhost:25878/");
            //clinet.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //var response = clinet.DeleteAsync("api/Product/80").Result;
            // Console.WriteLine("{0} ({1})", (int)response.StatusCode, response.ReasonPhrase);

            Console.ReadLine();
			
        }
         class Products
        {
            public int ProductID { get; set; }
            public string ProductName { get; set; }
            public int SupplierID { get; set; }
            public int CategoryID { get; set; }
            public string QuantityPerUnit { get; set; }
            public float UnitPrice { get; set; }
            public int UnitsInStock { get; set; }
            public int UnitsOnOrder { get; set; }
            public int ReorderLevel { get; set; }
            public bool Discontinued { get; set; }
        }
    }
   
}
