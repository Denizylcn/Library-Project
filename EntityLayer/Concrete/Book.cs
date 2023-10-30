using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EntityLayer.Concrete
{
    public partial class Book
    {
        public Book()
        {
            BorrowingHistories = new HashSet<BorrowingHistory>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; } = null!;
        public int AuthorId { get; set; }
        public int? BookAvailabilityId { get; set; }
        public string BookImgUrl { get; set; } = null!;
     

        public virtual Author Author { get; set; } = null!;
        public virtual BookAvailability? BookAvailability { get; set; }
        public virtual ICollection<BorrowingHistory> BorrowingHistories { get; set; }
        [NotMapped]
        public IFormFile BookPicture { get; set; }
    }
}
