﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WordPressTests;

namespace WordpressAutomation
{
    public class LoginPage
    {
        


        //public static void Main() {
        //    var cl = new LoginPage();
        //    cl.Go();
        //}

        public static void GoTo()
        {
            Driver.Instance.Navigate().GoToUrl(Driver.BaseAddress+@"wp-login.php");
            var wait = new WebDriverWait(Driver.Instance, TimeSpan.FromSeconds(10));
            wait.Until(s => s.SwitchTo().ActiveElement().GetAttribute("id") == "user_login");
            
            
        }

        public static LoginCommand LogInAs(String userName)
        {
            var loginCommand = new LoginCommand();
            loginCommand.userName = userName;
            return loginCommand;
            
        }

        public static void doLogin()
        {
            LoginPage.GoTo();
            LoginPage.LogInAs("arun").withPassword("arun12").Login();
            Assert.IsTrue(Driver.Instance.Title == "Dashboard ‹ iBlog — WordPress");
            Assert.IsTrue(DashboardPage.IsAt, "Failed to Login");
        }

        public class LoginCommand
        {
            internal string userName;
            internal string password;

        public LoginCommand withPassword(string v)
            {
                this.password = v;
                return this;
            }

            public void Login()
            {
                var loginInput = Driver.Instance.FindElement(By.Id("user_login"));
                loginInput.SendKeys(userName);

                var passwordInput = Driver.Instance.FindElement(By.Id("user_pass"));
                passwordInput.SendKeys(password);

                var loginButton = Driver.Instance.FindElement(By.Id("wp-submit"));
                loginButton.Click();
            }

            
        }
    }
}
