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
    public class SizeController : ControllerBase
    {
        private readonly ISize iSize;
        public SizeController(ISize ISize)
        {
            iSize = ISize;
        }
        [HttpPost]
        public IActionResult AddSize(MSize Size)
        {
            if (ModelState.IsValid)
            {
                iSize.AddSize(Size);
                return Ok("عملیات با موفقیت انجام شد");

            }

            return BadRequest();
        }

        [HttpPost]
        public IActionResult DeleteSize(int id)
        {
            var result = iSize.DeleteSize(id);
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
        public IActionResult ShowSizeProduct()
        {
            return Ok(iSize.ShowSizeProduct());
        }


        [HttpPost]
        public IActionResult UpdateSize(MSize Size)
        {
            if (ModelState.IsValid)
            {
                var Result=iSize.UpdateSize(Size);
                if (Result)
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
