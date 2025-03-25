using ApiCatalogo.Interface;
using ApiCatalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace ApiCatalogo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        public readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("{int:id}")]
        public async Task<ActionResult<User>> GetUser(int id)  
        {
            var user = await _userRepository.GetById(id);
            if(user == null)
            {
                return BadRequest("User not null");
            }
            return Ok(user);
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            var Users = await _userRepository.GetAll();
            if (Users is null || !Users.Any())
            {
                return NotFound("Not found Users.");
            }
            return Ok(Users);
        }
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser(User user)
        {
            if (user == null)
            {
                BadRequest("User not null");
            }
            _userRepository.Add(user);

            if(await _userRepository.SavelAll())
            {
                //Aqui nessa ação são passadas a rota(Url) ao qual vai retornar após cadastrar um produto
                //Depois informa qual o id que foi cadastrado e também o Produto(Retornar um status 201).
                return CreatedAtAction(nameof(GetUser), new { id = user.Id }, user);
            }
            return BadRequest("User not found.");
        }
        [HttpPut("{id:int}")]
        public async Task<ActionResult<User>> UpdateUser(int id, User user)
        {
            if(id !=  user.Id)
            {
                return BadRequest("Error");
            }
            _userRepository.Update(user);

            if (await _userRepository.SavelAll())
            {
                return Ok(user);
            }
            return BadRequest("Error");
        }
        [HttpDelete("{id:int}")]
        public async Task<ActionResult<User>> DeleteUser(int id)
        {
            var user = await _userRepository.GetById(id);
            if(user == null)
            {
                return NotFound("User not null");
            }
            _userRepository.Delete(user);
            if (await _userRepository.SavelAll())
            {
                return Ok("sucess");
            }
            return BadRequest("Error");
        }
    }
}
