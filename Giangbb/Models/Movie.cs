﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Giangbb.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
        public int NumberAvailable { get; set; }

        public Genre Genre { get; set; }

        public byte GenreId { get; set; }       
    }
}