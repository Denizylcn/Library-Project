using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using DataAccesLayer.Concrete;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MemberManager : IMemberService
    {
        private libraryDBContext _context;
        IMemberDal _member;
        public MemberManager(IMemberDal member, libraryDBContext context)
        {
            _member = member;
            _context = context; 
        }
        public List<Member> GetAll()
        {
            using (var context = new libraryDBContext())
            {
                return context.Members
                    .OrderBy(x => x.MemberFullName)
                    .ToList();
            }
        }

        public Member GetById(int id)
        {
            using (var context = new libraryDBContext())
            {
                var member = context.Members.FirstOrDefault(b => b.MemberId == id);
                return member;
            }
        }
        public int GenerateUniqueMemberID()
        {
            // BorrowingID'nin en büyük mevcut değerini bulma
            int maxMemberID = _context.Members.Max(b => (int?)b.MemberId) ?? 0;

            // Yeni ID'yi oluşturma
             int newMemberID = maxMemberID + 1;

            return newMemberID;
        }
        public void TAdd(Member t)
        {
            int newMemberID = GenerateUniqueMemberID();
            Member newMember = new Member
            {
                MemberId = newMemberID,
                MemberFullName = t.MemberFullName,
                MemberEmailAddress = t.MemberEmailAddress,
                MemberPhone= t.MemberPhone,
               



            };

            _member.Insert(newMember);  
        }

        public void TDelete(Member t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(Member t)
        {
            throw new NotImplementedException();
        }
    }
}
