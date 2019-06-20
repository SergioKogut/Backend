using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Backend.DAL.Entities;
using System.Threading;

namespace Backend.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]

    public class AnimalController : ControllerBase

    {
        private readonly EFContext _context;
        public AnimalController(EFContext context)
        {
            _context = context;
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

            List<AnimalViewModel> model = _context.Animals
                 .Select(a => new AnimalViewModel
                 {
                     Id = a.Id,
                     Name = a.Name,
                     Image = a.Image
                 }).ToList();
            Thread.Sleep(3000);
            return Ok(model);

        }
        //Get api/animal/add
        [HttpPost("add")]
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
    }
}