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
using System.Configuration;
using System.Web.Caching;

namespace rkanr.CacheDependencyFactory
{
    public class DependencyFacade
    {
        private static readonly string path = ConfigurationManager.AppSettings["CacheDependencyAssembly"];

        public static AggregateCacheDependency GetBasicIntTableCacheDependency()
        {
            if (!string.IsNullOrEmpty(path))
                return DependencyAccess.CreateBasicIntTableDependency().GetDependency();
            else
                return null;
        }
    }
}


