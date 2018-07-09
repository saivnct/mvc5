using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Giangbb.FormModels
{
    public class MovieForm
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string ReleaseDate { get; set; }
        
        [Range(5,10)]
        public int NumberInStock { get; set; }        

        public byte GenreId { get; set; }
    }
}