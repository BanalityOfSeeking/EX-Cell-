using SimpleInjector.Advanced;
using System;
using System.Reflection;
using System.Composition;
using System.Linq;

namespace Game
{
    class ImportPropertySelectionBehavior : IPropertySelectionBehavior
    {
        public bool SelectProperty(Type implementationType, PropertyInfo prop) =>
            prop.GetCustomAttributes(typeof(ImportAttribute)).Any();
    }
}