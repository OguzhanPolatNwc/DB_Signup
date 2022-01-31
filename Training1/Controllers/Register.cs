using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Training1.Models;

namespace Training1.Controllers;

public class Register : Controller
{
    private readonly AppDbContext _context;
    
    public Register(AppDbContext db)
    {
        _context = db;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index([Bind("Id, Username, Email, CreatedAt, Password, IsAgreed")] RegisterModel register)
    {
        var compare1 = _context.Registers.Where(i => i.Username == register.Username).FirstOrDefault();

        if (compare1 != null)
        {
            ModelState.AddModelError("Username", "Kullanici bulunmaktadir");
        }
        var compare2 = _context.Registers.Where(i => i.Email == register.Email).FirstOrDefault();

        if (compare2 != null)
        {
            ModelState.AddModelError("Email", "Kullanici bulunmaktadir");
        }

        var compare3 = _context.Registers.Where(i => i.IsAgreed == register.IsAgreed).FirstOrDefault();

        if (compare3.IsAgreed == false)
        {
            ModelState.AddModelError("IsAgreed", "Lutfen kutuyu seciniz");
        }

        if (ModelState.IsValid)
        {
            register.CreatedAt = DateTime.Now;
            _context.Add(register);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(register);
    }
}