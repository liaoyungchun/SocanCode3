using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class Table
    {
        private string _name;

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        private List<Model.Field> _fields = new List<Field>();

        public List<Model.Field> Fields
        {
            get { return _fields; }
            set { _fields = value; }
        }
    }
}
