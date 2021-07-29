using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VidlyWithEntity.Dtos
{
    public class NewRentalDto
    {
        public int CustomerId { get; set; }
        public List<int> MovieIds { get; set; }
    }
}