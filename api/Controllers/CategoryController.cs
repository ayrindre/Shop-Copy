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
            icategory = Icategory;
        }
        [HttpPost]
        public IActionResult AddCategory(MCategory category)
        {
            if (ModelState.IsValid)
            {
                icategory.AddCategory(category);
                return Ok("عملیات با موفقیت انجام شد");
            }
            return BadRequest();

        }
        [HttpPost]
        public IActionResult DeleteCategory(int id)
        {
            var result = icategory.DeleteCategory(id);
            if (result)
            {
                return Ok("عملیات با موفقیت انجام شد");
            }
            else
            {
                return Ok("این آیدی وجود ندارد!");
            }
        }

        [HttpGet]
        public IActionResult ShowActiveStatus()
        {
            return Ok(icategory.ShowActiveStatus());
        }


        [HttpPost]
        public IActionResult ShowChildCategory(int id)
        {
            return Ok(icategory.ShowChildCategory(id));
        }

        [HttpGet]
        public IActionResult ShowDeActiveStatus()
        {
            return Ok(icategory.ShowDeActiveStatus());
        }

        [HttpPost]
        public IActionResult ShowParentCategory(int id)
        {
            return Ok(icategory.ShowParentCategory(id));
        }


        [HttpPost]
        public IActionResult UpdateCategory(MCategory category)
        {
            if (ModelState.IsValid)
            {
                var result = icategory.UpdateCategory(category);
                if (result)
                {
                    return Ok("عملیات با موفقیت انجام شد");
                }
                else
                {
                    return Ok("این آیدی وجود ندارد");
                }
            }
            return BadRequest();
        }
    }
}
