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
    public class ColorController : ControllerBase
    {
        private readonly IColor iColor;
        public ColorController(IColor IColor)
        {
            iColor = IColor;
        }
        [HttpPost]
        public IActionResult AddColor(MColor Color)
        {
            if (ModelState.IsValid)
            {
                iColor.AddColor(Color);
                return Ok("عملیات با موفقیت انجام شد");

            }

            return BadRequest();

        }

        [HttpPost]
        public IActionResult DeleteColor(int id)
        {
            var result = iColor.DeleteColor(id);
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
        public IActionResult ShowColorProduct()
        {
            return Ok(iColor.ShowColorProduct());
        }


        [HttpPost]
        public IActionResult UpdateColor(MColor Color)
        {
            if (ModelState.IsValid)
            {
                var result = iColor.UpdateColor(Color);
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
