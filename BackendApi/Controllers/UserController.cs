using Azure.Core;
using BackendApi.Contracts.User;
using Domain.Interfaces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Mapster;

namespace BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        /// <summary>
        /// Получение данных о всех пользователях
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var users = await _userService.GetAll();
            var response = users.Adapt<List<GetUserResponse>>();
            return Ok(response);
        }
        /// <summary>
        /// Получение данных о пользователе
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // GET api/<UsersController>
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _userService.GetById(id);
            var response = result.Adapt<GetUserResponse>();

            return Ok(response);
        }
        /// <summary>
        /// Создание нового пользователя
        /// </summary>
        /// <remarks>
        /// Пример запроса:
        ///
        ///     POST /Todo
        ///     {
        ///        "username" : "boba",
        ///        "pass" : "56788765",
        ///        "first_name" : "Иван",
        ///        "last_name" : "Иванов",
        ///        "email" : "qwezxc@mail.ru"
        ///     }
        ///
        /// </remarks>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // POST api/<UsersController>
        [HttpPost]
        public async Task<IActionResult> Add(CreateUserRequest request)
        {
            var userDto = request.Adapt<Customer>();
            await _userService.Create(userDto);
            return Ok();
        }
        /// <summary>
        /// Изменение данных пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // PUT api/<UsersController>
        [HttpPut]
        public async Task<IActionResult> Update(UpdateUserRequest userRequest)
        {
            var user = userRequest.Adapt<Customer>();
            await _userService.Update(user);
            return Ok();
        }
        /// <summary>
        /// Удаление пользователя
        /// </summary>
        /// <param name="model">Пользователь</param>
        /// <returns></returns>

        // DELETE api/<UsersController>
        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            await _userService.Delete(id);
            return Ok();
        }
    }
}
