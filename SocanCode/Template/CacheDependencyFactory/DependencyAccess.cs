//------------------------------------------------------------------------------
// 创建标识: Copyright (C) 2007 Socansoft.com 版权所有
// 创建描述: SocanCode代码生成器自动创建于 2007-8-29 22:10:04
//
// 功能描述: 
//
// 修改标识: 
// 修改描述: 
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.Caching;
using System.Configuration;
using System.Reflection;
using ICacheDependency;

namespace CacheDependencyFactory
{
    public class DependencyAccess
    {
        public static ISocansoftCacheDependency CreateBasicIntTableDependency()
        {
            return LoadInstance("BasicIntTable");
        }

        private static ISocansoftCacheDependency LoadInstance(string className)
        {
            string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];
            string fullQualifiedClass = path + "." + className;
            return (ISocansoftCacheDependency)Assembly.Load(path).CreateInstance(fullQualifiedClass);
        }
    }
}
