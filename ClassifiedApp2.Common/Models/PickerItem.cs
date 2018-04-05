using System;
namespace ClassifiedApp2.Common.Models
{
    public class PickerItem
    {
        public int? Value { get; set; }

        public string DisplayName { get; set; }

		public override string ToString()
		{
            return DisplayName;
		}
	}
}
