using Nop.Core;
using Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Components;
using Nop.Plugin.Widgets.Ecommerce.Components;
using Nop.Services.Cms;
using Nop.Services.Localization;
using Nop.Services.Plugins;
using Nop.Web.Framework.Infrastructure;
using Nop.Web.Framework.Menu;

namespace Nop.Plugin.Widgets.Ecommerce
{
    public class EcommercePlugin : BasePlugin, IWidgetPlugin, IAdminMenuPlugin
    {
        #region Fields

        private readonly IWebHelper _webHelper;
        private readonly ILocalizationService _localizationService;

        #endregion

        #region Ctor
        public EcommercePlugin(IWebHelper webHelper, ILocalizationService localizationService)
        {
            _webHelper = webHelper;
            _localizationService = localizationService;
        }

        #endregion  

        #region Method

        public bool HideInWidgetList => false;


        public override string GetConfigurationPageUrl()
        {

            return _webHelper.GetStoreLocation() + "Admin/Company/Create";
        }


        #endregion

        #region WidgetZone
        public Type GetWidgetViewComponent(string widgetZone)
        {
            if (widgetZone == PublicWidgetZones.ProductDetailsOverviewBottom)
            {
                return typeof(PublicProductBrochureViewComponent);
            }

            if (widgetZone == AdminWidgetZones.ProductDetailsBlock)
                return typeof(AdminProductDetailsBlockAdditionWidgetZonesViewComponent);

            if (widgetZone == "admin_product_details_block_product_brochure_mapping")
                return typeof(ProductBrochureViewComponent);

            return typeof(ProductBrochureViewComponent);


        }

        public Task<IList<string>> GetWidgetZonesAsync()
        {
            return Task.FromResult<IList<string>>(
                new List<string>
                {
                PublicWidgetZones.ProductDetailsOverviewTop,
                "admin_product_details_block_product_brochure_mapping",
                AdminWidgetZones.ProductDetailsBlock,
                });
        }

        #endregion


        #region Install
        public override async Task InstallAsync()
        {

            await _localizationService.AddOrUpdateLocaleResourceAsync(GetLocaleResources());
            await base.InstallAsync();
        }

        #endregion


        #region Uninstall
        public override async Task UninstallAsync()
        {


            await _localizationService.DeleteLocaleResourcesAsync("Nop.Plugin.Widgets.Ecommerce");
            await base.UninstallAsync();
        }



        public override async Task UpdateAsync(string currentVersion, string targetVersion)
        {
            if (currentVersion != targetVersion)
            {
                await _localizationService.AddOrUpdateLocaleResourceAsync(GetLocaleResources());
            }
            await base.UpdateAsync(currentVersion, targetVersion);
        }


        public Dictionary<string, string> GetLocaleResources()
        {
            return new Dictionary<string, string>
            {

                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Name.Hint"] = "Enter employee name",
                ["Plugins.Widgets.Ecommerce.AdminMenuTitle"] = "Company",
                ["Plugins.Widgets.Ecommerce.AdminMenuTitle.List"] = "Company List",
                ["Plugins.Widgets.Ecommerce.AdminMenuTitle.Create"] = "Create Company",
                ["Admin.Widgets.Company.BackToList"] = "Back to list",
                ["Nop.Plugin.Widget.Ecommerce.Company.Info"] = "Comapany info",
                ["Admin.Widgets.Company.AddNew"] = "Add new ",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.Create.BackToList"] = "Back to List",
                ["Admin.Widgets.Ecommerce.EditDetails"] = "Edit Details",
                ["Nop.Plugin.Widget.Ecommerce.Companys"] = "Companys",
                ["Nop.Plugin.Widget.Ecommerce.Company.Created"] = "Created successfully",
                ["Nop.Plugin.Widget.Ecommerce.Company.NotFound"] = "Not found",
                ["Nop.Plugin.Widget.Ecommerce.Company.EditFailed"] = "Edit failed",
                ["Nop.Plugin.Widget.Ecommerce.Company.UpdateSuccessfully"] = "Update successfully",
                ["Nop.Plugin.Widget.Ecommerce.Company.Deleted"] = "Delete successfully",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.Create.Title"] = "Create Company",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.Create.Header"] = "Create Company",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.Edit.Titile"] = "Create Company",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.Edit.Header"] = "Create Company",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.Edit.BackToList"] = "Back to List",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.List.Title"] = "Company List",
                ["Admin.Widgets.Ecommerce.Areas.Admin.Company.List.Header"] = "Company List",


                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Name"] = "Name",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Description"] = "Description",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Description.Hint"] = "Enter the descrtion",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.DisplayOrder"] = "Display Order",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.DisplayOrder.Hint"] = "Enter Display Order.",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Picture"] = "Picture",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.Picture.Hint"] = "Enter the picture",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.IsActive"] = "Active",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.IsActive.Hint"] = "Check for active",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.CompanyTypeStr"] = "Company type",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanyModel.Fields.CompanyTypeStr.Hint"] = "Type of the company",

                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchName"] = "Name",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchName.Hint"] = "Search by company name",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchIsActive"] = "Active",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchIsActive.Hint"] = "Check by active",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchCompanyType"] = "Company Type",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Model.CompanySearchModel.Fields.SearchCompanyType.Hint"] = "Search by company type",


                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductId"] = "Product",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductId.Hint"] = "Enter the product",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ButtonText"] = "Button text",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ButtonText.Hint"] = "Enter the button text that your want to show public site",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductDownloadId"] = "Files",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.ProductDownloadId.Hint"] = "Choose your file",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.IsActive"] = "Active",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.IsActive.Hint"] = "Checked for active",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.DisplayOrder"] = "Display order",
                ["Nop.Plugin.Widgets.Ecommerce.Areas.Admin.Models.ProductBrochure.ProductBrochureModel.Fields.DisplayOrder.Hint"] = "Enter display order",
                ["NopStation.Plugin.Theme.GeneratorShop.Products.ProductBrochure.Header"] = "Product brochures",

            };
        }

        #endregion




        #region SiteMap

        public async Task ManageSiteMapAsync(SiteMapNode rootNode)
        {

            var menu = new SiteMapNode()
            {
                Title = await _localizationService.GetResourceAsync("Plugins.Widgets.Ecommerce.AdminMenuTitle"),
                Visible = true,
                IconClass = "far fa-dot-circle",
            };

            var companyList = new SiteMapNode()
            {
                Title = await _localizationService.GetResourceAsync("Plugins.Widgets.Ecommerce.AdminMenuTitle.List"),
                Visible = true,
                IconClass = "far fa-dot-circle",
                ControllerName = "Company",
                ActionName = "List",
                SystemName = "Widgets.Ecommerce.companyList",
            };

            menu.ChildNodes.Add(companyList);

            var companyCreate = new SiteMapNode()
            {
                Title = await _localizationService.GetResourceAsync("Plugins.Widgets.Ecommerce.AdminMenuTitle.Create"),
                Visible = true,
                IconClass = "far fa-dot-circle",
                ControllerName = "Company",
                ActionName = "Create",
                SystemName = "Widgets.Ecommerce.companyCreate",
            };

            menu.ChildNodes.Add(companyCreate);
            rootNode.ChildNodes.Insert(rootNode.ChildNodes.Count, menu);

        }

        #endregion

    }
}
