using Core.Entities;
using System.ComponentModel.DataAnnotations;

namespace Web.ViewModel
{
    public class MessageViewModel
    {
        public string name { get; set; }
        public string email { get; set; }

        public string subject { get; set; }

        public string message { get; set; }

    }
}
