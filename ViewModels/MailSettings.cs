using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyBlogMvcProject.ViewModels
{
    public class MailSettings
    {
        //The MailSetting class is to store SMTP setting from Google 
        //So we can configure and use an SMTP server from google for example
        public string Mail { get; set; }
        public string DisplayName { get; set; }
        public string Password { get; set; }
        public string Host { get; set; } //SMTP SERVER
        public int Port { get; set; }
    }
}
