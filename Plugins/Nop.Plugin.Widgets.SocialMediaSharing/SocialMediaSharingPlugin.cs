using Nop.Core;
using Nop.Plugin.Widgets.SocialMediaSharing.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;


namespace Nop.Plugin.Widgets.SocialMediaSharing
{
    public class SocialMediaSharingPlugin : BasePlugin, IWidgetPlugin
    {
        public bool HideInWidgetList => false;


        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;
   
        public SocialMediaSharingPlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

    


        public Type GetWidgetViewComponent(string widgetZone)
        {
            //  if (widgetZone == PublicWidgetZones.HomepageTop)
            //  {
                  return typeof(SocialMediaViewComponent);
            //}
        }


        #region WidgetZone
        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(
                new List<string> 
                {
                    PublicWidgetZones.HomepageTop,
                    
                /*    

                PublicWidgetZones.AccountNavigationAfter,
                PublicWidgetZones.AccountNavigationBefore,
                PublicWidgetZones.AddressBottom,
                PublicWidgetZones.AdminHeaderLinksAfter,
                PublicWidgetZones.ApplyVendorBottom,
                 PublicWidgetZones.ApplyVendorTop,
                 PublicWidgetZones.BlogListPageAfterPost,
                 PublicWidgetZones.BlogListPageAfterPostBody,
                 PublicWidgetZones.BlogListPageAfterPosts,
                 PublicWidgetZones.BlogListPageBeforePost,
                 PublicWidgetZones.BlogListPageBeforePostBody,
                 PublicWidgetZones.BlogListPageBeforePosts,
                 PublicWidgetZones.BlogListPageInsidePost,
                 PublicWidgetZones.BlogPostPageAfterComments,
                 PublicWidgetZones.BlogPostPageBeforeBody,
                 PublicWidgetZones.BlogPostPageBeforeComments ,
                 PublicWidgetZones.BlogPostPageBottom,
                 PublicWidgetZones.BlogPostPageInsideComment,
                PublicWidgetZones.BlogPostPageTop,
                 PublicWidgetZones.BoardsActivediscussionsAfterHeader,
                 PublicWidgetZones.BoardsActivediscussionsAfterTopics,
                 PublicWidgetZones.BoardsForumAfterHeader,
                 PublicWidgetZones.BoardsForumBottom,
                 PublicWidgetZones.BoardsForumGroupAfterHeader,
                 PublicWidgetZones.BoardsForumGroupBottom,
                 PublicWidgetZones.BoardsForumTop,
                 PublicWidgetZones.BoardsMainAfterActivediscussions,
                 PublicWidgetZones.BoardsMainAfterHeader,
                 PublicWidgetZones.BoardsMainBeforeActivediscussions,
                 PublicWidgetZones.BoardsPostCreateAfter,
                 PublicWidgetZones.BoardsPostCreateBefore,
                 PublicWidgetZones.BoardsPostEditAfter,
                 PublicWidgetZones.BoardsPostEditBefore,
                 PublicWidgetZones.BoardsSearchAfterResults,
                 PublicWidgetZones.BoardsSearchAfterSearchform,
                 PublicWidgetZones.BoardsSearchBeforeResults,
                 PublicWidgetZones.BoardsSearchBeforeSearchform,
                 PublicWidgetZones.BoardsTopicAfterHeader,
                 PublicWidgetZones.BoardsTopicBottom,
                 PublicWidgetZones.BoardsTopicCreateAfter,
                 PublicWidgetZones.BoardsTopicCreateBefore,
                 PublicWidgetZones.BoardsTopicEditAfter,
                 PublicWidgetZones.BoardsTopicEditBefore,
                 PublicWidgetZones.BoardsTopicTop,
                 PublicWidgetZones.BodyEndHtmlTagBefore,
                 PublicWidgetZones.BodyStartHtmlTagAfter,
                 PublicWidgetZones.CategoryDetailsAfterBreadcrumb,
                 PublicWidgetZones.CategoryDetailsAfterFeaturedProducts,
                 PublicWidgetZones.CategoryDetailsBeforeFeaturedProducts,
                 PublicWidgetZones.CategoryDetailsBeforeFilters,
                 PublicWidgetZones.CategoryDetailsBeforeProductList,
                 PublicWidgetZones.CategoryDetailsBeforeSubcategories,
                 PublicWidgetZones.CategoryDetailsBottom,
                 PublicWidgetZones.CategoryDetailsTop,
                 PublicWidgetZones.CheckoutBillingAddressBottom,
                 PublicWidgetZones.CheckoutBillingAddressMiddle,
                 PublicWidgetZones.CheckoutBillingAddressTop,
                 PublicWidgetZones.CheckoutCompletedBottom,
                 PublicWidgetZones.CheckoutCompletedTop,
                 PublicWidgetZones.CheckoutConfirmBottom ,
                 PublicWidgetZones.CheckoutConfirmTop ,
                 PublicWidgetZones.CheckoutPaymentInfoBottom,
                 PublicWidgetZones.CheckoutPaymentInfoTop,
                 PublicWidgetZones.CheckoutPaymentMethodBottom ,
                 PublicWidgetZones.CheckoutPaymentMethodTop,
                 PublicWidgetZones.CheckoutPickUpPointsAfter,
                 PublicWidgetZones.CheckoutProgressAfter,
                 PublicWidgetZones.CheckoutProgressBefore,
                 PublicWidgetZones.CheckoutShippingAddressBottom,
                 PublicWidgetZones.CheckoutShippingAddressMiddle,
                 PublicWidgetZones.CheckoutShippingAddressTop ,
                 PublicWidgetZones.CheckoutShippingMethodBottom ,
                 PublicWidgetZones.CheckoutShippingMethodTop,
                 PublicWidgetZones.ContactUsTop ,
                 PublicWidgetZones.ContactVendorBottom,
                 PublicWidgetZones.ContactVendorTop ,
                 PublicWidgetZones.ContentAfter ,
                 PublicWidgetZones.ContentBefore,
                 PublicWidgetZones.CustomerAddressesBottom ,
                 PublicWidgetZones.CustomerAddressesTop,
                 PublicWidgetZones.CustomerAvatarBottom ,
                 PublicWidgetZones.CustomerAvatarTop,
                 PublicWidgetZones.CustomerBackInStockSubscriptionsBottom,
                 PublicWidgetZones.CustomerBackInStockSubscriptionsTop,
                 PublicWidgetZones.CustomerChangePasswordBottom ,
                PublicWidgetZones.CustomerChangePasswordTop,
                PublicWidgetZones.CustomerCheckGiftCardBalanceBottom ,
                PublicWidgetZones.CustomerCheckGiftCardBalanceTop ,
                PublicWidgetZones.CustomerDownloadableProductsBottom ,
                PublicWidgetZones.CustomerDownloadableProductsTop ,
                PublicWidgetZones.CustomerForumSubscriptionsBottom,
                PublicWidgetZones.CustomerForumSubscriptionsTop ,
                PublicWidgetZones.CustomerGdprToolsBottom ,
                PublicWidgetZones.CustomerGdprToolsTop ,
                PublicWidgetZones.CustomerInfoBottom,
                PublicWidgetZones.CustomerInfoTop ,
                PublicWidgetZones.CustomerMultiFactorAuthenticationBottom,
                PublicWidgetZones.CustomerMultiFactorAuthenticationTop ,
                PublicWidgetZones.CustomerOrdersBottom ,
                PublicWidgetZones.CustomerOrdersTop ,
                PublicWidgetZones.CustomerProductReviewsBottom ,
                PublicWidgetZones.CustomerProductReviewsTop ,
                PublicWidgetZones.CustomerReturnRequestsBottom ,
                PublicWidgetZones.CustomerReturnRequestsTop ,
                PublicWidgetZones.CustomerRewardPointsBottom ,
                PublicWidgetZones.CustomerRewardPointsTop ,
                PublicWidgetZones. CustomerTopicDetailsBottom ,
                PublicWidgetZones. CustomerTopicDetailsTop ,
                PublicWidgetZones. Footer,
                PublicWidgetZones. HeaderAfter ,
                PublicWidgetZones. HeaderBefore ,
                PublicWidgetZones. HeaderLinksAfter ,
                PublicWidgetZones. HeaderLinksBefore ,
                PublicWidgetZones. HeaderMenuAfter ,
                PublicWidgetZones. HeaderMenuBefore ,
                PublicWidgetZones. HeaderMiddle ,
                PublicWidgetZones. HeaderSelectors,
                PublicWidgetZones. HeadHtmlTag ,
                PublicWidgetZones. HomepageBeforeBestSellers ,
                PublicWidgetZones. HomepageBeforeCategories,
                PublicWidgetZones. HomepageBeforeNews ,
                PublicWidgetZones. HomepageBeforePoll,
                PublicWidgetZones. HomepageBeforeProducts ,
                PublicWidgetZones. HomepageBottom,
                PublicWidgetZones. HomepageTop ,
                PublicWidgetZones. LeftSideColumnAfter ,
                PublicWidgetZones. LeftSideColumnAfterBlogArchive ,
                PublicWidgetZones. LeftSideColumnAfterCategoryNavigation ,
                PublicWidgetZones. LeftSideColumnBefore ,
                PublicWidgetZones. LeftSideColumnBlogAfter ,
                PublicWidgetZones. LeftSideColumnBlogBefore ,
                PublicWidgetZones. LoginBottom ,
                PublicWidgetZones. LoginTop,
                PublicWidgetZones. MainColumnAfter,
                PublicWidgetZones. MainColumnBefore ,
                PublicWidgetZones. ManufacturerDetailsAfterFeaturedProducts ,
                PublicWidgetZones. ManufacturerDetailsBeforeFeaturedProducts ,
                PublicWidgetZones. ManufacturerDetailsBeforeFilters ,
                PublicWidgetZones. ManufacturerDetailsBeforeProductList ,
                PublicWidgetZones. ManufacturerDetailsBottom ,
                PublicWidgetZones. ManufacturerDetailsTop ,
                PublicWidgetZones. MobHeaderMenuAfter ,
                PublicWidgetZones. MobHeaderMenuBefore ,
                PublicWidgetZones. NewsItemPageAfterComments ,
                PublicWidgetZones. NewsItemPageBeforeBody,
                PublicWidgetZones. NewsItemPageBeforeComments ,
                PublicWidgetZones. NewsItemPageInsideComment ,
                PublicWidgetZones. NewsListPageAfterItems ,
                PublicWidgetZones. NewsListPageBeforeItems ,
                PublicWidgetZones. NewsListPageInsideItem ,
                PublicWidgetZones. Notifications ,
                PublicWidgetZones. OpcContentAfter ,
                PublicWidgetZones. OpcContentBefore ,
                PublicWidgetZones. OpCheckoutBillingAddressBottom ,
                PublicWidgetZones. OpCheckoutBillingAddressMiddle ,
                PublicWidgetZones. OpCheckoutBillingAddressTop ,
                PublicWidgetZones. OpCheckoutConfirmBottom,
                PublicWidgetZones. OpCheckoutConfirmTop ,
                PublicWidgetZones. OpCheckoutPaymentInfoBottom ,
                PublicWidgetZones. OpCheckoutPaymentInfoTop ,
                PublicWidgetZones. OpCheckoutPaymentMethodBottom ,
                PublicWidgetZones. OpCheckoutPaymentMethodTop ,
                PublicWidgetZones. OpCheckoutShippingAddressBottom ,
                PublicWidgetZones. OpCheckoutShippingAddressMiddle ,
                PublicWidgetZones. OpCheckoutShippingAddressTop ,
                PublicWidgetZones. OpCheckoutShippingMethodBottom ,
                PublicWidgetZones. OpCheckoutShippingMethodTop ,
                PublicWidgetZones. OrderDetailsBillingAddress ,
                PublicWidgetZones. OrderDetailsPageAfterproducts ,
                PublicWidgetZones. OrderDetailsPageBeforeproducts ,
                PublicWidgetZones. OrderDetailsPageBottom ,
                PublicWidgetZones. OrderDetailsPageOverview ,
                PublicWidgetZones. OrderDetailsPageTop,
                PublicWidgetZones. OrderDetailsProductLine ,
                PublicWidgetZones. OrderDetailsShippingAddress ,
                PublicWidgetZones. OrderSummaryBillingAddress ,
                PublicWidgetZones. OrderSummaryCartFooter ,
                PublicWidgetZones. OrderSummaryContentAfter ,
                PublicWidgetZones. OrderSummaryContentBefore,
                PublicWidgetZones. OrderSummaryContentDeals ,
                PublicWidgetZones. OrderSummaryPaymentMethodInfo ,
                PublicWidgetZones. OrderSummaryShippingAddress ,
                PublicWidgetZones. OrderSummaryShippingMethodInfo ,
                PublicWidgetZones. OrderSummaryTotals ,
                PublicWidgetZones. ProductBoxAddinfoAfter ,
                PublicWidgetZones. ProductBoxAddinfoBefore,
                PublicWidgetZones. ProductBoxAddinfoMiddle ,
                PublicWidgetZones. ProductBreadcrumbAfter ,
                PublicWidgetZones. ProductBreadcrumbBefore,
                PublicWidgetZones. ProductDetailsAddInfo ,
                PublicWidgetZones. ProductDetailsAfterBreadcrumb ,
                PublicWidgetZones. ProductDetailsAfterPictures ,
                PublicWidgetZones. ProductDetailsAfterVideos ,
                PublicWidgetZones. ProductDetailsBeforeCollateral,
                PublicWidgetZones. ProductDetailsBeforePictures,
                PublicWidgetZones. ProductDetailsBeforeVideos,
                PublicWidgetZones. ProductDetailsBottom ,
                PublicWidgetZones. ProductDetailsEssentialBottom ,
                PublicWidgetZones. ProductDetailsEssentialTop,
                PublicWidgetZones. ProductDetailsInsideOverviewButtonsAfter ,
                PublicWidgetZones. ProductDetailsInsideOverviewButtonsBefore ,
                PublicWidgetZones. ProductDetailsOverviewBottom ,
                PublicWidgetZones. ProductDetailsOverviewTop ,
                PublicWidgetZones. ProductDetailsTop ,
                PublicWidgetZones. ProductPriceBottom ,
                PublicWidgetZones. ProductPriceTop ,
                PublicWidgetZones. ProductReviewsPageBottom ,
                PublicWidgetZones. ProductReviewsPageInsideReview ,
                PublicWidgetZones. ProductReviewsPageTop ,
                PublicWidgetZones. ProductsByTagBeforeProductList,
                PublicWidgetZones. ProductsByTagBottom ,
                PublicWidgetZones. ProductsByTagTop ,
                PublicWidgetZones. ProductSearchPageAdvanced ,
                PublicWidgetZones. ProductSearchPageAfterResults ,
                PublicWidgetZones. ProductSearchPageBasic ,
                PublicWidgetZones. ProductSearchPageBeforeResults ,
                PublicWidgetZones. ProfilePageInfoUserdetails ,
                PublicWidgetZones. ProfilePageInfoUserstats ,
                PublicWidgetZones. RegisterBottom ,
                PublicWidgetZones. RegisterTop ,
                PublicWidgetZones. SearchBox ,
                PublicWidgetZones. SearchBoxBeforeSearchButton ,
                PublicWidgetZones. SitemapAfter ,
                PublicWidgetZones. SitemapBefore ,
                PublicWidgetZones. VendorDetailsBottom ,
                PublicWidgetZones. VendorDetailsTop ,
                PublicWidgetZones. VendorInfoBottom ,
                PublicWidgetZones. VendorInfoTop ,
                PublicWidgetZones. WishlistBottom ,
                PublicWidgetZones. WishlistTop ,
                */


          }); 

        }
        #endregion

