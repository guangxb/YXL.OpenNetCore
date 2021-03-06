﻿// =================================================================== 
// 项目说明
//====================================================================
// YXL @ CopyRight 2006-2010。
// 文件： IMenuRepository.cs
// 项目名称： 
// 创建时间：2017-05-18
// 负责人：YXL
// ===================================================================

using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Sakura.AspNetCore;
using Core;
using Core.Repository;
using PermissionSystem.Models;
using ViewModels.AdminWeb.Nav;

namespace IService
{
    public interface IMenuService : IEfRepository<Menu>
    {
        Task<IPagedList<MenuViewModel>> PageMenuViewModel(int pageSize, int pageIndex,string queryString,Guid? parentID = null);

        Task<MenuViewModel> GetMenuViewModel(Guid rid);

        Task<IEnumerable<Menu>> QueryMenuViewModel(IEnumerable<Guid> roleList);

        Task<IEnumerable<Menu>> QueryMenuViewModel(Guid userID);

        Task<Menu> SingleAsync(string areaName, string controllerName, string actionName);
    }
}