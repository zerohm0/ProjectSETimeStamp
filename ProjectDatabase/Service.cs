using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace ProjectDatabase
{
    public class Service
    {

        public Container Login(string User, string Pass)
        {
            var ret = new Container();




            using (TimestampEntities ctx = new TimestampEntities())
            {
                var obj = ctx.Employee.Where(x => x.EmpID.ToString() == User && x.EmpPass.ToString() == Pass).AsQueryable();
                if (obj.Count() > 0)
                {
                    ret.Status = true;
                    ret.ResultObj = obj.FirstOrDefault();
                    ret.Message = "Login Successful";
                }
                else
                {
                    ret.Status = false;
                    ret.Message = " Username & password Incorrect";
                }
            }



            return ret;
        }

        public Container GetAuthen()
        {
            var ret = new Container();
            using (TimestampEntities tx = new TimestampEntities())
            {
                var obj = from Emp in tx.Employee
                          join Permis in tx.Permission on Emp.PermisID equals Permis.PermisID
                          select new { รหัสพนักงาน = Emp.EmpID, ชื่อ = Emp.EmpFName, นามสกุล = Emp.EmpLName, อีเมล = Emp.EmpEmail, รหัสผ่าน = Emp.EmpPass, สิทธิ์การใช้งาน = Permis.PermisLevel };
                if (obj.Count() > 0)
                {
                    ret.Status = true;
                    ret.ResultObj = obj.ToList();
                    ret.Message = "Get Successes";
                }
                else
                {
                    ret.Status = false;
                    ret.Message = "Get Failed";
                }
            }
            return ret;
        }

        public Container AuthenSearch(string keyword)
        {
            var ret = new Container();
            using (TimestampEntities tx = new TimestampEntities())
            {
                var obj = from Emp in tx.Employee
                          join Permis in tx.Permission on Emp.PermisID equals Permis.PermisID
                          where Emp.EmpID.ToString().Contains(keyword) || Emp.EmpFName.ToString().Contains(keyword) || Emp.EmpLName.ToString().Contains(keyword) || Permis.PermisLevel.Contains(keyword)
                          select new { รหัสพนักงาน = Emp.EmpID, ชื่อ = Emp.EmpFName, นามสกุล = Emp.EmpLName, อีเมล = Emp.EmpEmail, รหัสผ่าน = Emp.EmpPass, สิทธิ์การใช้งาน = Permis.PermisLevel };

                if (obj.Count() > 0)
                {
                    ret.Status = true;
                    ret.ResultObj = obj.ToList();
                    ret.Message = "SearchSuccesses";

                }
                //else
                //{
                //    ret.Status = false;
                //    ret.Message="Searc"
                //}
            }


            return ret;
        }

        public Container getList()
        {
            var ret = new Container();
            using (TimestampEntities tx = new TimestampEntities())
            {
                var objDP = from emp in tx.Employee select emp.EmpDepart;
                var objIDD = from emp in tx.Employee select emp.EmpID;
                var objLevel = from per in tx.Permission select per.PermisLevel;


                if (objDP.Count() > 0 && objIDD.Count()>0 && objLevel.Count() >0)
                {
                    ret.ResultObj = objDP.ToList();
                    ret.ResultObj = objIDD.ToList();
                    ret.ResultAnotherOneBiteTheDust = objLevel.ToList();
                }
            }

                return ret;
        }

        public Container EmployEdit(Container container)
        {
            var ret = new Container();
            if (container.Filter != null) {
                var filter = container.Filter;
                using (TimestampEntities tx = new TimestampEntities())
                {
                    var obj = tx.Employee.Where(x => (x.EmpID.ToString() == filter.ID)).FirstOrDefault();
                    if(obj != null)
                    {
                        ret.Status = true;
                        obj.EmpFName = filter.Name;
                        //obj.EmpLName = filter.LName;
                        obj.EmpDepart = filter.Department;
                        var findIDofLevel = tx.Permission.Where(x => (x.PermisLevel == filter.Level)).Select(x => x.PermisID).FirstOrDefault();
                        obj.PermisID = findIDofLevel;
                        tx.SaveChanges();

                        ret.Message = "Change Success";
                    }
                    else
                    {
                        ret.Status = false;
                        ret.Message = "Failed";
                    }
                }
            }
            return ret;
        }
            //public Container Authentication(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.Username != "" && filter.Password != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.UserAuthentication.Where(x => x.UserAuthen_Name == filter.Username && x.UserAuthen_Password == filter.Password).AsQueryable();
            //                if (obj.Count() > 0)
            //                {
            //                    ret.Status = true;
            //                    ret.ResultObj = obj.FirstOrDefault();
            //                    ret.Message = "Login Successful";
            //                }
            //                else
            //                {
            //                    ret.Status = false;
            //                    ret.Message = " Username & password Incorrect";
            //                }
            //            }
            //        }
            //    }

            //    return ret;


            //}

            //public Container AppProSearch(Container container)
            //{
            //    var ret = new Container();
            //    try
            //    {
            //        if (container.Filter != null)
            //        {
            //            var filter = container.Filter;

            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var list = ctx.Applications.Where(x => x.Application_Name.Contains(filter.AppSearch)
            //                 || x.Application_Des.Contains(filter.AppSearch)
            //                 || x.Application_Code.Contains(filter.AppSearch)
            //                 || x.Application_Status.Contains(filter.AppSearch)
            //                 || x.Application_URL.Contains(filter.AppSearch)).AsQueryable();
            //                ///Linq For Search
            //                if (list.Count() > 0)
            //                {
            //                    var output = (from c in list
            //                                  select new AuthenticationModel
            //                                  {
            //                                      AppCode = c.Application_Code,
            //                                      AppName = c.Application_Name,
            //                                      AppDes = c.Application_Des,
            //                                      AppStatus = c.Application_Status,
            //                                      AppURL = c.Application_URL
            //                                  });
            //                    ret.Status = true;
            //                    ret.ResultObj = output.ToList();//list.ToList();
            //                }
            //                else
            //                {
            //                    var res = ctx.Applications.AsQueryable();
            //                    var output = (from c in res
            //                                  select new AuthenticationModel
            //                                  {
            //                                      AppCode = c.Application_Code,
            //                                      AppName = c.Application_Name,
            //                                      AppDes = c.Application_Des,
            //                                      AppStatus = c.Application_Status,
            //                                      AppURL = c.Application_URL
            //                                  });
            //                    ret.Status = true;
            //                    ret.ResultObj = output;
            //                }
            //            }

            //        }
            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;

            //}

            //public Container AppMenuSearch(string _MenuID, string _KeySearch)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        if (_KeySearch != null && _KeySearch.Length != 0 && _KeySearch != "" && _KeySearch != " ")
            //        {

            //            var output = from ApplicationMenu in ctx.ApplicationMenu where ApplicationMenu.Application_Code == _MenuID && ApplicationMenu.AppMenu_Name.Contains(_KeySearch) select new { MenuID = ApplicationMenu.AppMenu_ID, MenuName = ApplicationMenu.AppMenu_Name, MenuDisplay = ApplicationMenu.AppMenu_Display, AppCode = ApplicationMenu.Application_Code };

            //            ///Linq For Search
            //            if (output.Count() > 0)
            //            {

            //                ret.Status = true;
            //                ret.ResultObj = output.ToList();
            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }
            //        else
            //        {
            //            var output = from ApplicationMenu in ctx.ApplicationMenu where ApplicationMenu.Application_Code == _MenuID select new { MenuID = ApplicationMenu.AppMenu_ID, MenuName = ApplicationMenu.AppMenu_Name, MenuDisplay = ApplicationMenu.AppMenu_Display, AppCode = ApplicationMenu.Application_Code };

            //            //var res = ctx.ApplicationMenu.AsQueryable();
            //            if (output.Count() > 0)
            //            {

            //                ret.Status = true;
            //                ret.ResultObj = output.ToList();
            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppMenuGetList()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from ApplicationMenu in ctx.ApplicationMenu select new { MenuID = ApplicationMenu.AppMenu_ID, MenuName = ApplicationMenu.AppMenu_Name, MenuDisplay = ApplicationMenu.AppMenu_Display, AppCode = ApplicationMenu.Application_Code };

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppProGetNameList()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from Applications in ctx.Applications select Applications.Application_Name;

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
            //public Container RoleGetNameList()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from Role in ctx.Role select Role.Role_Name;

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container PermissGetNameList()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from Permissions in ctx.Permissions select Permissions.Permission_Name;

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}


            //public Container AppMenuGetNameList(string _AppName)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from ApplicationMenu in ctx.ApplicationMenu
            //                     join App in ctx.Applications
            //                     on ApplicationMenu.Application_Code equals App.Application_Code
            //                     where App.Application_Name == _AppName
            //                     select ApplicationMenu.AppMenu_Name;

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
            //public Container ListOFRole(string _MenuID)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from Role in ctx.Role
            //                     join ApplicationRole in ctx.ApplicationRole
            //                     on Role.Role_ID equals ApplicationRole.Role_ID
            //                     where ApplicationRole.AppMenu_ID == _MenuID
            //                     select Role.Role_Name;

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
            //public Container AppProGet()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var AppAll = from Applications in ctx.Applications select new { AppCode = Applications.Application_Code, AppName = Applications.Application_Name, URL = Applications.Application_URL, Description = Applications.Application_Des, Status = Applications.Application_Status };
            //        if (AppAll.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = AppAll.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetItemApp(string _appCode)
            //{
            //    var ret = new Container();
            //    try
            //    {

            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.Applications.Where(x => x.Application_Code == _appCode).FirstOrDefault();
            //            if (obj != null)
            //            {
            //                ret.Status = true;
            //                ret.ResultObj = obj;
            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetItemMenu(string _MenuID)
            //{
            //    var ret = new Container();
            //    try
            //    {

            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.ApplicationMenu.Where(x => x.AppMenu_ID == _MenuID).FirstOrDefault();
            //            if (obj != null)
            //            {
            //                ret.Status = true;
            //                ret.ResultObj = obj;
            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetOneAppID(string _AppName)
            //{
            //    var ret = new Container();
            //    try
            //    {

            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.Applications.Where(x => x.Application_Name == _AppName).Select(x => x.Application_Code).FirstOrDefault();
            //            if (obj != null)
            //            {
            //                ret.Status = true;
            //                ret.ResultObj = obj;
            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetOneRoleID(string _AppName)
            //{
            //    var ret = new Container();
            //    try
            //    {

            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.Role.Where(x => x.Role_Name == _AppName).Select(x => x.Role_ID).FirstOrDefault();
            //            var obj2 = ctx.Role.Where(x => x.Role_Name == _AppName).Select(x => x.Role_Description).FirstOrDefault();

            //            if (obj != null)
            //            {
            //                ret.Status = true;
            //                ret.ResultID = obj;
            //                if (obj2 == null)
            //                {
            //                    ret.ResultObj = "";
            //                }
            //                else
            //                {
            //                    ret.ResultObj = obj2;
            //                }
            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetAppMenuID(string _AppMenu)
            //{
            //    var ret = new Container();
            //    try
            //    {

            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.ApplicationMenu.Where(x => x.AppMenu_Name == _AppMenu).Select(x => x.AppMenu_ID).FirstOrDefault();

            //            if (obj != null)
            //            {
            //                ret.Status = true;
            //                ret.ResultID = obj;

            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetAppRoleID(string _AppRole)
            //{
            //    var ret = new Container();
            //    try
            //    {

            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.ApplicationRole.Where(x => x.AppRole_Name == _AppRole).Select(x => x.AppRole_ID).FirstOrDefault();

            //            if (obj != null)
            //            {
            //                ret.Status = true;
            //                ret.ResultID = obj;

            //            }
            //            else
            //            {
            //                ret.Status = false;
            //            }
            //        }

            //    }
            //    catch (Exception ex)
            //    {
            //        ret.Status = false;
            //        ret.Message = ex.Message;
            //        if (ex.InnerException != null)
            //        {
            //            ret.ExceptionMessage = ex.InnerException.InnerException.Message;
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppRolePerGet()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        if (qqq.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqq.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppRoleGet()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRole in ctx.ApplicationRole /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  select new { AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        if (qqq.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqq.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppRoleSearch(string _AppName, string _MenuName, string _RoleKey)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRole in ctx.ApplicationRole /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  select new { AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        //if (_AppName != "" && _MenuName != "" && _RoleKey != "")
            //        //{
            //        var news = from Aqqq in qqq
            //                   where Aqqq.App.Contains(_AppName) && Aqqq.Menu.Contains(_MenuName) && Aqqq.Role.Contains(_RoleKey)
            //                   select Aqqq;

            //        if (news.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = news.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppPro_DeleteRow(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.Applications.Where(o => (o.Application_Code == filter.AppProCode)).FirstOrDefault();
            //                if (obj != null)
            //                {



            //                    ret.Status = true;
            //                    ctx.Applications.Remove(obj);


            //                    ctx.SaveChanges();


            //                    ret.Message = "Delete Success";
            //                }

            //            }
            //        }
            //    }
            //    return ret;
            //}

            //public Container AppMenu_DeleteRow(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.ApplicationMenu.Where(o => (o.AppMenu_ID == filter.AppProCode)).FirstOrDefault();
            //                if (obj != null)
            //                {



            //                    ret.Status = true;
            //                    ctx.ApplicationMenu.Remove(obj);


            //                    ctx.SaveChanges();


            //                    ret.Message = "Delete Success";
            //                }

            //            }
            //        }
            //    }
            //    return ret;
            //}

            //public Container RoleDelete(string _RoleID)
            //{

            //    var ret = new Container();
            //    if (_RoleID != "")
            //    {
            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.Role.Where(o => (o.Role_ID == _RoleID)).FirstOrDefault();
            //            if (obj != null)
            //            {



            //                ret.Status = true;
            //                ctx.Role.Remove(obj);


            //                ctx.SaveChanges();


            //                ret.Message = "Delete Success";
            //            }

            //        }
            //    }

            //    return ret;
            //}

            //public Container AppRoleDelete(string _ApproleID)
            //{

            //    var ret = new Container();
            //    if (_ApproleID != "")
            //    {
            //        using (TimestampEntities ctx = new TimestampEntities())
            //        {
            //            var obj = ctx.ApplicationRole.Where(o => (o.AppMenu_ID == _ApproleID)).FirstOrDefault();
            //            if (obj != null)
            //            {



            //                ret.Status = true;
            //                ctx.ApplicationRole.Remove(obj);


            //                ctx.SaveChanges();


            //                ret.Message = "Delete Success";
            //            }

            //        }
            //    }

            //    return ret;
            //}

            //public Container AppPro_StatChange(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.Applications.Where(o => (o.Application_Code == filter.AppProCode)).FirstOrDefault();
            //                if (obj != null)
            //                {



            //                    ret.Status = true;
            //                    ret.ResultObj = obj;
            //                    if (obj.Application_Status.ToString() == "Active")
            //                    {


            //                        obj.Application_Status = "Inactive";
            //                    }
            //                    else
            //                    {

            //                        obj.Application_Status = "Active";
            //                    }

            //                    ctx.SaveChanges();


            //                    ret.Message = "Status Changed";
            //                }
            //                else
            //                {

            //                    ret.Status = false;
            //                    ret.Message = "Failed";
            //                }
            //            }
            //        }
            //    }

            //    return ret;

            //}

            //public Container AppProEditGet(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "" && filter.AppProName == null)
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.Applications.Where(o => (o.Application_Code == filter.AppProCode)).FirstOrDefault();
            //                if (obj != null)
            //                {

            //                    ret.Status = true;
            //                    filter.AppProName = obj.Application_Name;
            //                    filter.AppProDes = obj.Application_Des;
            //                    filter.AppProStat = obj.Application_Status;
            //                    filter.AppProURL = obj.Application_URL;


            //                    ret.Message = "get data";
            //                }
            //                else
            //                {

            //                    ret.Status = false;
            //                    ret.Message = "Failed";
            //                }
            //            }
            //        }
            //        else if (filter.AppProCode != "" && filter.AppProName != null)
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.Applications.Where(o => (o.Application_Code == filter.AppProCode)).FirstOrDefault();

            //                if (obj != null)
            //                {

            //                    ret.Status = true;
            //                    obj.Application_Name = filter.AppProName;
            //                    obj.Application_Des = filter.AppProDes;
            //                    obj.Application_URL = filter.AppProURL;
            //                    obj.Application_Status = filter.AppProStat;



            //                    ctx.SaveChanges();

            //                    ret.Message = "Edit Success";



            //                }
            //                else
            //                {

            //                    ret.Status = false;
            //                    ret.Message = "Failed";
            //                }
            //            }
            //        }
            //    }

            //    return ret;
            //}

            //public Container RoleEdit(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;

            //        if (filter.RoleID != "" && filter.AppRoleName != null)
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.Role.Where(o => (o.Role_ID == filter.RoleID)).FirstOrDefault();

            //                if (obj != null)
            //                {

            //                    ret.Status = true;
            //                    obj.Role_Name = filter.AppRoleName;
            //                    obj.Role_Description = filter.AppRoleDes;




            //                    ctx.SaveChanges();

            //                    ret.Message = "Edit Success";



            //                }
            //                else
            //                {

            //                    ret.Status = false;
            //                    ret.Message = "Failed";
            //                }
            //            }
            //        }
            //    }

            //    return ret;
            //}

            //public Container AppProCreate(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                Applications AppIn = new Applications();

            //                ret.Status = true;

            //                AppIn.Application_Name = filter.AppProName;
            //                AppIn.Application_Code = filter.AppProCode;
            //                AppIn.Application_URL = filter.AppProURL;
            //                AppIn.Application_Des = filter.AppProDes;
            //                AppIn.Application_Status = "Active";
            //                ctx.Applications.Add(AppIn);

            //                ctx.SaveChanges();
            //                ret.Message = "Create Success";




            //            }
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //            ret.Message = "Can't Create";
            //        }
            //    }

            //    return ret;


            //}

            //public Container AppRoleCreate(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                ApplicationRole AppIn = new ApplicationRole();

            //                ret.Status = true;

            //                AppIn.AppRole_ID = filter.AppRoleID;
            //                AppIn.AppMenu_ID = filter.AppMenuID;
            //                AppIn.Role_ID = filter.RoleID;
            //                AppIn.AppRole_Name = filter.AppRoleName;
            //                AppIn.AppRole_Des = filter.AppRoleDes;
            //                ctx.ApplicationRole.Add(AppIn);

            //                ctx.SaveChanges();
            //                ret.Message = "Create Success";




            //            }
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //            ret.Message = "Can't Create";
            //        }
            //    }

            //    return ret;


            //}

            //public Container RoleCreate(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppProCode != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                Role AppIn = new Role();

            //                ret.Status = true;

            //                AppIn.Role_ID = filter.RoleID;
            //                AppIn.Role_Name = filter.AppRoleName;
            //                AppIn.Role_Description = filter.AppRoleDes;

            //                ctx.Role.Add(AppIn);

            //                ctx.SaveChanges();
            //                ret.Message = "Create Success";




            //            }
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //            ret.Message = "Can't Create";
            //        }
            //    }

            //    return ret;


            //}

            //public Container AppMenuCreate(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        if (filter.AppMenuID != "")
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                ApplicationMenu MenuIN = new ApplicationMenu();

            //                ret.Status = true;

            //                MenuIN.AppMenu_ID = filter.AppMenuID;
            //                MenuIN.AppMenu_Name = filter.AppMenuName;
            //                MenuIN.AppMenu_Display = filter.AppMenuDis;
            //                MenuIN.Application_Code = filter.AppProCode;
            //                ctx.ApplicationMenu.Add(MenuIN);

            //                ctx.SaveChanges();
            //                ret.Message = "Create Success";




            //            }
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //            ret.Message = "Can't Create";
            //        }
            //    }

            //    return ret;


            //}

            //public Container AppMenuUpdate(Container container)
            //{
            //    var ret = new Container();

            //    if (container.Filter != null)
            //    {
            //        var filter = container.Filter;
            //        //if (filter.AppMenuID != "" && filter.AppMenuName == null)
            //        //{
            //        //    using (TimestampEntities ctx = new TimestampEntities())
            //        //    {
            //        //        var obj = ctx.ApplicationMenu.Where(o => (o.AppMenu_ID == filter.AppMenuID)).FirstOrDefault();
            //        //        if (obj != null)
            //        //        {

            //        //            ret.Status = true;
            //        //            filter.AppMenuName = obj.AppMenu_Name;
            //        //            filter.AppMenuDis = obj.AppMenu_Display;
            //        //            filter.AppProCode = obj.Application_Code;


            //        //            ret.Message = "get data";
            //        //        }
            //        //        else
            //        //        {

            //        //            ret.Status = false;
            //        //            ret.Message = "Failed";
            //        //        }
            //        //    }
            //        //}
            //        if (filter.AppProCode != "" && filter.AppMenuName != null)
            //        {
            //            using (TimestampEntities ctx = new TimestampEntities())
            //            {
            //                var obj = ctx.ApplicationMenu.Where(o => (o.AppMenu_ID == filter.AppMenuID)).FirstOrDefault();

            //                if (obj != null)
            //                {

            //                    ret.Status = true;
            //                    obj.AppMenu_Name = filter.AppMenuName;
            //                    obj.AppMenu_Display = filter.AppMenuDis;
            //                    obj.Application_Code = filter.AppProCode;



            //                    ctx.SaveChanges();

            //                    ret.Message = "Edit Success";



            //                }
            //                else
            //                {

            //                    ret.Status = false;
            //                    ret.Message = "Failed";
            //                }
            //            }
            //        }
            //    }

            //    return ret;
            //}

            //public Container GetLastMenuID()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var AppAll = from ApplicationMenu in ctx.ApplicationMenu orderby ApplicationMenu.AppMenu_ID descending select ApplicationMenu.AppMenu_ID;
            //        if (AppAll.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = AppAll.FirstOrDefault();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}



            //public Container GetLastAppRoleID()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var AppAll = from ApplicationRole in ctx.ApplicationRole orderby ApplicationRole.AppRole_ID descending select ApplicationRole.AppRole_ID;
            //        if (AppAll.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = AppAll.FirstOrDefault();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetLastRoleID()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var AppAll = from Role in ctx.Role orderby Role.Role_ID descending select Role.Role_ID;
            //        if (AppAll.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = AppAll.FirstOrDefault();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetAppListForSearch()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqqTheAppName = from Orqqq in qqq group Orqqq by Orqqq.App into pg select pg.FirstOrDefault().App;
            //        if (qqqTheAppName.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqqTheAppName.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetAppMenuListForSearch(string _AppName)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqqTheAppMenuName = from Orqqq in qqq where Orqqq.App == _AppName group Orqqq by Orqqq.Menu into pg select pg.FirstOrDefault().Menu;
            //        if (qqqTheAppMenuName.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqqTheAppMenuName.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container GetAppRoleListForSearch(string _AppName, string _AppMenu)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqqTheAppMenuName = from Orqqq in qqq where Orqqq.App == _AppName && Orqqq.Menu == _AppMenu group Orqqq by Orqqq.Role into pg select pg.FirstOrDefault().Role;
            //        if (qqqTheAppMenuName.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqqTheAppMenuName.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
            //public Container GetPermissionListForSearch(string _AppName, string _AppMenu, string _Role)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqqTheAppMenuName = from Orqqq in qqq where Orqqq.App == _AppName && Orqqq.Menu == _AppMenu && Orqqq.Role == _Role group Orqqq by Orqqq.Permissions into pg select pg.FirstOrDefault().Permissions;
            //        if (qqqTheAppMenuName.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqqTheAppMenuName.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
            //public Container GetPermissionSearch(string _AppName, string _AppMenu, string _Role, string _Permission)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqqTheAppMenuName = from Orqqq in qqq where Orqqq.App.Contains(_AppName) && Orqqq.Menu.Contains(_AppMenu) && Orqqq.Role.Contains(_Role) && Orqqq.Permissions.Contains(_Permission) select Orqqq;
            //        if (qqqTheAppMenuName.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqqTheAppMenuName.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
            //public Container GetAppRoleListItHave()
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRole in ctx.ApplicationRole /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  select AppRole.AppRole_Name;
            //        if (qqq.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqq.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container getThatAppRole(Container container)
            //{
            //    var ret = new Container();
            //    var filter = container.Filter;

            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRole in ctx.ApplicationRole /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  where AppRole.AppRole_Name == filter.AppRoleName
            //                  select AppRole;

            //        var qqq2 = from AppRole in ctx.ApplicationRole /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                   join Role in ctx.Role
            //                   on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                   join AppMenu in ctx.ApplicationMenu
            //                   on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                   join App in ctx.Applications
            //                   on AppMenu.Application_Code equals App.Application_Code
            //                   where AppRole.AppRole_Name == filter.AppRoleName
            //                   select new { AppID = App.Application_Code, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqq3 = from Applications in ctx.Applications where Applications.Application_Name == qqq2.FirstOrDefault().App select Applications.Application_Code;

            //        if (qqq.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqq.FirstOrDefault();
            //            ret.ResultID = qqq2.FirstOrDefault().App;
            //            ret.ExceptionMessage = qqq3.FirstOrDefault();
            //            filter.AppRoleDes = qqq2.FirstOrDefault().Role;
            //            filter.AppMenuName = qqq2.FirstOrDefault().Menu;
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container getPermissionInShow(string _AppRoleName)
            //{
            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var qqq = from AppRolePer in ctx.ApplicationRolePermission /*group AppRole by AppRole.AppMenu_ID into pg*/
            //                  join AppRole in ctx.ApplicationRole
            //                  on AppRolePer/*pg.FirstOrDefault()*/.AppRole_ID equals AppRole.AppRole_ID
            //                  join Role in ctx.Role
            //                  on AppRole/*pg.FirstOrDefault()*/.Role_ID equals Role.Role_ID
            //                  join AppMenu in ctx.ApplicationMenu
            //                  on /*pg.FirstOrDefault()*/AppRole.AppMenu_ID equals AppMenu.AppMenu_ID
            //                  join App in ctx.Applications
            //                  on AppMenu.Application_Code equals App.Application_Code
            //                  join Permissions in ctx.Permissions
            //                  on AppRolePer.Permission_ID equals Permissions.Permission_ID
            //                  select new { RolePermission = AppRolePer.RolePer_Name, AppRole = AppRole.AppRole_Name, Role = Role.Role_Name, Permissions = Permissions.Permission_Name, App = App.Application_Name, Menu = AppMenu.AppMenu_Name, Description = Role.Role_Description };
            //        var qqq2 = from Wow in qqq where Wow.AppRole == _AppRoleName select Wow.Permissions;
            //        if (qqq2.Count() > 0)
            //        {
            //            ret.Status = true;
            //            ret.ResultObj = qqq2.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }

            //    return ret;
            //}

            //public Container GetPermissionList()
            //{

            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from Per in ctx.Permissions select Per.Permission_Name;

            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.ToList();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}

            //public Container getIDbyPerName(string _NamePer)
            //{

            //    var ret = new Container();
            //    using (TimestampEntities ctx = new TimestampEntities())
            //    {
            //        var output = from Per in ctx.Permissions where Per.Permission_Name == _NamePer select Per.Permission_ID;
            //        //var res = ctx.ApplicationMenu.AsQueryable();
            //        if (output.Count() > 0)
            //        {
            //            //    var output = (from c in res
            //            //                  select new AuthenticationModel
            //            //                  {
            //            //                      AppMenuID = c.AppMenu_ID,
            //            //                      AppName = c.AppMenu_Name,
            //            //                      AppMenuDisplay = c.AppMenu_Display,
            //            //                      AppCode = c.Application_Code,
            //            //                  });
            //            ret.Status = true;
            //            ret.ResultObj = output.FirstOrDefault();
            //        }
            //        else
            //        {
            //            ret.Status = false;
            //        }
            //    }
            //    return ret;
            //}
        }

    } 

