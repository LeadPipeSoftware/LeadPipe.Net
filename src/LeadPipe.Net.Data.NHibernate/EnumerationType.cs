// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using NHibernate.Dialect;
using NHibernate.SqlTypes;
using NHibernate.Type;
using System;
using System.Data;

namespace LeadPipe.Net.Data.NHibernate
{
    [Serializable]
    public class EnumerationType<T> : PrimitiveType where T : Enumeration<T>
    {
        public EnumerationType()
            : base(new SqlType(DbType.Int32))
        {
        }

        public override object DefaultValue
        {
            get { return 0; }
        }

        public override string Name
        {
            get { return "enumeration"; }
        }

        public override Type PrimitiveClass
        {
            get { return typeof(int); }
        }

        public override Type ReturnedClass
        {
            get { return typeof(T); }
        }

        public override object FromStringValue(string xml)
        {
            return int.Parse(xml);
        }

        public override object Get(IDataReader rs, int index)
        {
            var o = rs[index];
            var value = Convert.ToInt32(o);
            return Enumeration<T>.FromInt32(value);
        }

        public override object Get(IDataReader rs, string name)
        {
            var ordinal = rs.GetOrdinal(name);
            return Get(rs, ordinal);
        }

        public override string ObjectToSQLString(object value, Dialect dialect)
        {
            return value.ToString();
        }

        public override void Set(IDbCommand cmd, object value, int index)
        {
            var parameter = (IDataParameter)cmd.Parameters[index];

            var val = (Enumeration<T>)value;

            parameter.Value = val.Value;
        }
    }
}