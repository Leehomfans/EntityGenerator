using CreateEntityModel.AddDatabase.MySql.BLL;
using CreateEntityModel.AddDatabase.SqlServer.BLL;
using CreateEntityModel.CreateEntityModelBuilder;
using System;
using System.Collections.Generic;
using System.IO;

namespace CreateEntityModel
{
    //core 3.1控制台程序

    //主体逻辑
    //读取数据库表中字段信息，拼接成实体类格式的字符串，把字符串写入后缀名为cs的文件中
    class Program
    {
        static void Main(string[] args)
        {
            //数据库连接语句
            string connectionString = "数据库链接字符串";
            //文件创建保存地址
            string path = @"C:\Users\Administrator\Desktop\log\model\";

            new CreateDefaultBuilder()      //创建默认构建器
               .AddSqlServer(connectionString) //添加SqlServer数据库
                                               //.AddMySql(connectionString)  //添加MySql数据库
               .EntityBuild(options =>      //实体类构建
               {
                    //命名空间名（必填）
                    options.NamespaceName = "SCMC";
                    //引用程序集（选填）
                    options.Using = new List<string>
                   {
                        "System.Data.Linq",
                        "System.Data.Linq.Mapping",
                        "System.Linq"
                   };
                    //使用委托自定义类名规则（默认类名与表名一致，选填）
                    options.CustomClassName = fileName => fileName;
               })
               .Create(path);   //创建文件

            Console.WriteLine("完成");
            Console.ReadLine();
        }
    }
}
