﻿using PermissionSystem.Models;
using ViewModels.AdminWeb.Application;
using ViewModels.AdminWeb.Nav;
using ViewModels.AdminWeb.Organization;
using ViewModels.AdminWeb.Roles;
using ViewModels.AdminWeb.User;
using ViewModels.Mapper;

namespace ViewModels.AdminWeb
{
    /// <summary>
    /// </summary>
    public static class AdminMapperExtensions
    {
        #region Menu

        public static Menu ToEntity(this MenuViewModel model)
        {
            return model.MapTo<MenuViewModel, Menu>();
        }

        public static Menu ToEntity(this MenuViewModel model, Menu entity)
        {
            return model.MapTo(entity);
        }

        public static MenuViewModel ToModel(this Menu entity)
        {
            return entity.MapTo<Menu, MenuViewModel>();
        }

        #endregion

        #region PermissionSystem.Models.Application

        public static PermissionSystem.Models.Application ToEntity(this ApplicationViewModel model)
        {
            return model.MapTo<ApplicationViewModel, PermissionSystem.Models.Application>();
        }

        public static PermissionSystem.Models.Application ToEntity(this ApplicationViewModel model,
            PermissionSystem.Models.Application entity)
        {
            return model.MapTo(entity);
        }

        public static ApplicationViewModel ToModel(this PermissionSystem.Models.Application entity)
        {
            return entity.MapTo<PermissionSystem.Models.Application, ApplicationViewModel>();
        }

        #endregion

        #region  Role MappingExtension

        public static Role ToEntity(this RoleViewModel model)
        {
            return model.MapTo<RoleViewModel, Role>();
        }

        public static Role ToEntity(this RoleViewModel model, Role entity)
        {
            return model.MapTo(entity);
        }

        public static RoleViewModel ToModel(this Role entity)
        {
            return entity.MapTo<Role, RoleViewModel>();
        }

        #endregion

        #region  Organization MappingExtension

        public static PermissionSystem.Models.Organization ToEntity(this OrganizationViewModel model)
        {
            return model.MapTo<OrganizationViewModel, PermissionSystem.Models.Organization>();
        }

        public static PermissionSystem.Models.Organization ToEntity(this OrganizationViewModel model,
            PermissionSystem.Models.Organization entity)
        {
            return model.MapTo(entity);
        }

        public static OrganizationViewModel ToModel(this PermissionSystem.Models.Organization entity)
        {
            return entity.MapTo<PermissionSystem.Models.Organization, OrganizationViewModel>();
        }

        #endregion

        #region User

        public static PermissionSystem.Models.User ToEntity(this UserViewModel model)
        {
            return model.MapTo<UserViewModel, PermissionSystem.Models.User>();
        }

        public static PermissionSystem.Models.User ToEntity(this UserViewModel model,
            PermissionSystem.Models.User entity)
        {
            return model.MapTo(entity);
        }

        public static UserViewModel ToModel(this PermissionSystem.Models.User entity)
        {
            return entity.MapTo<PermissionSystem.Models.User, UserViewModel>();
        }

        #endregion
    }
}