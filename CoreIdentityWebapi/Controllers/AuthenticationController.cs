using CoreIdentityWebapi.Models;
using CoreIdentityWebapi.Models.Authentication.SignUp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NETCore.MailKit.Core;
using User.Management.Service.Models;


namespace CoreIdentityWebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IEmailService _emailService;

        public AuthenticationController(IConfiguration configuration, 
            UserManager<IdentityUser> userManager, 
            RoleManager<IdentityRole> roleManager, 
            IEmailService emailService)
        {
            _configuration = configuration;
            _userManager = userManager;
            _roleManager = roleManager;
            _emailService = emailService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterUser model, string role)
        {
            var userExists = await _userManager.FindByEmailAsync(model.Email);
            if(userExists != null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, 
                    new Response { Status = "Error", Message = "User already exists!" });
            }
            IdentityUser user = new()
            {
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };
            // Assign Role to User
            if(await _roleManager.RoleExistsAsync(role))
            {
                // Create New User
                var result = await _userManager.CreateAsync(user, model.Password);
                // If user is successfully created
                if (!result.Succeeded)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError,
                        new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });
                }
                // Assign Role to User
                await _userManager.AddToRoleAsync(user, role);
                // Create User in DB
                return StatusCode(StatusCodes.Status200OK,
                       new Response { Status = "Success", Message = "User created successfully." });
            }
            
            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        
        [HttpGet]
        public IActionResult TestEmail()
        {
            var messsage =
                new Message(new string[]
                { "vishnubhandarge90@gmail.com" } ,
                "Test Email",
                "This is a test email sent by Vishnu.");
            _emailService.SendEmail(messsage);
            return Ok(new Response { Status = "Success", Message = "Email sent successfully!" });
        }
    }
}
