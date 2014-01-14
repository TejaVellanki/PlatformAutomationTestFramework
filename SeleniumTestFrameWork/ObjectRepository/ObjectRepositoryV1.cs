namespace MoBankUI.ObjectRepository
{
    public static class CollectionMapV1
    {
        //*[@id="categoryList"]/div/ul/li[1]/div/div/a/h3


        public const string Categorylink = "//*[@id='categoryList']/div/article";
        public const string Cat = "/a/span/span[1]/h3";
        public const string Products = "//*[@id='productList']/li";
        public const string Productlink = "/div/div[1]/a/img";
        public const string ProductPrice = "price";
        public const string ProductDescriptiontab = "//html/body/div/div[4]/div/div[2]/div[2]/div/div/h4/a/span";
        public const string ProductDescription = "//div[@id='mainContent']/div/div[2]/div[2]/div/div/div";

        public const string Detail =
            "css=html.ui-mobile body#page-products-details.ui-mobile-viewport div#main-" +
            "page.ui-page div#mainContent.ui-content div.productDetailsContent div.ui-grid-a div.ui-block-b div.ui-collapsible-set div.ui-collapsible div.ui-collapsible-content";

        public const string Producttitle = "//*[@id='mainContent']/div/div[1]/div[1]/h2";

        public const string ProductVariant = "Variants_0__OptionValue";
        public const string Productvariant2 = "OptionValue";
        public const string Addtobasket = "AddToBasket";
        public const string Checkout = "//*[@id='GoToCheckout']/span";

        public const string Deletebasket = "button.ui-btn-hidden";
        public const string Homeimage = "//div[@id='main-page']/div[3]/a/img";
    }

    public static class FooterV1
    {
        public const string Footer = "//html/body/div/div[3]/ul/li";
        public const string Footerlink = "/div/div/a";
        public const string Sociallin = "//html/body/div/div[3]/div/a";
        public const string Sociallink = "/img";
        public const string Mopowered = "//html/body/div/div[3]/p/a";
        public const string Lowerfooter = "//html/body/div/div[3]/p[2]/a";
        public const string Lowerfooterlink = "";
    }

    public static class BasketV1
    {
        public const string Basketempty = "//form[@id='UpdateBasketForm']/ul/li";
        public const string basketvalue = "//a[@id='BasketInfo']";
    }

    public static class ImagesV1
    {
        public const string Homepageimage = "//body[@id='page-home-index']/div/div[2]/div/img";
        public const string Categoryimage = "//body[@id='page-categories-details']/div/div[2]/div/img";
        public const string Categoryimagecss = "img.categoryImage";
        public const string productimage = "  //*[@id='main-page']/div[5]/div[2]/div[1]/div[1]/ul/li";
        public const string productimagelink = "/img";
        public const string multiproductimage = "css = li.flex - active - slide > img";
    }

    public static class AddressMapV1
    {
        public const string submitbutton =
            "//body[@id='page-checkout-process']/div/div[2]/div/form/fieldset/div[2]/div/button";

        public const string field = "//body[@id='page-checkout-process']/div/div[2]/div/form/section/div";
        public const string sendletters = "/fieldset/div[2]/div/label/span/span[2]";
        public const string fieldlabel = "/label";
        public const string fieldinput = "/div/input";
        public const string fieldcountry = "FormData_";
        public const string coutryvalue = "__Value";
    }

    public static class CheckoutMapV1
    {
//*[@id="main-page"]/div[9]/div/div[2]/div/button
        //*[@id="checkoutForm"]/section/div/div[5]/fieldset/div[2]/div/label/span
        public const string submitterms = "//div[@id='main-page']/div[9]/div/div[2]/div/button";

        public const string termsncond =
            "//*[@id='checkoutForm']/section/div/div[5]/fieldset/div[2]/div/label/span/span";

        public const string paybutton = "//a[@id='PayButton']/span/span";
    }
}