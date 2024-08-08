using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nop.Plugin.Widgets.SocialMediaSharing.Areas.Admin.Model.MediaFolder;
public static class SocialMediaInfo
{

    public static readonly Dictionary<SocialMediaPlatform, SocialMediaDetails> Platforms = new Dictionary<SocialMediaPlatform, SocialMediaDetails>
    {
        {SocialMediaPlatform.Facebook, new SocialMediaDetails("Facebook","https://www.facebook.com/sharer/sharer.php?u=")},
        {SocialMediaPlatform.WhatsApp, new SocialMediaDetails("WhatsApp","https://api.whatsapp.com/send/?text=") },
        {SocialMediaPlatform.Twitter, new SocialMediaDetails("Twitter","https://twitter.com/share?url=") },
        {SocialMediaPlatform.LinkedIn, new SocialMediaDetails("LinkedIn","https://www.linkedin.com/shareArticle?mini=true&url=")}

    };

    public class SocialMediaDetails
    {
        public string Name { get; }
        public string Url { get; }


        public SocialMediaDetails(string name, string url)
        {
            Name = name;
            Url = url;
        }

    }
}
