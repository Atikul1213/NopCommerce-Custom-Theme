using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nop.Core;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Domains;
public class ShareOption : BaseEntity
{
    public int ShareMediaId { get; set; }
    public string CustomMessage { get; set; }
    public bool IncludedLink { get; set; }

    public string zone { get; set; }



}
