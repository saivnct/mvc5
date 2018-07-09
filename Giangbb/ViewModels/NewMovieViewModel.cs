using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Giangbb.FormModels;
using Giangbb.Models;

namespace Giangbb.ViewModels
{
    public class NewMovieViewModel
    {
        public IEnumerable<Genre> Genres { get; set; }
        public Movie Movie { get; set; }
    }
}