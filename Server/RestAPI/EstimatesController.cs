﻿using System;
using System.Linq;
using System.Threading.Tasks;
using AspCoreServer.Data;
using AspCoreServer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreServer.Controllers
{
    [Route("api/[controller]")]
    public class EstimatesController : Controller
    {
        private readonly SpaDbContext context;

        public EstimatesController(SpaDbContext context) => this.context = context;

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var results = this.context
                                    .Estimates;

            return this.Json(await results.ToListAsync());
        }

        //[HttpGet("{id}")]
        //public async Task<IActionResult> Get(int id)
        //{
            //var user = await this.context.User
            //    .Where(u => u.ID == id)
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(m => m.ID == id);

            //if (user == null)
            //{
            //    return NotFound("User not Found");
            //}
            //else
            //{
            //    return Ok(user);
            //}
        //}

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] User user)
        {
            if (!string.IsNullOrEmpty(user.Name))
            {
                this.context.Add(user);
                await this.context.SaveChangesAsync();
                return CreatedAtAction("Post", user);
            }
            else
            {
                return BadRequest("User's name was not given");
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] User userUpdateValue)
        {
            return null;
            //try
            //{
            //    userUpdateValue.EntryTime = DateTime.Now;

            //    var userToEdit = await context.User
            //        .AsNoTracking()
            //        .SingleOrDefaultAsync(m => m.ID == id);

            //    if (userToEdit == null)
            //    {
            //        return NotFound("Could not update user as it was not Found");
            //    }
            //    else
            //    {
            //        this.context.Update(userUpdateValue);
            //        await this.context.SaveChangesAsync();
            //        return Json("Updated user - " + userUpdateValue.Name);
            //    }
            //}
            //catch (DbUpdateException)
            //{
            //    //Log the error (uncomment ex variable name and write a log.)
            //    this.ModelState.AddModelError("", "Unable to save changes. " +
            //        "Try again, and if the problem persists, " +
            //        "see your system administrator.");
            //    return NotFound("User not Found");
            //}
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return null;
            //var userToRemove = await this.context.User
            //    .AsNoTracking()
            //    .SingleOrDefaultAsync(m => m.ID == id);
            //if (userToRemove == null)
            //{
            //    return NotFound("Could not delete user as it was not Found");
            //}
            //else
            //{
            //    this.context.User.Remove(userToRemove);
            //    await this.context.SaveChangesAsync();
            //    return Json("Deleted user - " + userToRemove.Name);
            //}
        }
    }
}
