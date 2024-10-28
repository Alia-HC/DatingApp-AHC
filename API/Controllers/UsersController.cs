using API.Data;
using API.DataEntities;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Authorize]
    public class UsersController : BaseApicontroller
    {
        private readonly IUserRepository _repository;

        public UsersController(IUserRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<MemberResponse>>> GetAllAsync()
        {
            var users = await _repository.GetAllAsync();

            return Ok(users);
        }

       [Authorize]
        [HttpGet("{id:int}")] 
        public async Task<ActionResult<MemberResponse>> GetByIdAsync(int id)
        {
            var user = await _repository.GetByIdAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        [HttpGet("{username}")] 
        public async Task<ActionResult<MemberResponse>> GetByUsernameAsync(string username)
        {
            var user = await _repository.GetByUsernameAsync(username);

            if (user == null) return NotFound();

            return user;
        }
    }
}