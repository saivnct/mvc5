using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Giangbb.FormModels;
using Giangbb.Models;

namespace Giangbb.ViewModels
{
    public class NewCustomerViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public CustomerForm CustomerForm { get; set; }
    }
}