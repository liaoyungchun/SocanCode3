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
            /// ������ṹ
            /// </summary>
            Simple,
            /// <summary>
            /// ����ģʽ����ṹ
            /// </summary>
            Factory
        }
        public enum CacheFrames
        {
            /// <summary>
            /// ��ʹ�û���
            /// </summary>
            None,
            /// <summary>
            /// �򵥻������
            /// </summary>
            Cache,
            /// <summary>
            /// �ۺϻ�������(����)
            /// </summary>
            AggregateDependency
        }
        public enum DALFrames
        {
            /// <summary>
            /// ��������SQL���
            /// </summary>
            SQL,
            /// <summary>
            /// �洢����
            /// </summary>
            SP
        }

        #region ��Ա����
        private string _beforenamespace;
        private string _afternamespace;
        private string _connvariable;
        private CodeFrames _codeframe = CodeFrames.Factory;
        private CacheFrames _cacheframe = CacheFrames.Cache;
        private DALFrames _dalframe;

        /// <summary>
        /// �����ռ�ǰ׺
        /// </summary>
        public string BeforeNamespace
        {
            get { return _beforenamespace; }
            set { _beforenamespace = value; }
        }

        /// <summary>
        /// �����ռ�ǰ׺�ӵ㣬���硰Petshop.��
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
        /// �����ռ��׺
        /// </summary>
        public string AfterNamespace
        {
            get { return _afternamespace; }
            set { _afternamespace = value; }
        }

        /// <summary>
        /// ��������ռ��׺�����硰.Basic��
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
        /// �����ռ��׺�ӵ㣬���硰Basic.��
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
        /// �����ռ��׺���»��ߣ����硰Basic_��
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
        /// ���ݿ����Ӳ���
        /// </summary>
        public string ConnVariable
        {
            get { return _connvariable; }
            set { _connvariable = value; }
        }

        /// <summary>
        /// ����ģʽ�ṹ
        /// </summary>
        public CodeFrames CodeFrame
        {
            get { return _codeframe; }
            set { _codeframe = value; }
        }

        /// <summary>
        /// ����ṹ
        /// </summary>
        public CacheFrames CacheFrame
        {
            get { return _cacheframe; }
            set { _cacheframe = value; }
        }

        /// <summary>
        /// DAL�����ʽ��SQL���ߴ洢���̣�
        /// </summary>
        public DALFrames DALFrame
        {
            get { return _dalframe; }
            set { _dalframe = value; }
        }
        #endregion

    }
}
