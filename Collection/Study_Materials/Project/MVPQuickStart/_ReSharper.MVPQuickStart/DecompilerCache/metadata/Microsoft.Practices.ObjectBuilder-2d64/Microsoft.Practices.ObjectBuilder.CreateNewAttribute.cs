// Type: Microsoft.Practices.ObjectBuilder.CreateNewAttribute
// Assembly: Microsoft.Practices.ObjectBuilder, Version=1.0.51206.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a
// Assembly location: D:\Karthik.sakkarai\karthik.sakkarai\Study_Materials\Project\MVPQuickStart\Library\Microsoft.Practices.ObjectBuilder.dll

using System;

namespace Microsoft.Practices.ObjectBuilder
{
    [AttributeUsage(AttributeTargets.Parameter | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    public sealed class CreateNewAttribute : ParameterAttribute
    {
        public override IParameter CreateParameter(Type annotatedMemberType);
    }
}
