using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectSETimeStamp
{
    public class Service
    {

        public Container getOneManLogin(Container container)
        {
            var ret = new Container();
            var filter = container.Filter;
            using (TimestampEntities2 ctx = new TimestampEntities2())
            {
                var res = from Employ in ctx.Employee where Employ.EmpID.ToString() == filter.ID select new { id = Employ.EmpID, namess = Employ.EmpFName + " " + Employ.EmpLName ,dep=Employ.EmpDepart,pos=Employ.EmpPosit};

                if (res.Count() >0)
                {
                    ret.Status = true;
                    ret.ResultObj = res.FirstOrDefault();
                    ret.Message = res.FirstOrDefault().namess;
                    filter.Department = res.FirstOrDefault().dep;
                    filter.Detial = res.FirstOrDefault().pos;
                }
            }
            return ret;
        }
         public Container Login(string User, string Pass)
        {
            var ret = new Container();




            using (TimestampEntities2 ctx = new TimestampEntities2())
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
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.Employee
                          join Permis in tx.Permission on Emp.PermisID equals Permis.PermisID
                          select new { รหัสพนักงาน = Emp.EmpID.ToString(), ชื่อ = Emp.EmpFName, นามสกุล = Emp.EmpLName, อีเมล = Emp.EmpEmail, รหัสผ่าน = Emp.EmpPass, สิทธิ์การใช้งาน = Permis.PermisLevel };
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
        public Container GetAuthen(Container container)
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.Employee
                          join Permis in tx.Permission on Emp.PermisID equals Permis.PermisID
                          select Emp;
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

        public Container GetAPTTimestamp()
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from TS in tx.Timestamp
                          join Ty in tx.TimestampType on TS.TypeID equals Ty.TypeID
                          join Emp in tx.Employee on TS.EmpID equals Emp.EmpID
                          join St in tx.TimestampStatus on TS.StatusID equals St.StatusID
                          select new { รหัสTimestamp = TS.TimestampID, ชื่อ = Emp.EmpFName,นามสกุล = Emp.EmpLName,ประเภท = Ty.TypeName,วันที่เริ่ม = TS.TimestampFDay,วันสุดท้าย = TS.TimestampLDay, เวลาเข้างาน = TS.TimestampIn, เวลาออก = TS.TimestampOut, สถานะ = St.Status,วันที่Approve = TS.TimestampKDay};
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

        public Container GetTimesType()
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.TimestampType
                          select new { ลำดับ = Emp.TypeID, ประเภท = Emp.TypeName, รายละเอียด = Emp.TypeDetail};
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

        public Container GetEmp()
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.Employee
                          select new { รหัสพนักงาน = Emp.EmpID, ชื่อ = Emp.EmpFName, นามสกุล = Emp.EmpLName, อีเมล = Emp.EmpEmail, แผนก = Emp.EmpDepart/*,ตำแหน่ง=Emp.EmpPosit*/ };
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

        public Container GetTimestampOfMine(int IDD)
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.Timestamp
                          join TTy in tx.TimestampType on Emp.TypeID equals TTy.TypeID
                          join sta in tx.TimestampStatus on Emp.StatusID equals sta.StatusID
                          where Emp.EmpID == IDD
                          select new { รหัสพนักงาน = Emp.EmpID, ประเภท = TTy.TypeName, วันที่เริ่ม = Emp.TimestampFDay, วันที่สิ้นสุด = Emp.TimestampLDay,วันที่อนุมัติ=Emp.TimestampKDay,สถานะ = sta.Status };
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

        public Container GetHoliday()
        {
            var ret = new Container();
            using(TimestampEntities2 en = new TimestampEntities2())
            {
                var obj = from his in en.Holiday
                          join Emp in en.Employee on his.EmpID equals Emp.EmpID
                          select new { ลำดับ = his.Id, วันที่หยุด = his.Holiday1, ผู้รับผิดชอบ = Emp.EmpFName+"  "+Emp.EmpLName , วันที่แก้ไข = his.ThisDay, หมายเหตุ = his.other };

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
            using (TimestampEntities2 tx = new TimestampEntities2())
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
        public Container TimestampTypeSearch(string keyword)
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.TimestampType
                          where Emp.TypeName.ToString().Contains(keyword)
                          select new { ลำดับ = Emp.TypeID, ประเภท = Emp.TypeName, รายละเอียด = Emp.TypeDetail };

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


        public Container TimestampofMineSeaarch(string keyword,int IDD)
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.Timestamp
                join TTy in tx.TimestampType on Emp.TypeID equals TTy.TypeID
                join sta in tx.TimestampStatus on Emp.StatusID equals sta.StatusID
                where Emp.EmpID == IDD && (Emp.TimestampID.ToString().Contains(keyword)||TTy.TypeName.Contains(keyword)||Emp.TimestampFDay.ToString().Contains(keyword)||Emp.TimestampLDay.ToString().Contains(keyword)||Emp.TimestampKDay.ToString().Contains(keyword)||sta.Status.Contains(keyword))
                select new { รหัสพนักงาน = Emp.EmpID, ประเภท = TTy.TypeName, วันที่เริ่ม = Emp.TimestampFDay, วันที่สิ้นสุด = Emp.TimestampLDay, วันที่อนุมัติ = Emp.TimestampKDay, สถานะ = sta.Status };

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

        public Container EmpSearch(string keyword)
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from Emp in tx.Employee
                          where Emp.EmpID.ToString().Contains(keyword) || Emp.EmpFName.ToString().Contains(keyword) || Emp.EmpLName.ToString().Contains(keyword) || Emp.EmpPass.Contains(keyword)
                          select new { รหัสพนักงาน = Emp.EmpID, ชื่อ = Emp.EmpFName, นามสกุล = Emp.EmpLName, อีเมล = Emp.EmpEmail,แผนก=Emp.EmpDepart/*,ตำแหน่ง=Emp.EmpPosit*/};

                if (obj.Count() > 0)
                {
                    ret.Status = true;
                    ret.ResultObj = obj.ToList();
                    ret.ExceptMessage = obj.FirstOrDefault().แผนก;
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

        public Container StampSearch(string keyword)
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var obj = from TS in tx.Timestamp
                          join Ty in tx.TimestampType on TS.TypeID equals Ty.TypeID
                          join Emp in tx.Employee on TS.EmpID equals Emp.EmpID
                          join St in tx.TimestampStatus on TS.StatusID equals St.StatusID
                          select new {รหัสTimestamp = TS.TimestampID, ชื่อ = Emp.EmpFName, นามสกุล = Emp.EmpLName, ประเภท = Ty.TypeName, วันที่เริ่ม = TS.TimestampFDay, วันสุดท้าย = TS.TimestampLDay,/*เวลาเข้างาน = TS.TimestampIN,เวลาออก = TS.TimestampOut,*/สถานะ = St.Status, วันที่Approve = TS.TimestampKDay };
                var result = from rs in obj where rs.ชื่อ.Contains(keyword) || rs.นามสกุล.Contains(keyword) || rs.รหัสTimestamp.ToString().Contains(keyword) || rs.ประเภท.Contains(keyword) || rs.วันที่เริ่ม.ToString().Contains(keyword) || rs.วันสุดท้าย.ToString().Contains(keyword) || rs.สถานะ.Contains(keyword) || rs.วันที่Approve.ToString().Contains(keyword) select rs;
                if (obj.Count() > 0)
                {
                    ret.Status = true;
                    ret.ResultObj = result.ToList();
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
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var objDP = from emp in tx.Employee select emp.EmpDepart;
                var objIDD = tx.Employee.Select(x=>x.EmpID.ToString());
                var objLevel = from per in tx.Permission where per.PermisStat=="Active" select per.PermisLevel;
                ret.Status = true;

                if (objDP.Count() > 0 && objIDD.Count() > 0 && objLevel.Count() > 0)
                {
                    ret.ResultObj = objDP.ToArray();
                    ret.ResultID = objIDD.ToArray();
                    ret.ResultAnotherOneBiteTheDust = objLevel.ToArray();
                }
            }

            return ret;
        }
        public Container getList2()
        {
            var ret = new Container();
            using (TimestampEntities2 tx = new TimestampEntities2())
            {
                var objDP = from emp in tx.Employee select emp.EmpDepart;
                var objIDD = from emp in tx.Employee select emp.EmpID;
                var objLevel = from emp in tx.Employee select emp.EmpPosit;


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
                using (TimestampEntities2 tx = new TimestampEntities2())
                {
                    var obj = tx.Employee.Where(x => (x.EmpID.ToString() == filter.ID)).FirstOrDefault();
                    if (obj != null)
                    {
                        ret.Status = true;
                        obj.EmpFName = filter.Name;
                        obj.EmpLName = filter.LName;
                        obj.EmpDepart = filter.Department;
                        //var findIDofLevel = tx.Permission.Where(x => (x.PermisLevel == filter.Level)).Select(x => x.PermisID).FirstOrDefault();
                        obj.EmpPosit = filter.Level;
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

        public Container AuthenEdit(Container container)
        {
            var ret = new Container();
            if (container.Filter != null)
            {
                var filter = container.Filter;
                using (TimestampEntities2 tx = new TimestampEntities2())
                {
                    var obj = tx.Employee.Where(x => (x.EmpID.ToString() == filter.ID)).FirstOrDefault();
                    if (obj != null)
                    {
                        ret.Status = true;
                        obj.EmpFName = filter.Name;
                        obj.EmpLName = filter.LName;
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

        public Container AddTimestampType(string Type,string Detail)
        {
            var ret = new Container();
            using(TimestampEntities2 tx = new TimestampEntities2())
            {
                var getlastID = from tt in tx.TimestampType orderby tt.TypeID descending select tt.TypeID;

                TimestampType MenuIN = new TimestampType();

                ret.Status = true;

                MenuIN.TypeID = Convert.ToInt32(getlastID.FirstOrDefault()) + 1;
                MenuIN.TypeName = Type;
                MenuIN.TypeDetail = Detail;
                
                tx.TimestampType.Add(MenuIN);

                tx.SaveChanges();
                ret.Message = "Add Success";



            }
            return ret;
        }

        public Container AddHoliday(Container container)
        {
            var ret = new Container();
            if (container.Filter != null)
            {
                var filter = container.Filter;

                using(TimestampEntities2 te = new TimestampEntities2())
                {
                    Holiday hld = new Holiday();

                    ret.Status = true;

                    var lastID = from sss in te.Holiday orderby sss.Id descending select sss.Id;

                    hld.Id = Convert.ToInt32(lastID.FirstOrDefault()) + 1;
                    hld.Holiday1 = filter.dtF;
                    hld.ThisDay = filter.dtK;
                    hld.other = filter.Detial;
                    hld.EmpID = Convert.ToInt32(filter.ID);
                    hld.Depart = filter.Department;

                    te.SaveChanges();
                    ret.Message = "Create Holiday";
                }
            }
            return ret;
        }

        public Container AskTimestamp(Container container)
        {
            var ret = new Container();

            if (container.Filter != null)
            {
                var filter = container.Filter;


                using (TimestampEntities2 te = new TimestampEntities2())
                {
                    ret.Status = true;

                    var lastID = from ts in te.Timestamp orderby ts.TimestampID descending select ts.TimestampID;

                    Timestamp TimeIn = new Timestamp();

                    TimeIn.TimestampID = Convert.ToInt32(lastID.FirstOrDefault()) + 1;
                    TimeIn.EmpID = Convert.ToInt32(filter.ID);
                    TimeIn.TimestampFDay = filter.dtF;
                    TimeIn.TimestampLDay = filter.dtL;
                    TimeIn.TimestampIn = filter.TimeIn;
                    TimeIn.TimestampOut = filter.TimeOut;
                    TimeIn.TimestampDes = filter.Detial;

                    var Typee = from ty in te.TimestampType where ty.TypeName == filter.Type select ty.TypeID;

                    TimeIn.TypeID = Convert.ToInt32(Typee.FirstOrDefault());
                    TimeIn.StatusID = 0;

                    te.Timestamp.Add(TimeIn);

                    te.SaveChanges();
                    ret.Message = "ชื่อ - สกุล : " + filter.Name + "  " + filter.LName + "\n" + "รหัสพนักงาน : " + filter.ID + "\n" + "วันที่เริ่ม : " + filter.dtF.ToString("dd-MM-yy") + "  " + "วันสุดท้าย : " + filter.dtL.ToString("dd-MM-yy") + "\n"
                        + "เวลาเข้า : " + filter.TimeIn + "   " + "เวลาออก : " + filter.TimeOut + "\n" + "รายละเอียด : " + filter.Detial + "\n" + "ประเภท : " + filter.Type;
                }
            }
            else
            {
                ret.Status = false;
                ret.Message = "ERROR";

            }
            return ret;

        }

        public Container TimestampUpdateStatus(int ID,string status)
        {
            var ret = new Container();
            using (TimestampEntities2 te = new TimestampEntities2())
            {
                var Tims = te.Timestamp.Where(x => (x.TimestampID == ID)).FirstOrDefault();
                var stat = te.TimestampStatus.Where(x => (x.Status == status)).Select(x=>x.StatusID).FirstOrDefault();
                if (Tims != null)
                {
                    ret.Status = true;
                    Tims.StatusID = stat;
                    Tims.TimestampKDay = DateTime.Today;
                    te.SaveChanges();

                    ret.Message = status + " Success";
                }
                else
                {
                    ret.Status = false;
                    ret.Message = "ERROR";
                }
            }
            return ret;
        }
        public Container RejectTimestampofMine(int ID)
        {
            var ret = new Container();

            using(TimestampEntities2 te = new TimestampEntities2())
            {
                var obj = te.Timestamp.Where(o => (o.TimestampID == ID)).FirstOrDefault();

                if (obj != null)
                {
                    ret.Status = true;
                    te.Timestamp.Remove(obj);

                    te.SaveChanges();
                    //ก่อนบยกเลิกควรมี dialog ขึ้นมาถามยืนยัน
                    ret.Message = "ยกเลิกสำเร็จ";
                }
                else
                {
                    ret.Status = false;
                    ret.Message = "";
                }
                               
            }

            return ret;
        }
    }
}
