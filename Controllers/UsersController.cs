using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PharmacyStore.Data;
using PharmacyStore.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PharmacyStore.Controllers
{
    public class UsersController : Controller
    {
        private readonly ApplicationDbContext _context;
        private UserManager<IdentityUser> userManager;

        private IPasswordHasher<IdentityUser> passwordHasher;


        public UsersController(ApplicationDbContext context, UserManager<IdentityUser> usrMgr, IPasswordHasher<IdentityUser> passwordHash)
        {
            _context = context;
            userManager = usrMgr;
            passwordHasher = passwordHash;
        }

        public IActionResult Index()
        {
            List<UserModel> lstData = new List<UserModel>();

            using (var command = _context.Database.GetDbConnection().CreateCommand())
            {
                
               command.CommandText = @"select id, username, email, phonenumber from AspNetUsers where id in (
                                        select userid from AspNetUserRoles where roleid = 2);";
                
                _context.Database.OpenConnection();

                using (var result = command.ExecuteReader())
                {
                    UserModel data;
                    while (result.Read())
                    {
                        data = new UserModel();
                        data.UserID = result.GetString(0);
                        data.UserName = result.GetString(1);
                        data.Email = result.GetString(2);
                        lstData.Add(data);
                    }
                }
            }
            return View(lstData);
        }

        public async Task<IActionResult> Edit(string id)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                return View(user);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        [HttpPost,ActionName("Edit")]
        public async Task<IActionResult> Edit(string id, string username, string email)
        {
            IdentityUser user = await userManager.FindByIdAsync(id);
            if (user != null)
            {
                if (!string.IsNullOrEmpty(username))
                    user.UserName = username;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                if (!string.IsNullOrEmpty(email))
                    user.Email = email;
                else
                    ModelState.AddModelError("", "Email cannot be empty");

                
                //if (!string.IsNullOrEmpty(phonenumber))
                //    user.PhoneNumber = phonenumber;
                //else
                //    ModelState.AddModelError("", "PhoneNumber cannot be empty");

                //if (!string.IsNullOrEmpty(password))
                //    user.PasswordHash = passwordHasher.HashPassword(user, password);
                //else
                //    ModelState.AddModelError("", "Password cannot be empty");

                if (!string.IsNullOrEmpty(email))
                {
                    IdentityResult result = await userManager.UpdateAsync(user);
                    if (result.Succeeded)
                        return RedirectToAction("Index");
                    else
                        Errors(result);
                }
            }
            else
            {
                return NotFound();
            }
            return View(user);
            
        }
        private void Errors(IdentityResult result)
        {
            foreach (IdentityError error in result.Errors)
                ModelState.AddModelError("", error.Description);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> Delete(string? id)
        { 
            IdentityUser user = await userManager.FindByIdAsync(id);

            if (user != null)
            {
                IdentityResult result = await userManager.DeleteAsync(user);
                if (result.Succeeded)
                    return RedirectToAction("Index");
                else
                    Errors(result);
            }
            else
                ModelState.AddModelError("", "User Not Found");
            return View("Index");
        }
    }
}
