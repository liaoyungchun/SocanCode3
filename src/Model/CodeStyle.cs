using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CodeStyle
    {
        public enum CodeFrames
        {
            /// <summary>
            /// 简单三层结构
            /// </summary>
            Simple,
            /// <summary>
            /// 工厂模式三层结构
            /// </summary>
            Factory
        }
        public enum CacheFrames
        {
            /// <summary>
            /// 不使用缓存
            /// </summary>
            None,
            /// <summary>
            /// 简单缓存对象
            /// </summary>
            Cache,
            /// <summary>
            /// 聚合缓存依赖(三层)
            /// </summary>
            AggregateDependency
        }
        public enum DALFrames
        {
            /// <summary>
            /// 带参数的SQL语句
            /// </summary>
            SQL,
            /// <summary>
            /// 存储过程
            /// </summary>
            SP
        }

        #region 成员变量
        private string _beforenamespace;
        private string _afternamespace;
        private string _connvariable;
        private CodeFrames _codeframe = CodeFrames.Factory;
        private CacheFrames _cacheframe = CacheFrames.Cache;
        private DALFrames _dalframe;

        /// <summary>
        /// 命名空间前缀
        /// </summary>
        public string BeforeNamespace
        {
            get { return _beforenamespace; }
            set { _beforenamespace = value; }
        }

        /// <summary>
        /// 命名空间前缀加点，例如“Petshop.”
        /// </summary>
        public string BeforeNamespaceDot
        {
            get
            {
                if (_beforenamespace != string.Empty)
                    return _beforenamespace + ".";
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 命名空间后缀
        /// </summary>
        public string AfterNamespace
        {
            get { return _afternamespace; }
            set { _afternamespace = value; }
        }

        /// <summary>
        /// 点加命名空间后缀，例如“.Basic”
        /// </summary>
        public string DotAfterNamespace
        {
            get
            {
                if (_afternamespace != string.Empty)
                    return "." + _afternamespace;
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 命名空间后缀加点，例如“Basic.”
        /// </summary>
        public string AfterNamespaceDot
        {
            get
            {
                if (_afternamespace != string.Empty)
                    return _afternamespace + ".";
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 命名空间后缀加下划线，例如“Basic_”
        /// </summary>
        public string AfterNamespaceLine
        {
            get
            {
                if (_afternamespace != string.Empty)
                    return _afternamespace + "_";
                else
                    return string.Empty;
            }
        }

        /// <summary>
        /// 数据库连接参数
        /// </summary>
        public string ConnVariable
        {
            get { return _connvariable; }
            set { _connvariable = value; }
        }

        /// <summary>
        /// 三层模式结构
        /// </summary>
        public CodeFrames CodeFrame
        {
            get { return _codeframe; }
            set { _codeframe = value; }
        }

        /// <summary>
        /// 缓存结构
        /// </summary>
        public CacheFrames CacheFrame
        {
            get { return _cacheframe; }
            set { _cacheframe = value; }
        }

        /// <summary>
        /// DAL层的样式（SQL或者存储过程）
        /// </summary>
        public DALFrames DALFrame
        {
            get { return _dalframe; }
            set { _dalframe = value; }
        }
        #endregion

    }
}
