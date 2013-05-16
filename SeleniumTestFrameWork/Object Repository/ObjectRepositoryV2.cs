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
        public const string productDescription = "//div[@id='mainContent']/div/div[2]/div[2]/div/div/div";
        public const string detail = "css=html.ui-mobile body#page-products-details.ui-mobile-viewport div#main-page.ui-page div#mainContent.ui-content div.productDetailsContent div.ui-grid-a div.ui-block-b div.ui-collapsible-set div.ui-collapsible div.ui-collapsible-content";
        public const string producttitle = "//html/body/div/div[4]/div/div/div/h2";
        public const string productVariant = "Variants_0__OptionValue";
        public const string productvariant2 = "OptionValue";
        public const string addtobasket = "//div[@id='AddToBasketButton']/div/div[2]/button";
        public const string checkout = "//div[@id='main-page']/div[7]/div/div[2]/a/span/span";
        public const string deletebasket = "//form[@id='UpdateBasketForm']/ul/li[2]/a/span";
        public const string homeimage = "//div[@id='main-page']/div[3]/a/img";

    }
    public static class FooterV2
    {
        public const string footer = "//*[@id='main-page']/div[6]/article";
        public const string footerlink = "/a/span";
        public const string sociallin = "//*[@id='links']/div/div/div/a";
        public const string sociallink = "/img";
        public const string mopowered = "//*[@id='copyright']/a";
        public const string lowerfooter = "//*[@id='main-page']/div[7]/ul/li";
        public const string lowerfooterlink = "/a"; 

    }
    public static class BasketV2
    {
       public const string basketempty = "//ul[@id='Basket']/li";
    }
    public static class ImagesV2
    {
        public const string Homepageimage = "//*[@id='mainContent']/div/img";
        public const string Categoryimage = "//div[@id='mainContent']/div/img";
        public const string Categoryimagecss = "css=img.categoryImage";
        public const string productimage = "//*[@id='mainContent']/div/div[2]/div[1]/div/div/ul/li";
        public const string productimagelink = "/img";
        public const string multiproductimage = "css=li.flex-active-slide"; 


    }

    public static class AddressMapV2
    {
        public const string submitbutton = "//div[@id='main-page']/div[7]/div/div[2]/div/button";
        public const string field = "//form[@id='checkoutForm']/section/div/div";
        public const string terms = "/fieldset/div[2]/div/label/span/span[2]";
        public const string fieldlabel = "/label";
        public const string fieldinput = "/div/input";
        public const string fieldcountry = "FormData_";
        public const string coutryvalue = "__Value";
    }
    public static class CheckoutMapV2
    {
        public const string termsncond ="//form[@id='checkoutForm']/section/div/div[3]/fieldset/div[2]/div/label/span/span[2]";
        public const string paybutton = "//a[@id='PayButton']/span/span";
    }

}




 

  



