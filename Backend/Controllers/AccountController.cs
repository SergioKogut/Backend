using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.DAL.Entities;
using System.Threading;
using Backend.Helpers;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Drawing.Imaging;


namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]



    public class AccountController : ControllerBase

    {

        private readonly EFContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        public AccountController(EFContext context, IHostingEnvironment env,
            IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
            _env = env;
        }
        //static List<AnimalViewModel> data = new List<AnimalViewModel>
        //    {
        //        new AnimalViewModel{
        //            Id=4,
        //            Name="Верблюд",
        //            Image="https://upload.wikimedia.org/wikipedia/commons/d/d4/%D0%92%D0%B5%D1%80%D0%B1%D0%BB%D1%8E%D0%B4_%D0%B2_%D0%A7%D1%83%D0%B9%D1%81%D0%BA%D0%BE%D0%B9_%D1%81%D1%82%D0%B5%D0%BF%D0%B8.jpg"
        //        },
        //         new AnimalViewModel{
        //            Id=5,
        //            Name="Білка",
        //            Image="https://ichef.bbci.co.uk/news/976/cpsprodpb/7624/production/_104444203_d03fb5eb-685c-42c3-8fa2-eea0ee2dac26.jpg"
        //        }
        //         ,
        //         new AnimalViewModel{
        //            Id=6,
        //            Name="Опосум",
        //            Image="https://i.ytimg.com/vi/MdahcBvWqNU/maxresdefault.jpg"
        //        }
        //          };
        //Get api/account/login
        [HttpPost("login")]
        public IActionResult Login([FromBody] Credentials credentials)
        {
            if (!ModelState.IsValid)
            {

                return BadRequest(new { invalid = "Problem validation" });
            }

            var user = new UserModel
            {
                Id = 1,
                Name = "Admin",
                Email = "admin@gmail.com"
            };
           
            return Ok(user);
        }




    }
}
