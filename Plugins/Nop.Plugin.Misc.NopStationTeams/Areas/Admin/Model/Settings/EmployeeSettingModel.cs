using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Web.Framework.Models;

namespace Nop.Plugin.Misc.NopStationTeams.Areas.Admin.Model.Settings;
public partial record EmployeeSettingModel : BaseNopModel, ISettingsModel
{
    public EmployeeSettingModel()
    {
        
    }

    
    public int? OrderIdent { get; set; }
    public bool IsEditAllow { get; set; }
    public bool IsEditAllow_OverrideForEmployee { get; set; }

    public bool IsCertified { get; set; }
    public bool IsCertified_OverrideForEmployee { get; set; }

    public bool IsMVP { get; set; }
    public bool IsMVP_OverrideForEmployee { get; set; }

    public bool IsDeleteAllow { get; set; }
    public bool IsDeleteAllow_OverrideForEmployee { get; set; }

    public bool AttachPdfInvoiceToAllEmployee { get; set; }
    public bool AttachPdfInvoiceToAllEmployee_OverrideForEmployee { get; set; }

    public bool AttachPdfInvoiceToCertifiedEmployee { get; set; }
    public bool AttachPdfInvoiceToCertifiedEmployee_OverrideForEmployee { get; set; }

    public bool AttachPdfInvoiceToIsMVPEmployee { get; set; }
    public bool AttachPdfInvoiceToIsMVPEmployee_OverrideForEmployee { get; set; }

    public bool AttachPdfInvoiceToCertifiedAndMVPEmployee { get; set; }
    public bool AttachPdfInvoiceToCertifiedAndMVPEmployee_OverrideForEmployee { get; set; }
    public int ActiveStoreScopeConfiguration { get; set; }
}
