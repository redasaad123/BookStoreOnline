using Core.Entities;
using System.Collections.Generic;

namespace Web.ViewModel
{
    public class MainBook 
    {
        public string Id { get; set; }

        public string NameBook { get; set; }
        public decimal Price { get; set; }

        public string PhotoUrl { get; set; }
        public string PdfUrl { get; set; }
        public DateTime? Date { get; set; }

        public bool? IsOffer { get; set; }

        public double? Discount { get; set; }
        public string? Description { get; set; }

        public bool? IsClickedInBasket { get; set; }
        public bool? IsClickedInBookMark { get; set; }
        public string? NumberOfPage { get; set; }
        public string? releaseYears { get; set; }
        public int NumberSales { get; set; }






    }
}
