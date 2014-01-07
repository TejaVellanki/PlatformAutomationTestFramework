namespace MoBankUI.ObjectRepository
{
    public class CollectionMapV2
    {
        //*[@id="categoryList"]/div/ul/li[1]/div/div/a/h3
        //*[@id="productList"]/li[1]/div/div/a
        public const string Categorylink = " //*[@id='categoryList']/div/ul/li";
        public const string cat = "/div/div/a/h3";
        public const string products = "//*[@id='productList']/li";
        public const string productlink = "/div/div/a";
        public const string ProductPrice = "price";

        public const string ProductDescriptiontab =
            "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/h4/a/span/span[1]/span";

        public const string productDescription =
            "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/div/span/div[1]/div/p";

        public const string detail = "//*[@id='main-page']/div[5]/div[2]/div[2]/div/div/div/span/div[2]/div";

        public const string producttitle = "productName";
        public const string productVariant = "Variants_0__OptionValue";
        public const string productvariant2 = "OptionValue";

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

        public const string termsncond =
            "//*[@id='checkoutForm']/section/div/div[5]/fieldset/div[2]/div/label/span/span";

        public const string paybutton = "//a[@id='PayButton']/span/span";
    }
}