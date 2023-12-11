using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using WebApp.Models;
using WebApp.Service.IService;
using WebApp.Utility;

namespace WebApp.Controllers
{
    public class AuthController : Controller
    {
        private readonly IAuthService _authService;
        private readonly ITokenProvider _tokenProvider;
        public AuthController(IAuthService authService, ITokenProvider tokenProvider)
        {
            _authService = authService;
            _tokenProvider = tokenProvider;
        }

        [HttpGet]
        public IActionResult Login()
        {
            LoginRequestDTO loginRequestDTO = new();
            return View(loginRequestDTO);
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginRequestDTO loginRequest)
        {
            ResponseDTO response = await _authService.LoginAsync(loginRequest);
            if (response != null && response.IsSuccess)
            {
                LoginResponseDTO loginResponseDTO = JsonConvert.DeserializeObject<LoginResponseDTO>(Convert.ToString(response.Result));
                _tokenProvider.SetToken(loginResponseDTO.Token);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("CustomError", response.Message);
                return View(loginRequest);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var roleList = new List<SelectListItem>()
            {
                new SelectListItem { Text = StaticDetails.RoleAdmin, Value = StaticDetails.RoleAdmin},
                new SelectListItem { Text = StaticDetails.RoleCustomer, Value = StaticDetails.RoleCustomer}
            };

            ViewBag.RoleList = roleList;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegistrationRequestDTO regRequest)
        {
            ResponseDTO response = await _authService.RegisterAsync(regRequest);
            ResponseDTO assignRole;
            if (response != null && response.IsSuccess)
            {
                if (string.IsNullOrEmpty(regRequest.Role))
                {
                    regRequest.Role = StaticDetails.RoleCustomer;
                }
                assignRole = await _authService.AssignRoleAsync(regRequest);
                if (assignRole != null && assignRole.IsSuccess)
                {
                    TempData["success"] = "Registration Successful";
                    return RedirectToAction(nameof(Login));
                }
            }

            var roleList = new List<SelectListItem>()
            {
                new SelectListItem { Text = StaticDetails.RoleAdmin, Value = StaticDetails.RoleAdmin},
                new SelectListItem { Text = StaticDetails.RoleCustomer, Value = StaticDetails.RoleCustomer}
            };

            ViewBag.RoleList = roleList;
            return View(regRequest);
        }

        public IActionResult Logout()
        {
            return View();
        }
    }
}