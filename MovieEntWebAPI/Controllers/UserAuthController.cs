using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MovieEntWebAPI.Data;
using MovieEntWebAPI.Dtos;
using MovieEntWebAPI.Models;
using System.Security.Claims;

namespace MovieEntWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ApplicationDbContext _context;

        public UserAuthController(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager=signInManager;
            _context=context;
        }

        // GET: api/UserAuth/5
        //DONE
        [HttpPost("/loginuser")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> LoginUser(LoginModel loginModel)
        {            
                        
         var result = await _signInManager.PasswordSignInAsync(loginModel.Email
               , loginModel.Password, loginModel.RememberMe, lockoutOnFailure:false);
            
           if(!result.Succeeded)            
              return result;

          var user = await _userManager.FindByEmailAsync(loginModel.Email);            
        
            return new UserDto
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                IsAuthenticated = result.Succeeded,
                UserName=user.UserName
            };
            
        }

        [HttpPost("/registeruser")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> RegisterUser(RegisterModel registerModel)
        {
            ApplicationUser user = new ApplicationUser
            {
                Email =registerModel.Email,
                UserName=registerModel.Email,
                FirstName=registerModel.Firstname,
                LastName=registerModel.Lastname,
                PhoneNumber=registerModel.PhoneNumber,
            };

            var result=await _userManager.CreateAsync(user, registerModel.Password);
            return result;           
        }

        [HttpPost("/updateuser")]
        [AllowAnonymous]
        public async Task<ActionResult<object>> UpdateUser(UpdateUserDto updateUserDto)
        {


            var u = await _userManager.FindByEmailAsync(updateUserDto.Email);

            u.FirstName = updateUserDto.Firstname;
            u.LastName=updateUserDto.Lastname;
            u.Email=updateUserDto.Email;
            u.UserName = updateUserDto.Username;
            u.PhoneNumber=updateUserDto.PhoneNumber;

            
            var result = await _userManager.UpdateAsync(u);

            return result;
        }
    }
}
