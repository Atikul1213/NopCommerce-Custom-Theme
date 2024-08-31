using Nop.Core;
using Nop.Core.Domain.Localization;

namespace Nop.Plugin.Widgets.Ecommerce.Domain;
public class Company : BaseEntity, ILocalizedEntity
{
    public string Name { get; set; }

    public string Description { get; set; }
    public int DisplayOrder { get; set; }
    public int PictureId { get; set; }
    public bool IsActive { get; set; }
    public int CompanyType { get; set; }
    public CompanyTypes CompanyTypes
    {
        get => (CompanyTypes)CompanyType;
        set => CompanyType = (int)value;
    }


}


public enum CompanyTypes
{
    Public = 10,
    Private = 20,
    JoinVenture = 30
};