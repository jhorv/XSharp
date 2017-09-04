﻿namespace XSharp.x86.Params
{
    public class MemoryAddress : Identifier
    {
        public override bool IsMatch(object aValue)
        {
            return aValue is Address address && address.AddressOf is string;
        }

        public override object Transform(object aValue)
        {
            return $"[{((Address)aValue).AddressOf}]";
        }
    }

    public class RegisterAddress : Param
    {
        public override bool IsMatch(object aValue)
        {
            return aValue is Address address && address.AddressOf is Register;
        }

        public override object Transform(object aValue)
        {
            return $"[{((Address)aValue).AddressOf}]";
        }
    }

    /// <summary>
    /// Address is the object that contains an address
    /// of parameter which points to the actual object
    /// that should go inbetween brackets
    /// </summary>
    public class Address
    {
        public object AddressOf { get; set; }

        public Address(Register addressOf)
        {
            AddressOf = addressOf;
        }

        public Address(string label)
        {
            AddressOf = label;
        }
    }
}