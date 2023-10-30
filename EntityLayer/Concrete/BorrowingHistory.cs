using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public partial class BorrowingHistory
    {
        public int BorrowingId { get; set; }
        public int MemberId { get; set; }
        public int BookId { get; set; }
       
        public DateTime DueDate { get; set; }

        public virtual Book Book { get; set; } = null!;
        public virtual Member Member { get; set; } = null!;
    }
}
