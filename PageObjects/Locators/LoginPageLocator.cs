using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCode.PageObjects.Locators
{
    class LoginPageLocator
    {
        #region LoginPage
        public const string emailField = "//input[@id='login-username']";
        public const string passwordField = "//input[@id='login-password']";
        public const string signInButton = "//button[contains(text(),'Sign In')]";
        #endregion

        #region HomePage
        public const string profileIcon = "//button[@id='dropdownBasic1']";
        public const string signOut = "//app-header/div[1]/div[1]/div[2]/div[2]/div[1]/button[4]";
        #endregion
    }
}
