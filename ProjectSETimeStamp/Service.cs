using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSETimeStamp
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


                if (objDP.Count() > 0 && objIDD.Count() > 0 && objLevel.Count() > 0)
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
            if (container.Filter != null)
            {
                var filter = container.Filter;
                using (TimestampEntities tx = new TimestampEntities())
                {
                    var obj = tx.Employee.Where(x => (x.EmpID.ToString() == filter.ID)).FirstOrDefault();
                    if (obj != null)
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
    }
}
