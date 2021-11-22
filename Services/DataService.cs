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
<<<<<<< HEAD
        public DataService(ApplicationDbContext dbContext,
                           RoleManager<IdentityRole> roleManager,
=======
        public DataService(ApplicationDbContext dbContext, 
                           RoleManager<IdentityRole> roleManager, 
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
                           UserManager<BlogUser> userManager)
        {
            _dbContext = dbContext;
            _roleManager = roleManager;
            _userManager = userManager;
        }

<<<<<<< HEAD
        public async Task ManageDataAsync()
        {
            //Task 4: To programmaticallyt create the DataBase(DB) from the Migration instead of maually typing Updat-Database
=======
        public async Task ManageDataAsync ()
        {
            //Task 4: To programmaticallyt create the DB from the Migration 
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
            await _dbContext.Database.MigrateAsync();

            //Task 1: Seed a few roles into the system 
            await SeedRolesAsync();

            //Task 2: Seed a few users into the system
            await SeedUsersAsync();
        }

        private async Task SeedRolesAsync()
        {
<<<<<<< HEAD
            //If there are already roles in the system, do nothing.
=======
            //If there are already roles in the system do nothing.
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
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
<<<<<<< HEAD
                await _roleManager.CreateAsync(new IdentityRole(role));
=======
               await _roleManager.CreateAsync(new IdentityRole(role));
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
            }

        }

        private async Task SeedUsersAsync()
        {
<<<<<<< HEAD
            //If there are already User in the system, do nothing.
=======
            //If there are already users in the system do nothing.
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
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

<<<<<<< HEAD
            //Step B: Use the UserManager to create a new user that is defined by the adminUser variable
=======
            //Step B: Use the UserManager to create a new user that is defined by the adminUser
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
            await _userManager.CreateAsync(adminUser, "Abc&123!");

            //Step C: Add this new user to the Administrator role.
            await _userManager.AddToRoleAsync(adminUser, BlogRole.Administrator.ToString());

<<<<<<< HEAD
            //Seeding Moderator into the system i.e. Repeat above step A to C
            //Step A
=======
            //Seeding Moderator into the system
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
            var modUser = new BlogUser()
            {
                Email = "joel912@live.co.uk",
                UserName = "joel912@live.co.uk",
                FirstName = "James",
                LastName = "Adebowale",
                DisplayName = "The other Professor",
<<<<<<< HEAD
                PhoneNumber = "(234) 808 838 5040",
=======
                PhoneNumber = "(234) 807 205 3097",
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
                EmailConfirmed = true
            };

            await _userManager.CreateAsync(modUser, "Abc&123!");
            await _userManager.AddToRoleAsync(modUser, BlogRole.Moderator.ToString());

        }
<<<<<<< HEAD
    }
}
=======

    }
}
>>>>>>> 3f01bee6813313ce190a9462f70acece2ef81951
