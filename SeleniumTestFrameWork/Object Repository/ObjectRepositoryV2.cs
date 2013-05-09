using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using Webinator;
using Webinator.Enums;


namespace ObjectRepository
{
    public class CollectionMapV2
    {
        public const string categorylink = "//*[@id='categoryList']/div/article";
        public const string cat = "/a/span/span[1]/h3";
        public const string products = "//*[@id='productList']/article";
        public const string productlink = "/a/div[1]/img";
        public const string ProductPrice = "//html/body/div/div[4]/div/div/div[2]/div/div/p/strong";
        public const string ProductDescriptiontab = "//html/body/div/div[4]/div/div[2]/div[2]/div/div/h4/a/span";
        public const string productDescription = "//div[@id='Description']/div/div/div/p";
        public const string detail = "css=html.ui-mobile body#page-products-details.ui-mobile-viewport div#main-page.ui-page div#mainContent.ui-content div.productDetailsContent div.ui-grid-a div.ui-block-b div.ui-collapsible-set div.ui-collapsible div.ui-collapsible-content";
        public const string producttitle = "//html/body/div/div[4]/div/div/div/h2";
        public const string productVariant = "Variants_0__OptionValue";
        public const string productvariant2 = "OptionValue";
        public const string addtobasket = "//div[@id='AddToBasketButton']/div/div[2]/button";
        public const string checkout = "//div[@id='main-page']/div[7]/div/div[2]/a/span/span";
        public const string deletebasket = "//form[@id='UpdateBasketForm']/ul/li[2]/a/span";
        public const string homeimage = "//div[@id='main-page']/div[3]/a/img";

    }

}




 

  



