﻿using Business.Abstract;
using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        //GetAll
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _userService.GetAll();
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //GetById
        [HttpGet("getbyid")]
        public IActionResult GetById(int id)
        {
            var result = _userService.GetByID(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //GetByUserName
        [HttpGet("getbyusername")]
        public IActionResult GetAllByUserName(string name)
        {
            var result = _userService.GetAllByUserName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //GetByUserLastName
        [HttpGet("getbylastname")]
        public IActionResult GetAllByUserLastName(string name)
        {
            var result = _userService.GetAllByUserLastName(name);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }


       
        //Add
        [HttpPost("add")]
        public IActionResult Add(User user)
        {
            var result = _userService.Add(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        //Delete
        [HttpPost("delete")]
        public IActionResult Delete(User user)
        {
            var result = _userService.Delete(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        
        //Update
        [HttpPost("update")]
        public IActionResult Update(User user)
        {
            var result = _userService.Update(user);

            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
