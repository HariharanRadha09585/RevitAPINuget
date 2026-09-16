namespace RevitAPINuget.Elements
{
    public class ElementHelper
    {
        public static string GetElementName(Autodesk.Revit.DB.Element element)
        {
            if (element == null)
            {
                return "Element is null";
            }
            string name = element.Name;
            if (string.IsNullOrEmpty(name))
            {
                return "Element has no name";
            }
            return name;
        }
    }
}
