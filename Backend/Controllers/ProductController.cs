using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Backend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
 
    public class ProductController : ControllerBase
    {
        //Get api/product/serch
        [HttpGet("search")]
        public IActionResult Get()
        {
            List<ProductViewModel> model = new List<ProductViewModel>
            {
                new ProductViewModel{
                    Id=4,
                    Name="Кефір",
                    Image="http://www.bigom.lviv.ua/image/cache/catalog/PRODUCTS/kefir-prostokvashino-32-500x500.jpg",
                    Price="15.20"
                },
                 new ProductViewModel{
                    Id=5,
                    Name="Йогурт",
                    Image="https://rud.ua/uploads/product/big/yogurt_abrikos_5697bcecd7996.png",
                    Price="8.70"
                }
                 ,
                 new ProductViewModel{
                    Id=6,
                    Name="Сирок",
                    Image="https://img2.zakaz.ua/20180801.1533108435.ad72436478c_2018-08-01_Ucat/20180801.1533108435.SNCPSG10.obj.0.1.jpg.oe.jpg.pf.jpg.350nowm.jpg.350x.jpg",
                    Price="13.60"
                }
            };

            Thread.Sleep(2000);
            return Ok(model);

        }
    }
}