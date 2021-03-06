using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using VidlyWithEntity.Models;

namespace VidlyWithEntity.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}