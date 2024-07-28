using DocumentFormat.OpenXml.Bibliography;
using DocumentFormat.OpenXml.Office2010.Excel;

using Nop.Plugin.Misc.NopStationTeams.Domain;
using Nop.Plugin.Misc.NopStationTeams.Model;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Services.Localization;
using Nop.Services.Media;
using Nop.Web.Models.Media;
using Nop.Data;
using Nop.Plugin.Misc.NopStationTeams.Services;
using Nop.Core.Caching;
using Nop.Plugin.Misc.NopStationTeams.Infrastructure;
namespace Nop.Plugin.Misc.NopStationTeams.Factories;
public class EmployeeHomeModelFactory : IEmployeeHomeModelFactory
{
    #region Fields

    private readonly ILocalizationService _localizationService;
    private readonly IPictureService _pictureService;
    private readonly EmployeeSettings _employeeSettings;
    private readonly IStaticCacheManager _staticCacheManager;
    private readonly IRepository<Employee> _employeeRepository;
    #endregion

    #region Ctor
    public EmployeeHomeModelFactory(ILocalizationService localizationService, IPictureService pictureService, EmployeeSettings employeeSettings, IRepository<Employee> employeeRepository, IStaticCacheManager staticCacheManager)
    {
        _localizationService = localizationService;
        _pictureService = pictureService;
        _employeeSettings = employeeSettings;
        _employeeRepository = employeeRepository;
        _staticCacheManager = staticCacheManager;
    }

    #endregion


    #region Method
    public async Task<IList<EmployeeHomeModel>> PrepareEmployeeHomeListModelAsync(IList<Employee> employee)
    {

        var output = await _staticCacheManager.GetAsync(NopModelCacheDefaults.PublicEmployeeAllModelKey, async()=>{

            var query = _employeeRepository.GetAll();
            if (_employeeSettings.IsMVP)
                query = query.Where(x => x.IsMVP == true).ToList();

            else if (_employeeSettings.IsCertified)
                query = query.Where(x => x.IsCertified == true).ToList();

            else if( (_employeeSettings.IsMVP == false) && (_employeeSettings.IsCertified == false) ) 
                query = query.Where(x=>(x.IsMVP == false && x.IsCertified==false)).ToList();

            var model = new List<EmployeeHomeModel>();
            foreach(var emp in query)
            {
                model.Add( await PrepareEmployeeHomeModelAsync(emp));
            }

            return model;
        });

        return output;
        /**
         var model = new List<EmployeeHomeModel>();

        foreach(var emp in employee)
        {
            if (_employeeSettings.IsMVP==true && emp.IsMVP==true)
            {
                model.Add(await PrepareEmployeeHomeModelAsync(emp));
            }

            else if (_employeeSettings.IsCertified==true && emp.IsCertified==true)
            {
                model.Add(await PrepareEmployeeHomeModelAsync(emp));

            }

            else if ( (_employeeSettings.IsMVP == false && _employeeSettings.IsCertified == false) && (emp.IsMVP==false && emp.IsCertified==false) )
            {
                model.Add(await PrepareEmployeeHomeModelAsync(emp));
            }
        }

        return model;
        */

    }

    public async Task<EmployeeHomeModel> PrepareEmployeeHomeModelAsync(Employee employee)
    {

        var picture = await _pictureService.GetPictureByIdAsync(employee.PictureId);

        var pictureModel = new PictureModel
        { 
            Id = employee.PictureId,
            AlternateText = "Picture of " + employee.Name,
            Title = "Picture of " + employee.Name,
            ThumbImageUrl = (await _pictureService.GetPictureUrlAsync(picture, 200)).Url,
            FullSizeImageUrl = (await _pictureService.GetPictureUrlAsync(picture)).Url

        };

        return new EmployeeHomeModel()
        {
            Id = employee.Id,
            Name = employee.Name,
            IsMVP = employee.IsMVP,
            IsCertified = employee.IsCertified,
            Picture = pictureModel
        };
    }

    #endregion
}
