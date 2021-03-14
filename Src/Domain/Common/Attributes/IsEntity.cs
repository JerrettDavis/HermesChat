using System;
using JetBrains.Annotations;

namespace Domain.Common.Attributes
{
    [MeansImplicitUse(ImplicitUseTargetFlags.WithMembers)]
    [AttributeUsage(AttributeTargets.All, Inherited = false)]
    public class IsEntity : Attribute
    {
        
    }
}