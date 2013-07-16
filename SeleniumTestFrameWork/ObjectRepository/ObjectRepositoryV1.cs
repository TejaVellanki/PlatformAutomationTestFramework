using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ObjectRepository
{
    public static class CollectionMapV1
    {
        //*[@id='categoryList']/div/article/a/span/span[1]/h3
       
        public const string categorylink = "//html/body/div/div[2]/div/ul/li";
        public const string cat = "/div/div/a/h2";
        public const string products = "//*[@id='page-categories-details']/div[1]/div[2]/div[1]/ul/li";
        public const string productlink = "/div/div/a";
        public const string ProductPrice ="//*[@id='page-products-details']/div[1]/div[2]/div/div[1]/div[1]/div/p/strong";
        public const string ProductDescriptiontab = "//div[@id='Description']/h4/a/span";
        public const string productDescription = "//div[@id='Description']/div/div/div/p";
        public const string detail ="css=html.ui-mobile body#page-products-details.ui-mobile-viewport div.ui-page div.pageContent div.productDetails div.ui-content div#Description.ui-collapsible div.ui-collapsible-content";

        public const string producttitle = "//html/body/div/div/div[2]/h2";
        public const string productVariant = "Variants_0__OptionValue";
        public const string productvariant2 = "OptionValue";

        public const string LowerFooter = "//*[@id='links']/div/div/div/a[1]/img";
        public const string poweredLink = "https://tablet.mobankdev.com/";
        public const string Search = "searchText";
        public const string homeimage = "css=img";
        public const string checkout = "//a[@id='GoToCheckout']/span/span";


        public const string addtobasket = "//*[@id='AddToBasketButton']/div/div[2]/input";
        public const string deletebasket = "//ul[@id='Basket']/li/a/span";
      

    }

    public static class FooterV1
    {
        public const string footer = "//html/body/div/div[3]/ul/li";
        public const string footerlink = "/div/div/a";
        public const string sociallin = "//html/body/div/div[3]/div/a";
        public const string sociallink = "/img";
        public const string mopowered = "//html/body/div/div[3]/p/a";
        public const string lowerfooter = "//html/body/div/div[3]/p[2]/a";
        public const string lowerfooterlink = "";
     

     
    }

    public static class BasketV1
    {
        public const string basketempty = "//form[@id='UpdateBasketForm']/ul/li";
        public const string basketvalue = "//a[@id='BasketInfo']";
    }

    public static class ImagesV1
    {
        public const string Homepageimage = "//body[@id='page-home-index']/div/div[2]/div/img";
        public const string Categoryimage = "//body[@id='page-categories-details']/div/div[2]/div/img";
        public const string Categoryimagecss = "css=img.categoryImage";
        public const string productimage = "//body[@id='page-products-details']/div/div[2]/div/div[2]/ul/li";
        public const string productimagelink = "/img";
        public const string multiproductimage = "css = li.flex - active - slide > img"; 


    }

    public static class AddressMapV1
    {
        public const string submitbutton ="//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button";
        public const string field = "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div";
        public const string sendletters = "/fieldset/div[2]/div/label/span/span[2]";
        public const string fieldlabel = "/label";
        public const string fieldinput = "/div/input";
        public const string fieldcountry = "FormData_";
        public const string coutryvalue  =  "__Value";
    }

    public static class CheckoutMapV1
    {
        public const string termsncond = "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div[5]/fieldset/div[2]/div/label/span/span";
        public const string paybutton = "//a[@id='PayButton']/span/span";
    }
}
