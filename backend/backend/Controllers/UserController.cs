using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using backend.DAO;
using backend.Helpers;
using backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers
{
    [Route("api/user")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserDAO _userDAO;

        public UserController(UserDAO userDAO)
        {
            _userDAO = userDAO;
        }


        // GET: api/user
        [HttpGet]
        public List<User> Get()
        {
            return _userDAO.FindAll();
        }

        // GET: api/user/5
        [HttpGet("{id}", Name = "Get")]
        public User Get(int id)
        {
            if (id != 0)
            {
                return _userDAO.FindById(id);
            }

            return null;
        }

        // POST: api/user
        [HttpPost]
        public string Post([FromBody] User user)
        {
            if (user != null && _userDAO.FindByEmail(user.email) == 1)
            {
                _userDAO.Save(user);
                return StringProperties.SUCCESS.ToString();
            }
            else if (_userDAO.FindByEmail(user.email) == 0)
            {
                return StringProperties.EMAILEXIST;
            }
            else if (_userDAO.FindByEmail(user.email) == 2)
            {
                return StringProperties.ERROR;
            }

            return StringProperties.FAIL;
        }

        // PUT: api/user/5
        [HttpPut("{id}")]
        public string Put(int id, [FromBody] User user)
        {
            if (id != 0 && user != null)
            {
                _userDAO.Update(user);
                return StringProperties.SUCCESS;
            }
            return StringProperties.ERROR;
        }

        // DELETE: api/user/5
        [HttpDelete("{id}")]
        public string Delete(int id)
        {
            if (id != 0 && _userDAO.Delete(id) == 0)
            {
                return StringProperties.SUCCESS;

            }
            else if (_userDAO.Delete(id) == 1)
            {
                return StringProperties.FAIL;
            }

            return StringProperties.ERROR;
        }
    }
}
