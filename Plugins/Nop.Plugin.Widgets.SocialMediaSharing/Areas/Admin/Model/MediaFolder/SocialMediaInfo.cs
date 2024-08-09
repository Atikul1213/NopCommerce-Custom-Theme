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
        {SocialMediaPlatform.LinkedIn, new SocialMediaDetails("LinkedIn","https://www.linkedin.com/shareArticle?mini=true&url=")},
        {SocialMediaPlatform.Outlook, new SocialMediaDetails("Outlook","mailto:?")},
        {SocialMediaPlatform.Gmail, new SocialMediaDetails("Gmail","https://mail.google.com/mail/u/0/?tab=rm&ogbl#inbox?compose=new")},
        {SocialMediaPlatform.Telegram, new SocialMediaDetails("Telegram","")},
        {SocialMediaPlatform.Instagram, new SocialMediaDetails("Instagram","")},
        {SocialMediaPlatform.TikTok, new SocialMediaDetails("TikTok","")},
        {SocialMediaPlatform.YouTube, new SocialMediaDetails("YouTube","")},
        {SocialMediaPlatform.Snapchat, new SocialMediaDetails("Snapchat","")},
        {SocialMediaPlatform.Pinterest, new SocialMediaDetails("Pinterest","")},
        {SocialMediaPlatform.Reddit, new SocialMediaDetails("Reddit","")},
        {SocialMediaPlatform.WeChat, new SocialMediaDetails("WeChat","")},
        {SocialMediaPlatform.Discord, new SocialMediaDetails("Discord","")},
        {SocialMediaPlatform.Tumblr, new SocialMediaDetails("Tumblr","")},
        {SocialMediaPlatform.Clubhouse, new SocialMediaDetails("Clubhouse","")}

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
