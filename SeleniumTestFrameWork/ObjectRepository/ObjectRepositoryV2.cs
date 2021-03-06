﻿namespace MoBankUI.ObjectRepository
{
    public class CollectionMapV2
    {
        //*[@id="categoryList"]/div/ul/li[1]/div/div/a/h3
        //*[@id="productList"]/li[1]/div/div/a
        public const string Categorylink = " //*[@id='categoryList']/div/ul/li";
        public const string Cat = "/div/div/a/h3";
        public const string Products = "//*[@id='productList']/li";
        public const string Productlink = "/div/div/a";
        public const string ProductPrice = "price";

        public const string ProductDescriptiontab =
            "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/h4/a/span/span[1]/span";

        public const string ProductDescription =
            "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/div/span/div[1]/div/p";

        public const string Detail = "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/div/span/div[2]/div";

        public const string Producttitle = "productName";
        public const string ProductVariant = "Variants_0__OptionValue";
        public const string Productvariant2 = "OptionValue";

        public const string LowerFooter = "//*[@id='links']/div/div/div/a[1]/img";
        public const string PoweredLink = "https://tablet.mobankdev.com/";
        public const string Search = "searchText";
        public const string Homeimage = "ui-link";
        public const string Checkout = "//a[@id='GoToCheckout']/span/span";
        //*[@id="AddToBasketButton"]/div/div[2]/button
        public const string Addtobasket = "//*[@id='AddToBasketButton']/div/div[2]/button";
        public const string Deletebasket = "//form[@id='UpdateBasketForm']/ul/li/a/span";
    }

    public static class FooterV2
    {
        public const string Footer = "//*[@id='main-page']/div[6]/article";
        public const string Footerlink = "/a/span";
        public const string Sociallin = "//*[@id='links']/div/div/div/a";
        public const string Sociallink = "/img";
        public const string Mopowered = "//*[@id='copyright']/a";
        public const string Lowerfooter = "//*[@id='main-page']/div[7]/ul/li";
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

        public const string termsncond =
            "//*[@id='checkoutForm']/section/div/div[5]/fieldset/div[2]/div/label/span/span";

        public const string paybutton = "//a[@id='PayButton']/span/span";
    }
}