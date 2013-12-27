﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;



namespace ObjectRepository
{
    public class CollectionMapV2
    {
<<<<<<< HEAD
        //*[@id="categoryList"]/div/article[1]/a/span/span[1]/h3
        public const string categorylink = "//*[@id='categoryList']/div/article";
        public const string cat = "/a/span/span[1]/h3";
<<<<<<< HEAD:SeleniumTestFrameWork/Object Repository/ObjectRepositoryV2.cs
<<<<<<< HEAD
<<<<<<< HEAD
        public const string ProductPrice = "//html/body/div/div[4]/div/div/div[2]/div/div/p/strong";
        public const string ProductDescriptiontab = "//html/body/div/div[4]/div/div[2]/div[2]/div/div/h4/a/span";
        public const string productDescription = "//div[@id='Description']/div/div/div/p";
=======
=======
>>>>>>> TabletView
        public const string products = "//*[@id='productList']/article";
        public const string productlink = "/a/div[1]/img";
        public const string ProductPrice = "//html/body/div/div[4]/div/div/div[2]/div/div/p/strong";
        public const string ProductDescriptiontab = "//html/body/div/div[4]/div/div[2]/div[2]/div/div/h4/a/span";
        public const string productDescription = "//div[@id='mainContent']/div/div[2]/div[2]/div/div/div";
<<<<<<< HEAD
>>>>>>> origin/TabletView
=======
>>>>>>> TabletView
=======
=======
>>>>>>> TabletView

        //*[@id="categoryList"]/div/ul/li[1]/div/div/a/h3
        //*[@id="productList"]/li[1]/div/div/a
        public const string categorylink = " //*[@id='categoryList']/div/ul/li";
        public const string cat = "/div/div/a/h3";
        public const string products = "//*[@id='productList']/li";
<<<<<<< HEAD
        public const string productlink = "/div/div[1]/a/img";
        //*[@id="productList"]/li[1]/div/div[1]/a/img
        //*[@id="productList"]/li[2]/div/div[1]/a/img
        
        public const string ProductPrice = "//*[@id='mainContent']/div/div[1]/div[2]/div/div/p/strong";
        public const string ProductDescriptiontab = "//html/body/div/div[4]/div/div[2]/div[2]/div/div/h4/a/span";
        public const string productDescription = "//div[@id='mainContent']/div/div[2]/div[2]/div/div/div";
        
>>>>>>> origin/TabletView:SeleniumTestFrameWork/ObjectRepository/ObjectRepositoryV2.cs
        public const string detail = "css=html.ui-mobile body#page-products-details.ui-mobile-viewport div#main-page.ui-page div#mainContent.ui-content div.productDetailsContent div.ui-grid-a div.ui-block-b div.ui-collapsible-set div.ui-collapsible div.ui-collapsible-content";
        public const string producttitle = "//*[@id='mainContent']/div/div[1]/div[1]/h2";
        
        public const string productVariant = "Variants_0__OptionValue";
        public const string productvariant2 = "OptionValue";
<<<<<<< HEAD
<<<<<<< HEAD
=======
=======
>>>>>>> TabletView
        public const string addtobasket = "//div[@id='AddToBasketButton']/div/div[2]/button";
        public const string checkout = "//*[@id='GoToCheckout']/span";
        
        public const string deletebasket = "//*[@id='UpdateBasketForm']/ul/li/a/span";
        public const string homeimage = "//div[@id='main-page']/div[3]/a/img";
=======
        public const string productlink = "/div/div/a";
        public const string ProductPrice = "price";
        public const string ProductDescriptiontab = "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/h4/a/span/span[1]/span";
        public const string productDescription = "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/div/span/div[1]/div/p";
        public const string detail = "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/div/span/div[2]/div";

        public const string producttitle = "productName";
        public const string productVariant = "Variants_0__OptionValue";
        public const string productvariant2 = "OptionValue";
>>>>>>> TabletView

        public const string LowerFooter = "//*[@id='links']/div/div/div/a[1]/img";
        public const string poweredLink = "https://tablet.mobankdev.com/";
        public const string Search = "searchText";
        public const string homeimage = "ui-link";
        public const string checkout = "//a[@id='GoToCheckout']/span/span";
        //*[@id="AddToBasketButton"]/div/div[2]/button
        public const string addtobasket = "//*[@id='AddToBasketButton']/div/div[2]/button";
        public const string deletebasket = "//form[@id='UpdateBasketForm']/ul/li/a/span";
        
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
        //div[@id='main-page']/div[7]/div/div[2]/a/span/span
    }
    public static class BasketV2
    {
        public const string basketempty = "//form[@id='UpdateBasketForm']/ul/li";
        public const string basketvalue = "//a[@id='BasketInfo']/span";
    }
    public static class ImagesV2
    { 
        public const string Homepageimage = "//*[@id='mainContent']/div/img";
        public const string Categoryimage = "//div[@id='mainContent']/div/img";
        public const string Categoryimagecss = "img.categoryImage";
       
        public const string productimage = "//div[@id='mainContent']/div/div[2]/div/div/ul/li";
        public const string productimagelink = "/img";
        public const string multiproductimage = "css=li.flex-active-slide";
    }
   
    public static class AddressMapV2
    {
        public const string submitbutton = "//*[@id='main-page']/div[9]/div/div[2]/div/button";
        public const string field = "//form[@id='checkoutForm']/section/div/div";
        public const string terms = "/fieldset/div[2]/div/label/span/span[2]";
        public const string fieldlabel = "/label";
        public const string fieldinput = "/div/input";
        public const string fieldcountry = "FormData_";
        public const string coutryvalue = "__Value";
    }
    public static class CheckoutMapV2
    {
        public const string submitterms = "//*[@id='main-page']/div[9]/div/div[2]/div/button";
        public const string termsncond = "//*[@id='checkoutForm']/section/div/div[5]/fieldset/div[2]/div/label/span/span";
        public const string paybutton = "//a[@id='PayButton']/span/span";
<<<<<<< HEAD
>>>>>>> origin/TabletView
=======
>>>>>>> TabletView
    }

}






  



