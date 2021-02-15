using System;
using System.ComponentModel.DataAnnotations;
using System.Reflection;

namespace app_DotNet_Bank_bootcampDIO_LocalizaLabs
{
  public static class Extension
  {
    public static string GetDisplayValue(this TypeAccount value)
    {
      if (value.ToString() == "0")
        return null;

      var fieldInfo = value.GetType().GetField(value.ToString());

      var descriptionAttributes = fieldInfo.GetCustomAttributes(
          typeof(DisplayAttribute), false) as DisplayAttribute[];

      if (descriptionAttributes[0].ResourceType != null)
        return lookupResource(descriptionAttributes[0].ResourceType, descriptionAttributes[0].Name);

      if (descriptionAttributes == null) return string.Empty;
      return (descriptionAttributes.Length > 0) ? descriptionAttributes[0].Name : value.ToString();
    }

    private static string lookupResource(Type resourceManagerProvider, string resourceKey)
    {
      foreach (PropertyInfo staticProperty in resourceManagerProvider.GetProperties(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.Public))
      {
        if (staticProperty.PropertyType == typeof(System.Resources.ResourceManager))
        {
          System.Resources.ResourceManager resourceManager = (System.Resources.ResourceManager)staticProperty.GetValue(null, null);
          return resourceManager.GetString(resourceKey);
        }
      }

      return resourceKey; // Fallback with the key name
    }
  }
}