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
    public class BanerController : ControllerBase
    {
        private readonly IBaner iBaner;
        public BanerController(IBaner IBaner)
        {
            iBaner = IBaner;
        }
        [HttpPost]
        public IActionResult AddBaner(MBaner Baner)
        {
            if (ModelState.IsValid)
            {
                iBaner.AddBaner(Baner);
                return Ok("عملیات با موفقیت انجام شد");

            }

            return BadRequest();

        }

        [HttpPost]
        public IActionResult DeleteBaner(int id)
        {
            var result = iBaner.DeleteBaner(id);
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
        public IActionResult ShowActiveImageBaner()
        {
            return Ok(iBaner.ShowActiveImageBaner());
        }

        [HttpPost]
        public IActionResult ShowProductBaner(int IdBaner)
        {
            return Ok(iBaner.ShowProductBaner(IdBaner));
        }


        [HttpPost]
        public IActionResult UpdateBaner(MBaner Baner)
        {
            if (ModelState.IsValid)
            {
                var result = iBaner.UpdateBaner(Baner);
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
