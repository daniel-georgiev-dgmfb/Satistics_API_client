using Convesys.Kernel.Reflection;

namespace Convesys.Kernel.Security.Configuration
{
    public class ValidationRuleDescriptor : TypeDescriptor
    {
        public ValidationRuleDescriptor(string fullQualifiedName) : base(fullQualifiedName)
        {
        }
        
        public ValidationScope Scope { get; }
    }
}