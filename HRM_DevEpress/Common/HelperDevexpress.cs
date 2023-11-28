namespace HRM_DevEpress.Common
{
    public class StringAsLookupItem
    {
        public string Name { get; set; }

        public object Value { get; set; }

        public StringAsLookupItem(string name, object value)
        {
            Name = name; Value = value;
        }
    }
}
