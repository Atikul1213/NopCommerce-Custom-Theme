﻿using Nop.Core;
using Nop.Plugin.Widgets.NopQuickTabs.Domains;

namespace Nop.Plugin.Widgets.NopQuickTabs.Services;
public interface ITabService
{
    Task InsertTabAsync(Tab tab);

    Task UpdateTabAsync(Tab tab);

    Task DeleteTabAsync(Tab tab);

    Task<Tab> GetTabByIdAsync(int id);

    Task<IPagedList<Tab>> GetAllTabAsync(int pageIndex = 0, int pageSize = int.MaxValue);

}
