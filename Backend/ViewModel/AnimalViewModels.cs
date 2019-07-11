using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Backend.ViewModel
{
    public class AnimalViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public int ImageLikeCount { get; set; }

    }


    public class UserModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

       
    }



    public class AnimalAddViewModel
    {
        public string Name { get; set; }
        public string Image { get; set; }

        
    }

    public class AnimalAddLikeViewModel
    {
        public int Id { get; set; }
      
        public int ImageLikeCount { get; set; }
    }






    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

        public string Price { get; set; }

    }
}



