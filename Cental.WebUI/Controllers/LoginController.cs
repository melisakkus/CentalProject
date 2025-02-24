using Cental.DtoLayer.UserDtos;
using Cental.EntityLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Cental.WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController(SignInManager<AppUser> _signInManager, UserManager<AppUser> _userManager) : Controller
    {
        public async Task<IActionResult> Index()
        {
            await _signInManager.SignOutAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserLoginDto model, string? returnUrl)
        {
            AppUser user = await _userManager.FindByNameAsync(model.UserName);
            if (user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, false, false);
                if (!result.Succeeded)
                {
                    await _userManager.AccessFailedAsync(user);
                    int failCount = await _userManager.GetAccessFailedCountAsync(user);
                    if (failCount == 3)
                    {
                        await _userManager.SetLockoutEndDateAsync(user, new DateTimeOffset(DateTime.Now.AddMinutes(1)));
                        ModelState.AddModelError("Kilitlenme", "Art arda 3 başarısız giriş denemesi yaptığınızdan dolayı hesabınız 1 dakikalığına kitlenmiştir. ");
                    }
                    else
                    {
                        if (result.IsLockedOut)
                        {
                            ModelState.AddModelError("Kilitlenme", "Bekleme süresi dolunca tekrar deneyiniz. ");
                        }
                        else
                        {
                            ModelState.AddModelError(string.Empty, "Kullanıcı adı veya şifre hatalı");
                        }
                    }
                    return View(model);
                }

                await _userManager.ResetAccessFailedCountAsync(user);
                if (returnUrl != null)
                {
                    return Redirect(returnUrl);
                }

                var userRoles = await _userManager.GetRolesAsync(user);
                foreach (var role in userRoles)
                {
                    if (role == "Admin")
                    {
                        return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
                    }

                    if (role == "Manager")
                    {
                        return RedirectToAction("Index", "Booking", new { area = "Manager" });
                    }

                    if (role == "User")
                    {
                        return RedirectToAction("Index", "Booking", new { area = "User" });
                    }

                }
                return RedirectToAction("Index", "Default");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Böyle bir kullanıcı bulunmamaktadır.");
                return View(model);
            }
        }

            public async Task<IActionResult> Logout()
            {
                await _signInManager.SignOutAsync();
                return RedirectToAction("Index", "Login");

            }

        }
    }
