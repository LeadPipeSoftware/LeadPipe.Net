using System;
using LeadPipe.Net.Extensions;

namespace LeadPipe.Net.Data.NHibernate
{
    [Serializable]
    public class EnumerationType<T> : WellKnownInstanceType<Enumeration<T>> where T : Enumeration<T>
    {
        public EnumerationType() : base(Enumeration<T>.GetAll(), FindPredicate, GetId)
        {
        }

        private static bool FindPredicate(Enumeration<T> instance, int id)
        {
            if (instance.IsNull()) return false;

            return instance.Value == id;
        }

        private static int GetId(Enumeration<T> instance)
        {
            return instance.Value;
        }
    }
}