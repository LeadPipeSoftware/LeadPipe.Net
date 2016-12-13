// --------------------------------------------------------------------------------------------------------------------
// Copyright (c) Lead Pipe Software. All rights reserved.
// Licensed under the MIT License. Please see the LICENSE file in the project root for full license information.
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace LeadPipe.Net
{
    /// <summary>
    /// The enumeration supertype.
    /// </summary>
    /// <remarks><para>
    /// A frequent problem with standard enumerations is that they often lead to gnarly switch statements. For example:
    ///   </para>
    ///   <code>
    /// public class Employee
    /// {
    /// public EmployeeType Type { get; set; }
    /// }
    /// public enum EmployeeType
    /// {
    /// FullTime,
    /// PartTime,
    /// Contract
    /// }
    /// public void ApplyBonus(Employee employee)
    /// {
    /// switch(employee.Type)
    /// {
    /// case EmployeeType.FullTime:
    /// employee.Bonus = 1000m;
    /// break;
    /// case EmployeeType.PartTime:
    /// employee.Bonus = 1.0m;
    /// case EmployeeType.Contract:
    /// employee.Bonus = 0.01m;
    /// default:
    /// throw new ArgumentOutOfRangeException();
    /// }
    /// }
    ///   </code>
    ///   <para>
    /// The trouble is that behavior related to the enumeration will often become scattered throughout the application
    /// and simple activities such as adding a new enumeration get messy. Using this class we can do this instead:
    ///   </para>
    ///   <code>
    /// public class EmployeeType : Enumeration
    /// {
    /// public static readonly EmployeeType FullTime = new EmployeeType(0, "Full Time");
    /// public static readonly EmployeeType PartTime = new EmployeeType(1, "Part Time");
    /// public static readonly EmployeeType Contract = new EmployeeType(2, "Contract");
    /// private EmployeeType ()
    /// {
    /// }
    /// private EmployeeType(int value, string displayName) : base(value, displayName)
    /// {
    /// }
    /// }
    ///   </code>
    ///   <para>
    /// The actual enumeration doesn't look any different in code. You can still do this:
    ///   </para>
    ///   <code>
    /// gregMajor.Type = EmployeeType.FullTime;
    ///   </code>
    ///   <para>
    /// Ah, but now we have a place to put behavior associated with the enumeration which means we can do this:
    ///   </para>
    ///   <code>
    /// public void ApplyBonus(Employee employee)
    /// {
    /// employee.Bonus = employee.Type.BonusSize;
    /// }
    ///   </code>
    ///   <para>
    /// See what happened there? The entire switch statement got dropped to a single line of code. How did we do that?
    /// Well, we could have simply assigned the enum's BonusSize value somewhere. We could have also done this:
    ///   </para>
    ///   <code>
    /// public abstract class EmployeeType : Enumeration
    /// {
    /// public static readonly EmployeeType FullTime = new FullTimeEmployeeType();
    /// protected EmployeeType()
    /// {
    /// }
    /// protected EmployeeType(int value, string displayName) : base(value, displayName)
    /// {
    /// }
    /// public abstract decimal BonusSize { get; }
    /// public override decimal BonusSize
    /// {
    /// get { return 1000m; }
    /// }
    /// }
    ///   </code>
    ///   <para>
    /// Pretty cool, huh? Now we can zero in on implementation without having to hunt all over our code for references
    /// to the enumeration. This is basically just the Strategy pattern applied to the enumeration class idea. Props to
    /// Jimmy Bogard (http://lostechies.com/jimmybogard) for laying this one out.
    /// </para></remarks>
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "Reviewed. Suppression is OK here.")]
    [Serializable]
    [DebuggerDisplay("{DisplayName} - {Value}")]
    public abstract class Enumeration<TEnumeration> : Enumeration<TEnumeration, int>
        where TEnumeration : Enumeration<TEnumeration>
    {
        protected Enumeration(int value, string displayName)
            : base(value, displayName)
        {
        }

        public static TEnumeration FromInt32(int value)
        {
            return FromValue(value);
        }

        public static bool TryFromInt32(int listItemValue, out TEnumeration result)
        {
            return TryParse(listItemValue, out result);
        }
    }

    [Serializable]
    [DebuggerDisplay("{DisplayName} - {Value}")]
    [DataContract(Namespace = "https://github.com/LeadPipeSoftware/LeadPipe.Net")]
    public abstract class Enumeration<TEnumeration, TValue> : IComparable<TEnumeration>, IEquatable<TEnumeration>
        where TEnumeration : Enumeration<TEnumeration, TValue>
        where TValue : IComparable
    {
        private static Lazy<TEnumeration[]> enumerations = new Lazy<TEnumeration[]>(GetEnumerations);

        [DataMember(Order = 1)]
        private readonly string displayName;

        [DataMember(Order = 0)]
        private readonly TValue value;

        protected Enumeration(TValue value, string displayName)
        {
            this.value = value;
            this.displayName = displayName;
        }

        public string DisplayName
        {
            get { return displayName; }
        }

        public TValue Value
        {
            get { return value; }
        }

        public static TEnumeration FromValue(TValue value)
        {
            return Parse(value, "value", item => item.Value.Equals(value));
        }

        public static TEnumeration[] GetAll()
        {
            return enumerations.Value;
        }

        public static bool operator !=(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
        {
            return !Equals(left, right);
        }

        public static bool operator ==(Enumeration<TEnumeration, TValue> left, Enumeration<TEnumeration, TValue> right)
        {
            return Equals(left, right);
        }

        public static TEnumeration Parse(string displayName)
        {
            return Parse(displayName, "display name", item => item.DisplayName == displayName);
        }

        public static bool TryParse(TValue value, out TEnumeration result)
        {
            return TryParse(e => e.Value.Equals(value), out result);
        }

        public static bool TryParse(string displayName, out TEnumeration result)
        {
            return TryParse(e => e.DisplayName == displayName, out result);
        }

        public int CompareTo(TEnumeration other)
        {
            return Value.CompareTo(other.Value);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as TEnumeration);
        }

        public bool Equals(TEnumeration other)
        {
            return other != null && Value.Equals(other.Value);
        }

        public override int GetHashCode()
        {
            return Value.GetHashCode();
        }

        public sealed override string ToString()
        {
            return DisplayName;
        }

        private static TEnumeration[] GetEnumerations()
        {
            var enumerationType = typeof(TEnumeration);

            return enumerationType
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.DeclaredOnly)
                .Where(info => enumerationType.IsAssignableFrom(info.FieldType))
                .Select(info => info.GetValue(null))
                .Cast<TEnumeration>()
                .ToArray();
        }

        private static TEnumeration Parse(object value, string description, Func<TEnumeration, bool> predicate)
        {
            TEnumeration result;

            if (!TryParse(predicate, out result))
            {
                string message = string.Format("'{0}' is not a valid {1} in {2}", value, description, typeof(TEnumeration));
                throw new ArgumentException(message, "value");
            }

            return result;
        }

        private static bool TryParse(Func<TEnumeration, bool> predicate, out TEnumeration result)
        {
            result = GetAll().FirstOrDefault(predicate);
            return result != null;
        }
    }
}