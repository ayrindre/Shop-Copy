using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using core.Domain;
using core.Repository;
using infrastructure.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]/[Action]")]
    public class ProductController : ControllerBase
    {
        private readonly IProduct iProduct;
        public ProductController(IProduct IProduct)
        {
            iProduct = IProduct;
        }
        [HttpPost]
        public string AddProduct(MProduct Product)
        {
            if (ModelState.IsValid)
            {
                var result = iProduct.AddProduct(Product);
                if (result)
                {
                    return "عملیات با موفقیت انجام شد";
                }
                else
                {
                    return "خطا";
                }
            }
            else
            {
                 return "خطا";
            }

        }
        
        [HttpPost]
        public string DeleteProduct(int id)
        {
            var result = iProduct.DeleteProduct(id);
            if (result)
            {
                return "عملیات با موفقیت انجام شد";
            }
            else
            {
                return "این آیدی وجود ندارد";
            }
        }

        [HttpGet]
        public List<MProduct> ShowActiveStatusProduct()
        {
            return iProduct.ShowActiveStatusProduct();
        }


        [HttpPost]
        public string UpdateProduct(MProduct Product)
        {
            var result = iProduct.UpdateProduct(Product);
            if (result)
            {
                return "عملیات با موفقیت انجام شد";
            }
            else
            {
                return "این آیدی وجود ندارد";
            }
        }
    }
}
