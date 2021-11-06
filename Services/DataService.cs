using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MyBlogMvcProject.Data;
using MyBlogMvcProject.Enums;
using MyBlogMvcProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject.Services
{
    public class DataService
    {
        //Step 3: 
        private readonly ApplicationDbContext _dbContext; //This provide us with ability to talk to and use the database
        private readonly RoleManager<IdentityRole> _roleManager; //Intorducing the role manager into the DataService class via constructor injection
        private readonly UserManager<BlogUser> _userManager;

        //Constructor Injection: this give us ability to talk to database
        public DataService(ApplicationDbContext dbContext, 
                           RoleManager<IdentityRole> roleManager, 
                           UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public async Task ManageDataAsync ()
        {
            //Task 4: To programmaticallyt create the DB from the Migration 
            await _dbContext.Database.MigrateAsync();

            //Task 1: Seed a few roles into the system 
            await SeedRolesAsync();

            //Task 2: Seed a few users into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
            //If there are already roles in the system do nothing.
            if (_dbContext.Roles.Any())
            {
                return;
            }

            //Otherwise we want to create a few roles.
            //But first Create an Enum BlogRole inside the Enums folder of your project
            foreach (var role in Enum.GetNames(typeof(BlogRole)))
            {
                //I need to use the Role Manager to create roles.
                //Above I will Intorduce the role manager into the DataService class via constructor injection
               await _roleManager.CreateAsync(new IdentityRole(role));
            }

        }

        private async Task SeedUsersAsync()
        {
            //If there are already users in the system do nothing.
            if (_dbContext.Users.Any())
            {
                return;
            }

            //Otherwise introduce a user that will occupied the administrator role.
            // Step A: Create a new instance of blogUser below
            // Step A to C seed an administrator into the system
            var adminUser = new BlogUser()
            {
                Email = "joelnirano@gmail.com",
                UserName = "joelnirano@gmail.com",
                FirstName = "Joel",
                LastName = "Ogunniran",
                DisplayName = "The Professor",
                PhoneNumber = "(234) 8055 739 873",
                EmailConfirmed = true
            };

            //Step B: Use the UserManager to create a new user that is defined by the adminUser
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step C: Add this new user to the Administrator role.
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

            //Seeding Moderator into the system
            var modUser = new BlogUser()
            {
                Email = "joel912@live.co.uk",
                UserName = "joel912@live.co.uk",
                FirstName = "James",
                LastName = "Adebowale",
                DisplayName = "The other Professor",
                PhoneNumber = "(234) 807 205 3097",
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Abc&123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }

    }
}
