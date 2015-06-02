using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class CreateStyle
    {
        private string _createpath;
        /// <summary>
        /// 创建到哪里
        /// </summary>
        public string CreatePath
        {
            get { return _createpath; }
            set { _createpath = value; }
        }

        private bool _hascreatemodel;

        public bool HasCreateModel
        {
            get { return _hascreatemodel; }
            set { _hascreatemodel = value; }
        }

        private bool _hascreateidal;

        public bool HasCreateIDAL
        {
            get { return _hascreateidal; }
            set { _hascreateidal = value; }
        }

        private bool _hascreatedal;

        public bool HasCreateDAL
        {
            get { return _hascreatedal; }
            set { _hascreatedal = value; }
        }
        private bool _hascreatedbutility;

        public bool HasCreateDBUtility
        {
            get { return _hascreatedbutility; }
            set { _hascreatedbutility = value; }
        }

        private bool _hascreatedalfactory;

        public bool HasCreateDALFactory
        {
            get { return _hascreatedalfactory; }
            set { _hascreatedalfactory = value; }
        }

        private bool _hascreatebll;

        public bool HasCreateBLL
        {
            get { return _hascreatebll; }
            set { _hascreatebll = value; }
        }

        private bool _hascreateusercontrol;

        public bool HasCreateUserControl
        {
            get { return _hascreateusercontrol; }
            set { _hascreateusercontrol = value; }
        }

        private bool _hascreateicachedependency;

        public bool HasCreateICacheDependency
        {
            get { return _hascreateicachedependency; }
            set { _hascreateicachedependency = value; }
        }

        private bool _hascreatetablecachedependency;

        public bool HasCreateTableCacheDependency
        {
            get { return _hascreatetablecachedependency; }
            set { _hascreatetablecachedependency = value; }
        }

        private bool _hascreatecachedependencyfactory;

        public bool HasCreateCacheDependencyFactory
        {
            get { return _hascreatecachedependencyfactory; }
            set { _hascreatecachedependencyfactory = value; }
        }

    }
}
