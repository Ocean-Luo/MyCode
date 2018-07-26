using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;
using Microsoft.Extensions.Options;
using DapperDemo.Models;
using Dapper;

namespace DapperDemo.Controllers
{
    public class FailGetFactorController : Controller
    {
        public readonly IOptions<Appsettings> Setting;

        public FailGetFactorController(IOptions<Appsettings> setting)
        {
            Setting = setting;
        }
        public IActionResult Index()
        {
            var s = Setting.Value.ConnectionStrings.DefaultConnection;
            using (var con = new SqlConnection(s))
            {
               
            
                //查询
                var sql = "select * from FailgetFactor where QuarterDate=@QuarterDate";
                List<FailGetFactor> templist=con.Query<FailGetFactor>(sql, new FailGetFactor { QuarterDate=DateTime.Parse("2018-3-31") }).ToList();

                //批量新增
                var sqlInsert = "insert into FailgetFactor(Code,Fields,Parameters,QuarterDate,CreateDate,IsFirst) values(@Code,@Fields,@Parameters,@QuarterDate,@CreateDate,@IsFirst)";
                List<FailGetFactor> list = new List<FailGetFactor>();
                for (int i = 0; i < 2; i++)
                {
                    FailGetFactor temp = new FailGetFactor();
                    temp.Code = "1";
                    temp.CreateDate = DateTime.Now.Date;
                    temp.QuarterDate =DateTime.Parse("2018-3-31");
                    list.Add(temp);

                }
                con.Execute(sqlInsert, list);

                //批量删除
                var sqlDelete = "delete from FailgetFactor where Code=@Code";
                con.Execute(sqlDelete, list);
            }
            return View();
        }
    }
}