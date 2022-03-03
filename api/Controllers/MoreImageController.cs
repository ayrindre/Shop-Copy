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
    public class MoreImageController : ControllerBase
    {
        private readonly IMoreImage iMoreImage;
        public MoreImageController(IMoreImage IMoreImage)
        {
            iMoreImage = IMoreImage;
        }
        [HttpPost]
        public IActionResult AddMoreImage(MMoreImage MoreImage)
        {
            if (ModelState.IsValid)
            {
                iMoreImage.AddMoreImage(MoreImage);
                return Ok("عملیات با موفقیت انجام شد");

            }

            return BadRequest();

        }

        [HttpPost]
        public IActionResult DeleteMoreImage(int id)
        {
            var result = iMoreImage.DeleteMoreImage(id);
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
        public IActionResult ShowMoreImage()
        {
            return Ok(iMoreImage.ShowMoreImage());
        }


        [HttpPost]
        public IActionResult UpdateMoreImage(MMoreImage MoreImage)
        {
            if (ModelState.IsValid)
            {
                var result = iMoreImage.UpdateMoreImage(MoreImage);
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
