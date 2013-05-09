using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webinator;
using Webinator.Enums;


namespace ObjectRepository
{
    public static class CollectionMapV1
    {
       
       
          public const string  categorylink = "//html/body/div/div[2]/div/ul/li";
          public const string  catlink =  "/div/div/a/h2";
          public const string  products ="//*[@id='page-categories-details']/div[1]/div[2]/div[1]/ul/li";
          public const string  productlink = "/div/div/a";
          public const string  ProductPrice = "//*[@id='page-products-details']/div[1]/div[2]/div/div[1]/div[1]/div/p/strong";
          public const string  ProductDescriptiontab = "//div[@id='Description']/h4/a/span";
          public const string  productDescription = "//div[@id='Description']/div/div/div/p";
          public const string  detail = "css=html.ui-mobile body#page-products-details.ui-mobile-viewport div.ui-page div.pageContent div.productDetails div.ui-content div#Description.ui-collapsible div.ui-collapsible-content";
          public const string  producttitle ="//html/body/div/div/div[2]/h2";
          public const string  productVariant = "Variants_0__OptionValue";
          public const string  productvariant2 = "OptionValue";
          public const string  LowerFooter = "//*[@id='links']/div/div/div/a[1]/img";
          public const string  poweredLink=  "https://tablet.mobankdev.com/";
          public const string  Search = "searchText";
          public const string  addtobasket = "//p[@id='AddToBasketButton']/div[2]/input";
          public const string  checkout = "//a[@id='GoToCheckout']/span/span";
          public const string  deletebasket = "//ul[@id='Basket']/li/a/span";
          public const string homeimage = "css=img";

    }
}