        public override string GetConfigurationPageUrl()
        {
            return _webHelper.GetStoreLocation() + "Admin/ShareMedia/List";
        }



        public override async Task InstallAsync()
        {

            await _localizationService.AddOrUpdateLocaleResourceAsync(new Dictionary<string, string>
            {
                ["Admin.Widget.SocialMediaSharing.Model.Name"] = "Media Name",
                ["Admin.Widget.SocialMediaSharing.Model.Url"] = "Url",
                ["Admin.Widget.SocialMediaSharing.Model.DisplayOrder"] = "DisplayOrder",
                ["Admin.Widget.SocialMediaSharing.Model.IsActive"] = "IsActive",
                ["Admin.Widget.SocialMediaSharing.Model.IconId"] = "IconId",
                ["Admin.Widget.ShareMedia.AddNew"] = "AddNew",
                ["Admin.Widget.ShareMedia.BackToList"] = "BackToList",


                ["Admin.Widget.ShareMedia"] = "ShareMedia",
                ["Admin.Widget.SocialMediaSharing.Model.Id"] = "Edit",
                ["Admin.Widget.SocialMediaSharing.Model.Icon"] = "Icon",
                ["Admin.Widget.ShareMedia.EditDetails"] = "Edit Details",


                ["Admin.SocialMediaSharing.ShareMedia"] = "Media View",
                ["Admin.SocialMediaSharing.ShareMediaOption"] = "ShareOption",
                ["Admin.ShareMediaOption.ShareOption.Fields.CustomMessage"] = "CustomMessage",
                ["Admin.ShareMediaOption.ShareOption.Fields.IncludedLink"] = "IncludedLink",
                ["Admin.ShareMediaOption.ShareOption.Fields.zone"] = "zone",
                
            });

            await base.InstallAsync();
        }


        public override Task UninstallAsync() { 
            return base.UninstallAsync(); 
        }

      
    }

}
