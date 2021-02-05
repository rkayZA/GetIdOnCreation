using System;
using System.Collections.Generic;
using System.Text;

namespace ProductListLibrary.Models
{
    public class SpecificationModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Specification { get; set; }
    }
}
