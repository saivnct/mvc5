using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Giangbb.Models
{
    public class MembershipType
    {
        public byte Id { get; set; }
        [Required]
        public string Name { get; set; }
        public short SignUpFee { get; set; }
        public byte DurationInMonths { get; set; }
        public byte DiscoutRate { get; set; }

        public static readonly byte Unkhown = 0;
        public static readonly byte PayAsYouGo = 0;
    }
}