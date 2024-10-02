using Core.Entities;

namespace Web.ViewModel
{
    public class MultipleModelView
    {
        public IEnumerable< MainBook> Books { get; set; }

        public IEnumerable<MainBookWithDate> mainBookWithDates { get; set; }
        public IEnumerable<MainBookWithOffer> MainBookWithOffer { get; set; }
        public MessageViewModel MessageViewModel { get; set; }









    }
}
