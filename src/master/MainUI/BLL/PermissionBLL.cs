﻿namespace MainUI.BLL
{
    /// <summary>
    /// 权限分配业务逻辑类
    /// </summary>
    public class PermissionAllocationBLL
    {
        private readonly IFreeSql _fsql = VarHelper.fsql;

        /// <summary>
        /// 为指定角色分配权限
        /// </summary>
        public bool SetRolePermissions(int roleId, List<int> permissionIds)
        {
            try
            {
                // 检查角色是否存在且未被删除
                if (!_fsql.Select<RoleModel>()
                    .Where(r => r.ID == roleId && r.IsDelete == 0)
                    .Any())
                {
                    return false;
                }

                _fsql.Transaction(() =>
               {
                   // 删除已有的角色-权限关联
                   _fsql.Delete<User_permissionModel>()
                       .Where(rp => rp.User_id == roleId)
                       .ExecuteAffrows();

                   // 添加新的角色-权限关联
                   if (permissionIds?.Count > 0)
                   {
                       var rolePermissions = permissionIds.Select(pid => new User_permissionModel
                       {
                           User_id = roleId,
                           Permission_id = pid,
                           IsDelete = 0
                       });

                       _fsql.Insert<User_permissionModel>()
                           .AppendData(rolePermissions)
                           .ExecuteAffrows();
                   }
               });
                return true;
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"分配角色权限失败：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 获取用户权限信息
        /// </summary>
        public List<string> GetUserPermissionCodes(int roleId)
        {
            try
            {
                return _fsql.Select<User_permissionModel, PermissionModel>()
                    .LeftJoin((u, p) => u.Permission_id == p.ID)
                    .Where((u, p) => u.User_id == roleId &&
                                   u.IsDelete == 0 &&
                                   p.IsDelete == 0)
                    .ToList((u, p) => p.PermissionCode);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"获取用户权限失败：{ex.Message}");
                return [];
            }
        }

        /// <summary>
        /// 获取角色绑定的权限
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public List<User_permissionModel> GetPermissionChecks(int UserId) =>
           _fsql.Select<User_permissionModel>()
                .Where(x => x.User_id == UserId && x.IsDelete == 0)
                .ToList();

        /// <summary>
        /// 当删除权限时，删除对应的用户权限关联
        /// </summary>
        /// <param name="Permission_id"></param>
        /// <returns></returns>
        public bool DelUserPermission(int Permission_id) =>
            _fsql.Delete<User_permissionModel>()
                 .Where(x => x.Permission_id == Permission_id)
                 .ExecuteAffrows() > 0;
    }

    /// <summary>
    /// 权限管理业务逻辑类
    /// </summary>
    public class PermissionBLL
    {
        private readonly IFreeSql _fsql = VarHelper.fsql;

        #region 基础权限管理

        /// <summary>
        /// 获取所有权限列表
        /// </summary>
        public List<PermissionModel> GetPermissions() =>
            _fsql.Select<PermissionModel>()
                .Where(x => x.IsDelete == 0)
                .ToList();

        /// <summary>
        /// 执行权限操作
        /// </summary>
        private bool ExecutePermissionOperation(Func<IFreeSql, bool> operation)
        {
            try
            {
                return operation(_fsql);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"执行权限操作失败：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 新增权限信息
        /// </summary>
        public bool AddPermission(PermissionModel model) =>
            ExecutePermissionOperation(db =>
                db.Insert(model).ExecuteAffrows() > 0);

        /// <summary>
        /// 修改权限信息
        /// </summary>
        public bool UpdatePermission(PermissionModel model) =>
            ExecutePermissionOperation(db =>
                db.Update<PermissionModel>()
                  .SetSource(model)
                  .Where(x => x.ID == model.ID)
                  .ExecuteAffrows() > 0);

        /// <summary>
        /// 删除权限信息
        /// </summary>
        public bool DelPermission(int id) =>
            ExecutePermissionOperation(db =>
                db.Update<PermissionModel>()
                  .Set(x => x.IsDelete, 1)
                  .Set(x => x.DeleteTime, DateTime.Now)
                  .Where(x => x.ID == id)
                  .ExecuteAffrows() > 0);
        #endregion
    }

    /// <summary>
    /// 角色管理业务逻辑类
    /// </summary>
    public class RoleBLL
    {
        private readonly IFreeSql _fsql = VarHelper.fsql;

        /// <summary>
        /// 执行角色操作
        /// </summary>
        private bool ExecuteRoleOperation(Func<IFreeSql, bool> operation)
        {
            try
            {
                return operation(_fsql);
            }
            catch (Exception ex)
            {
                NlogHelper.Default.Error($"执行角色操作失败：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 获取所有角色
        /// </summary>
        public List<RoleModel> GetRoles() =>
            _fsql.Select<RoleModel>()
                .Where(x => x.IsDelete == 0)
                .ToList();

        /// <summary>
        /// 新增角色
        /// </summary>
        public bool AddRole(RoleModel model) =>
            ExecuteRoleOperation(db =>
                db.Insert(model).ExecuteAffrows() > 0);

        /// <summary>
        /// 更新角色
        /// </summary>
        public bool UpdateRole(RoleModel model) =>
            ExecuteRoleOperation(db =>
                db.Update<RoleModel>()
                  .SetSource(model)
                  .Where(x => x.ID == model.ID)
                  .ExecuteAffrows() > 0);

        /// <summary>
        /// 删除角色
        /// </summary>
        public bool DelRole(int id) =>
            ExecuteRoleOperation(db =>
                db.Update<RoleModel>()
                  .Set(x => x.IsDelete, 1)
                  .Set(x => x.DeleteTime, DateTime.Now)
                  .Where(x => x.ID == id)
                  .ExecuteAffrows() > 0);
    }
}
