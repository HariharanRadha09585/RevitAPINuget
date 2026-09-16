using System;
using System.Collections.Generic;
using System.Text;

namespace HariharanRadha.RevitAPI.Helpers.Views
{
    public static class ViewHelper
    {
        public static string GetViewName(Autodesk.Revit.DB.View view)
        {
            if (view == null)
            {
                return "View is null";
            }
            string name = view.Name;
            if (string.IsNullOrEmpty(name))
            {
                return "View has no name";
            }
            return name;
        }
    }
}
