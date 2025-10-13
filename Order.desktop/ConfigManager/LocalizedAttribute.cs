using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Resources;
using System.Text;
using System.Threading.Tasks;

namespace RuFramework.LocalizedAttribute
{
    /// <summary>
    /// Used to translate the attributes of a PropertyGrid+
    /// Category    Attribute
    /// DisplayName Attribute
    /// Description Attribute
    /// </summary>
    public class LocalizedCategoryAttribute : CategoryAttribute
    {
        readonly ResourceManager _resourceManager;
        readonly string _resourceKey;

        public LocalizedCategoryAttribute(string resourceKey, System.Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        protected override string GetLocalizedString(string value)
        {
            string category = _resourceManager.GetString(_resourceKey);
            return string.IsNullOrWhiteSpace(category) ? string.Format("[[{0}]]", _resourceKey) : category;
        }
    }
    public class LocalizedDisplayNameAttribute : DisplayNameAttribute
    {
        readonly ResourceManager _resourceManager;
        readonly string _resourceKey;

        public LocalizedDisplayNameAttribute(string resourceKey, System.Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string DisplayName
        {
            get
            {
                string displayName = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(displayName) ? string.Format("[[{0}]]", _resourceKey) : displayName;
            }
        }
    }
    public class LocalizedAttribute : DescriptionAttribute
    {
        readonly ResourceManager _resourceManager;
        readonly string _resourceKey;

        public LocalizedAttribute(string resourceKey, System.Type resourceType)
        {
            _resourceManager = new ResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string description = _resourceManager.GetString(_resourceKey);
                return string.IsNullOrWhiteSpace(description) ? string.Format("[[{0}]]", _resourceKey) : description;
            }
        }
    }
}
