using System;
using System.Collections;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Models.Response;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class apiController : Controller
    {
        // GET
        [HttpGet]
        public IActionResult allUsers()
        {
            RequestResponse response;
            try
            {
                User user = new User();
                response = new RequestResponse(1, user.getAllUsers());
            }
            catch (Exception e)
            {
                response = new RequestResponse(0, e.Message, null);
            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult newUser(User user)
        {
            RequestResponse response;
            if (ModelState.IsValid)
            {
                try
                {
                    user = user.saveUser(user);
                    response = new RequestResponse(1, user);
                }
                catch (Exception e)
                {
                    response = new RequestResponse(0, "the user wasn't added to database \n" + e.Message, null);
                }
            }
            else
            {
                response = new RequestResponse(0, "attributes not match", null);
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult editUser(User user)
        {
            RequestResponse response;
            try
            {
                user = user.updateUser(user);
                if (user != null)
                {
                    response = new RequestResponse(1, user);
                }
                else
                {
                    response = new RequestResponse(0, "user not found or not editable", null);
                }
            }
            catch (Exception e)
            {
                response = new RequestResponse(0, e.Message, null);
            }

            return Ok(response);
        }

        [HttpDelete("{idUser}")]
        public IActionResult deleteUser(int idUser)
        {
            RequestResponse response;
            try
            {
                User user = new User();
                if (user.deleteUser(idUser) == true)
                {
                    response = new RequestResponse(1, "user deleted", null);
                }
                else
                {
                    response = new RequestResponse(0, "user not deleted", null);
                }
            }
            catch (Exception e)
            {
                response = new RequestResponse(0, e.Message, null);
            }

            return Ok(response);
        }
    }
}