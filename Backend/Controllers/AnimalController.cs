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

    public class AnimalController : ControllerBase

    {
        
        private readonly EFContext _context;
        private readonly IConfiguration _configuration;
        private readonly IHostingEnvironment _env;
        public AnimalController(EFContext context, IHostingEnvironment env,
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
        //Get api/animal/serch

        [HttpGet("search")]
        public IActionResult Get()
        {
           // string fileDestDir = _env.ContentRootPath;
           string frontandurl = _configuration.GetValue<string>("FrontandUrl");


            string sImg = "300_";
            List<AnimalViewModel> model = _context.Animals
                 .Select(a => new AnimalViewModel
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Image = frontandurl+"/Images/" + sImg + a.Image,
                     ImageLikeCount=a.ImageLikeCount
                 }).ToList();
            return Ok(model);

        }
        //Get api/animal/create
        [HttpPost("create")]
        public IActionResult Post([FromBody] AnimalAddViewModel model)
        {
            //Random rand = new Random();
            _context.Animals.Add(new DbAnimal
            {
                Name = model.Name,
                Image = model.Image
            });
            _context.SaveChanges();
            return Ok();

        }

        //Put api/animal/addlike/{id}
        [HttpPut("addlike/{id}")]
        public IActionResult Put([FromRoute] int id)
        {
           
            var animal = _context.Animals.SingleOrDefault(x => x.Id == id);

            if (animal == null)
                return BadRequest(new { invalid = "Animal is not found" });

            animal.ImageLikeCount = animal.ImageLikeCount+1;

            _context.Update(animal);

            _context.SaveChanges();

            return Ok(id);
        }

        [HttpPost("add-base64")]
        public IActionResult AdBase64([FromBody] AnimalAddViewModel model)
        {
           
            var sizes = _configuration.GetValue<string>("ImagesSizes").Split(' ');


            string imageName = Guid.NewGuid().ToString() + ".jpg";
            string base64 = model.Image;
            if (base64.Contains(","))
            {
                base64 = base64.Split(',')[1];
            }

            var bmp = base64.FromBase64StringToImage();
            string fileDestDir = _env.ContentRootPath;
            fileDestDir = Path.Combine(fileDestDir, _configuration.GetValue<string>("ImagesPath"));

            foreach (var element in sizes)
            {
                string fileSave = Path.Combine(fileDestDir, element+"_"+imageName);
                if (bmp != null)
                {
                    int size = Convert.ToInt32(element);
                    var image = ImageHelper.CompressImage(bmp, size, size);
                    image.Save(fileSave, ImageFormat.Jpeg);
                }

            }

            _context.Animals.Add(new DbAnimal
            {
                Name = model.Name,
                Image = imageName
            });
            _context.SaveChanges();



            return Ok();

        }

        [HttpDelete("delete/{id}")]
        public IActionResult Delete([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var animal = _context.Animals.SingleOrDefault(x => x.Id == id);
            if (animal == null)
            {
                return BadRequest(new { invalid = "Animal is not found" });
            }

            _context.Remove(animal);
            _context.SaveChanges();

            return Ok(animal.Id);
        }




    }
}