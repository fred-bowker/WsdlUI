using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace WsdlUI.App.UI.UserControls.Widgets {
    public class ResponsePropertyGrid : ICustomTypeDescriptor {

        Dictionary<string, StringPropertyValue> _dictionary = new Dictionary<string, StringPropertyValue>();

        const string STATUS_CATEGORY_NAME = "Response Status";
        const string HEADER_CATEGORY_NAME = "Response Headers";

        public ResponsePropertyGrid(string responseStatus, Dictionary<string, string> responseHeaders) {

            _dictionary["Status"] = new StringPropertyValue(STATUS_CATEGORY_NAME, responseStatus);

            foreach (var v in responseHeaders) {
                _dictionary[v.Key] = new StringPropertyValue(HEADER_CATEGORY_NAME, v.Value);
            }
        }

        public string GetComponentName() {
            return TypeDescriptor.GetComponentName(this, true);
        }

        public EventDescriptor GetDefaultEvent() {
            return TypeDescriptor.GetDefaultEvent(this, true);
        }

        public string GetClassName() {
            return TypeDescriptor.GetClassName(this, true);
        }

        public EventDescriptorCollection GetEvents(Attribute[] attributes) {
            return TypeDescriptor.GetEvents(this, attributes, true);
        }

        EventDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetEvents() {
            return TypeDescriptor.GetEvents(this, true);
        }

        public TypeConverter GetConverter() {
            return TypeDescriptor.GetConverter(this, true);
        }

        public object GetPropertyOwner(PropertyDescriptor pd) {
            return _dictionary;
        }

        public AttributeCollection GetAttributes() {
            return TypeDescriptor.GetAttributes(this, true);
        }

        public object GetEditor(Type editorBaseType) {
            return TypeDescriptor.GetEditor(this, editorBaseType, true);
        }

        public PropertyDescriptor GetDefaultProperty() {
            return null;
        }

        PropertyDescriptorCollection System.ComponentModel.ICustomTypeDescriptor.GetProperties() {
            return ((ICustomTypeDescriptor)this).GetProperties(new Attribute[0]);
        }

        public PropertyDescriptorCollection GetProperties(Attribute[] attributes) {

            List<DictionaryPropertyDescriptor> properties = new List<DictionaryPropertyDescriptor>();
            foreach (var v in _dictionary) {
                properties.Add(new DictionaryPropertyDescriptor(_dictionary, v.Key));
            }

            PropertyDescriptor[] props = (PropertyDescriptor[])properties.ToArray();

            return new PropertyDescriptorCollection(props);
        }

    }

    class DictionaryPropertyDescriptor : PropertyDescriptor {

        Dictionary<string, StringPropertyValue> _dictionary;
        string _key;

        internal DictionaryPropertyDescriptor(Dictionary<string, StringPropertyValue> d, string key)
            : base(key, null) {
            _dictionary = d;
            _key = key;
        }

        public override Type PropertyType {
            get {
                return typeof(string);
            }
        }

        public override object GetValue(object component) {
            return _dictionary[_key].InternalValue;
        }

        public override bool IsReadOnly {
            get {
                return true;
            }
        }

        public override string Category {
            get {
                return _dictionary[_key].CategoryName;
            }
        }

        public override Type ComponentType {
            get {
                return null;
            }
        }

        public override void SetValue(object component, object value) {
        }

        public override bool CanResetValue(object component) {
            return false;
        }

        public override void ResetValue(object component) {
        }

        public override bool ShouldSerializeValue(object component) {
            return false;
        }
    }

    class StringPropertyValue {

        public string CategoryName {
            get;
            private set;
        }

        public string InternalValue {
            get;
            private set;
        }

        public StringPropertyValue(string categoryName, string internalValue) {
            InternalValue = internalValue;
            CategoryName = categoryName;
        }

    }
}
