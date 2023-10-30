using System;
using System.Collections.Generic;

namespace EntityLayer.Concrete
{
    public partial class Member
    {
        public Member()
        {
            BorrowingHistories = new HashSet<BorrowingHistory>();
        }

        public int MemberId { get; set; }
        public string MemberFullName { get; set; } = null!;
        public string? MemberPhone { get; set; }
        public string MemberEmailAddress { get; set; } = null!;

        public virtual ICollection<BorrowingHistory> BorrowingHistories { get; set; }
    }
}
