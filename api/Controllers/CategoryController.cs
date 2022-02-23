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
    public class CategoryController : ControllerBase
    {
        private readonly ICategory icategory;
        public CategoryController(ICategory Icategory)
        {
            icategory=Icategory;
        }
        [HttpPost]
        public bool AddCategory(MCategory category)
        {
            if (ModelState.IsValid)
            {
                icategory.AddCategory(category);
                return true;
            }
            else
            {
                return false;
            }
            
        }
        [HttpPost]
        public string DeleteCategory(int id)
        {
            var result =icategory.DeleteCategory(id);
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
        public List<MCategory> ShowActiveStatus()
        {
            return icategory.ShowActiveStatus();
        }


        [HttpPost]
        public List<MCategory> ShowChildCategory(int id)
        {
            return icategory.ShowChildCategory(id);
        }

        [HttpGet]
        public List<MCategory> ShowDeActiveStatus()
        {
            return icategory.ShowDeActiveStatus();
        }

        [HttpPost]
        public MCategory ShowParentCategory(int id)
        {
            return icategory.ShowParentCategory(id);
        }


        [HttpPost]
        public string UpdateCategory(MCategory category)
        {
            var result =icategory.UpdateCategory(category);
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
