﻿using System.Threading.Tasks;
using Nop.Core;
using NopStation.Plugin.Widgets.AddCrawlers.Domain;

namespace NopStation.Plugin.Widgets.AddCrawlers.Services
{
    public interface ICrawlerService
    {
        Task AddOrUpdateCrawlerAsync(Crawler crawler);
        Task<IPagedList<Crawler>> GetCrawlersAsync(int pageIndex = 0, int pageSize = int.MaxValue);
    }
}