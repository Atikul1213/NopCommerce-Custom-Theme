using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core.Configuration;

namespace Nop.Plugin.Misc.NopStationTeams.Domain;
public partial class EmployeeSettings : ISettings
{
    public bool IsEditAllow { get; set; }
    public bool IsCertified { get; set; }

    public bool IsMVP { get; set; }
    public bool IsDeleteAllow { get; set; }

    public bool AttachPdfInvoiceToAllEmployee { get; set; }
    public bool AttachPdfInvoiceToCertifiedEmployee { get; set; }
    public bool AttachPdfInvoiceToIsMVPEmployee { get; set; }
    public bool AttachPdfInvoiceToCertifiedAndMVPEmployee { get; set; }


}
