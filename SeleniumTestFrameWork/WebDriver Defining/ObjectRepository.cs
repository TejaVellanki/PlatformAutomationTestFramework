using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Webinator;
using Webinator.Enums;


namespace objectrepository
{

    public static class CollectionMap
    {
        public static Locator


            basket     = new Locator(FindBy.Id, "BasketInfo"),
            category   = new Locator(FindBy.XPath, "//*[@id='page-home-index']/div[1]/div[2]/div[1]/ul/li[1]/div/div/a/h2"),
            Footer     = new Locator(FindBy.XPath, "//*[@id='page-home-index']/div[1]/div[3]/ul/li[1]/div/div/a"),
            LowerFooter = new Locator(FindBy.XPath, "//*[@id='social-media']/a[1]/img"),
            poweredLink = new Locator(FindBy.Text, "https://tablet.mobankdev.com/"),
            Search      = new Locator(FindBy.Name, "searchText");







    }
}

