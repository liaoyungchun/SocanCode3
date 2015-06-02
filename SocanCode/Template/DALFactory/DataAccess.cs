//------------------------------------------------------------------------------
// 创建标识: Copyright (C) 2007 Socansoft.com 版权所有
// 创建描述: SocanCode代码生成器自动创建于 2007-8-29 22:22:50
//
// 功能描述: 
//
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Configuration;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using IDAL.Basic;

namespace DALFactory
{
    public class DataAccess
    {
        private static readonly string path = ConfigurationManager.AppSettings["WebDAL"];

        public static IIntTable CreateBasicIntTable()
        {
            string className = path + ".Basic.IntTable";
            return (IIntTable)Assembly.Load(path).CreateInstance(className);
        }

        public static IGuidTable CreateBasicGuidTable()
        {
            string className = path + ".Basic.GuidTable";
            return (IGuidTable)Assembly.Load(path).CreateInstance(className);
        }
    }
}
