using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using DataAccesLayer.Concrete;
using DataAccesLayer.EntityFramework;
using EntityLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace library.Controllers
{
    public class MemberController : Controller
    {

        MemberManager membermanager = new MemberManager(new EFMemberDal(), new libraryDBContext());
        private IMemberService _memberService;
        public MemberController(IMemberService memberService)
        {


            _memberService = memberService;


        }


        [HttpGet]
        public IActionResult CreateMember()

        {

            return View();
        }
        [HttpPost]
        public IActionResult CreateMember(Member m)

        {
            if (string.IsNullOrEmpty(m.MemberFullName) || string.IsNullOrEmpty(m.MemberPhone) || string.IsNullOrEmpty(m.MemberEmailAddress))
            {
                ViewBag.AlertMessage = "Lutfen tüm alanlari doldurunuz.";
            
                return View();
            }
            if (!m.MemberEmailAddress.Contains("@"))
            {
                ViewBag.AlertMessage = "Lutfen gecerli bir e-posta adresi girin.";
                return View();
            }





            _memberService.TAdd(m);
            return RedirectToAction("BookList", "Default");
          }

    }
}
