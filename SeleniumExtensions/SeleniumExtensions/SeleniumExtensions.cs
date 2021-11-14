using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;

namespace SeleniumExt
{
    public static class SeleniumExtensions
    {
        /// <summary>
        /// This will change the focus to the alert pop-up and click the confirmation button (ok, accept, yes, etc.) and change the focus back to the default content.
        /// </summary>
        /// <param name="driver">This is the IWebDriver that is currently being used.</param>
        public static void AcceptAlert(this IWebDriver driver)
        {
            var alert = driver.SwitchTo().Alert();
            alert.Accept();
            driver.SwitchTo().DefaultContent();
        }

        /// <summary>
        /// This scrolls to an element on the page so that it is in view.
        /// </summary>
        /// <param name="driver">This is the IWebDriver that is currently being used.</param>
        /// <param name="el">This is the IWebElement that you want to scroll to to be in view.</param>
        public static void ScrollToElement(this IWebDriver driver, IWebElement el)
        {
            Actions actions = new Actions(driver);
            actions.MoveToElement(el);
            actions.Perform();
        }

        /// <summary>
        /// This uses javascript to remove the specified attribute from the specified IWebElement.
        /// </summary>
        /// <param name="driver">This is the IWebDriver that is currently being used.</param>
        /// <param name="el">This is the IWebElement that you want to remove the attribute from.</param>
        /// <param name="attr">This is the name of the attribute you want to remove.</param>
        public static void RemoveAttribute(this IWebDriver driver, IWebElement el, string attr)
        {
            IJavaScriptExecutor js = driver as IJavaScriptExecutor;
            js.ExecuteScript("arguments[0].removeAttribute('arguments[1]')", el, attr);
        }
    }
}
