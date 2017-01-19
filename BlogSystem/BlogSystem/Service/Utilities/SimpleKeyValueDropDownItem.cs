using System.Collections.Generic;

namespace Service.Utilities
{
    public class SimpleKeyValueDropDownItem<TKey, TValue>
    {
        public TKey Key { get; set; }
        public TValue Value { get; set; }
        public bool IsSelected { get; set; }
    }

    public class TwoLevelDropDownItem
    {
        public string Caption { get; set; }
        public List<SimpleKeyValueDropDownItem<int?, string>> SecondLevelItems { get; set; }
    }
}
