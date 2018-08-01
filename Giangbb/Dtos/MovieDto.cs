using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Giangbb.Models;

namespace Giangbb.Dtos
{
    //why we must use DTO? -data transfer object
    //dto is a plain data structure to transfer data from client to server

    //if we modify main object -> impact the clients => using dto reduces API breaking
    //using main object -> security hole -> hacker can easily pass addtional data into JSON
    //we can exclude some properties from mapping
    //if property names dont match, we can override the default convention
    public class MovieDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DateTime ReleaseDate { get; set; }
        public DateTime DateAdded { get; set; }
        public int NumberInStock { get; set; }
       
        public byte GenreId { get; set; }
        public Genre Genre { get; set; }
    }
}