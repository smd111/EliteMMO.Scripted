namespace EliteMMO.Scripted.Embedded
{
    using System.Collections.Generic;
    using API;
    public class InventoryItems
    {
        //private static EliteAPI api;
        public static Dictionary<string, string> Items = new Dictionary<string, string>();
        //public static void PopulateItems()
        //{
        //    Items.Clear();

        //    for (var x = 0; x < 32767; x++)
        //    {
        //        var i = api.Resources.GetItem((uint)x);

        //        if (string.IsNullOrEmpty(i?.Name[0])) continue;
        //        Items.Add(i.ItemID.ToString(), i.Name[0]);
        //    }
        //}
    }
}
