/*
    Copyright 2013 Fred Bowker
    This file is part of WsdlUI.
    WsdlUI is free software: you can redistribute it and/or modify it under the terms of the GNU General Public License as published by the Free Software Foundation, either version 3 of the License, or (at your option) any later version.
    WsdlUI is distributed in the hope that it will be useful, but WITHOUT ANY WARRANTY; without even the implied warranty of MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE. See the GNU General Public License for more details.
    You should have received a copy of the GNU General Public License along with Foobar. If not, see http://www.gnu.org/licenses/.
*/

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace WsdlUI.App.UI
{
    internal class DictionaryPropertyGridAdapter : ICustomTypeDescriptor
    {
         IDictionary<string, StringProperty> _dictionary;
        public IDictionary<string, StringProperty> PropGridValues
        {
            get
            {
                return _dictionary;
            }
        }

        public DictionaryPropertyGridAdapter(IDictionary<string, StringProperty> d)
        {
            _dictionary = d;
        }

        public string GetComponentName()
        {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public EventDescriptor GetDefaultEvent()
        {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public string GetClassName()
        {
            return TypeDescriptor.GetClassName(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes)
        {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents()
        {
            return TypeDescriptor.GetEvents(this, true);
        }

        public TypeConverter GetConverter()
        {
            return TypeDescriptor.GetConverter(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd)
        {
            return _dictionary;
        }

        public AttributeCollection GetAttributes()
        {
            AttributeCollection m = TypeDescriptor.GetAttributes(this, true);
            return m;
        }

        public object GetEditor(Type editorBaseType)
        {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public PropertyDescriptor GetDefaultProperty()
        {
            return null;
        }

        PropertyDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetProperties()
        {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes)
        {
            List<DictionaryPropertyDescriptor> properties = new List<DictionaryPropertyDescriptor>();

            foreach (var keyValue in _dictionary)
            {
                properties.Add(new DictionaryPropertyDescriptor(_dictionary, keyValue.Key));
            }

            PropertyDescriptor[] props = properties.ToArray();

            return new PropertyDescriptorCollection(props);
        }

    }

    internal class StringProperty
    {
        string _categoryName;
        
        public string InternalValue
        {
            get;
            set;
        }

         List<Attribute> _attributes;
        public AttributeCollection Attributes
        {
            get
            {
                if (_categoryName != null)
                {
                    _attributes.Add(new CategoryAttribute(_categoryName));
                }

                return new AttributeCollection(_attributes.ToArray());
            }
        }

         bool _isReadOnly = false;
        public bool IsReadOnly
        {
            get
            {
                return _isReadOnly;
            }
        }

        public StringProperty(string internalValue, string categoryName, List<Attribute> attributes)
        {
            InternalValue = internalValue;
            _categoryName = categoryName;
            _attributes = attributes;
        }

        public StringProperty(string internalValue, string categoryName, List<Attribute> attributes,bool isReadOnly)
        {
            InternalValue = internalValue;
            _categoryName = categoryName;
            _attributes = attributes;
            _isReadOnly = isReadOnly;
        }

    }

    internal class DictionaryPropertyDescriptor : PropertyDescriptor
    {
        IDictionary<string, StringProperty> _dictionary;
        string _key;

        internal DictionaryPropertyDescriptor(IDictionary<string, StringProperty> d, object key)
            : base(key.ToString(), null)
        {
            _dictionary = d;
            _key = (string)key;
        }

        public override AttributeCollection Attributes
        {
            get
            {
                return _dictionary[_key].Attributes;
            }
        }

        public override Type PropertyType
        {
            get
            {
                return typeof(string);
            }
        }

        public override void SetValue(object component, object value)
        {
            StringProperty propValue = (StringProperty)_dictionary[_key];
            propValue.InternalValue = (string)value;


            //_dictionary[_key] = (StringProperty)value;
        }

        public override object GetValue(object component)
        {
            return _dictionary[_key].InternalValue;
        }

        public override bool IsReadOnly
        {
            get
            {
                return _dictionary[_key].IsReadOnly;
            }
        }

        public override Type ComponentType
        {
            get
            {
                return null;
            }
        }

        public override bool CanResetValue(object component)
        {
            return false;
        }

        public override void ResetValue(object component)
        {
        }

        public override bool ShouldSerializeValue(object component)
        {
            return false;
        }
    }

}
