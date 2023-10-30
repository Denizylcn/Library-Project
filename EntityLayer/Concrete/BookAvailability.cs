using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public partial class BookAvailability
    {
        public BookAvailability()
        {
            Books = new HashSet<Book>();
        }

        public int BookAvailabilityId { get; set; }
        public string? BookAvailabilityDescription { get; set; }

        public virtual ICollection<Book> Books { get; set; }
    }
}
