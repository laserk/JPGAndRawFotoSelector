using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml.Serialization;
using JPGRawFotoSelector.Properties;

namespace JPGRawFotoSelector
{
    public static class Helper
    {
        public static Process StartProcessSilent(string file, string arguments)
        {
            var info = new ProcessStartInfo(file)
            {
                UseShellExecute = false,
                CreateNoWindow = true,
                Arguments = arguments
            };
            return Process.Start(info);
        }

        public static Match RegexMatch(string content, string expression)
        {
            if (content == null)
                content = String.Empty;
            var regex = new Regex(expression,
                RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.CultureInvariant);
            return regex.Match(content);
        }

        public static string Pattern2RegExpression(string pattern)
        {
            string result = Regex.Escape(pattern);
            result = result.Replace(@"\*\.\*", @"([^\.]+|.*\.[^\\\.]*)")
                .Replace(@"\.\*", @"\.[^\\\.]*")
                .Replace(@"\*", @".*")
                .Replace(@"\?", @"[^\\\.]");
            return result;
        }

        public static string GetFullPath(string relative)
        {
            string current = String.Empty;
            var assembly = Assembly.GetEntryAssembly();
            if (assembly != null)
                current = Directory.GetParent(Assembly.GetEntryAssembly().Location).FullName;
            return Path.GetFullPath(Path.Combine(current, relative));
        }

        public static T Deserialize<T>(string filePath)
        {
            return (T) Deserialize(typeof (T), filePath);
        }

        public static object Deserialize(Type type, string filePath)
        {
            using (var reader = new StreamReader(filePath, Encoding.UTF8))
            {
                var serializer = new XmlSerializer(type);
                return serializer.Deserialize(reader);
            }
        }

        public static T DeserializeContent<T>(string content)
        {
            return (T) DeserializeContent(typeof (T), content);
        }

        public static object DeserializeContent(Type type, string content)
        {
            using (var reader = new StringReader(content))
            {
                var serializer = new XmlSerializer(type);
                return serializer.Deserialize(reader);
            }
        }

        public static string SerializeContent(object target)
        {
            var builder = new StringBuilder();
            var ns = new XmlSerializerNamespaces();
            ns.Add(String.Empty, String.Empty);
            var serializer = new XmlSerializer(target.GetType());
            using (var writer = new StringWriter(builder))
            {
                serializer.Serialize(writer, target, ns);
            }
            return builder.ToString();
        }

        public static void SetPropertyValue(object target, string property, object value)
        {
            const BindingFlags bf =
                BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.NonPublic | BindingFlags.Public |
                BindingFlags.Static;
            PropertyInfo pi = target.GetType().GetProperty(property, bf);
            if (pi == null || !pi.CanWrite)
                throw new ArgumentException("Property Not Found or Can Not Write", property);
            object newValue = value;
            if (pi.PropertyType == typeof (string))
                newValue = (value == null) ? null : value.ToString();
            if (pi.PropertyType == typeof (Guid))
                newValue = (value == null || String.IsNullOrEmpty(value.ToString()))
                    ? Guid.Empty
                    : Guid.Parse(value.ToString());
            if (pi.PropertyType.IsEnum)
            {
                Trace.Assert(value != null);
                newValue = Enum.Parse(pi.PropertyType, value.ToString(), true);
            }
            if (pi.PropertyType.IsValueType)
            {
                TypeConverter converter = TypeDescriptor.GetConverter(pi.PropertyType);
                newValue = value == null ? null : converter.ConvertFromInvariantString(value.ToString());
            }
            pi.SetValue(target, newValue);
        }

        public static IEnumerable<string> GetPropertyNames(Type type, bool readable, bool writable)
        {
            var result = new List<string>();
            const BindingFlags bf =
                BindingFlags.Instance | BindingFlags.SetProperty | BindingFlags.GetProperty | BindingFlags.NonPublic |
                BindingFlags.Public;
            var properties = type.GetProperties(bf);
            foreach (PropertyInfo pi in properties)
            {
                if (readable && !pi.CanRead)
                    continue;
                if (readable && !pi.GetMethod.IsPublic)
                    continue;
                if (writable && !pi.CanWrite)
                    continue;
                if (writable && !pi.SetMethod.IsPublic)
                    continue;
                if (result.Contains(pi.Name))
                    continue;
                result.Add(pi.Name);
            }
            return result;
        }

        public static object GetPropertyValue(object target, string property)
        {
            const BindingFlags bf =
                BindingFlags.Instance | BindingFlags.GetProperty | BindingFlags.NonPublic | BindingFlags.Public |
                BindingFlags.Static;
            PropertyInfo pi = target.GetType().GetProperty(property, bf);
            if (pi == null || !pi.CanRead)
                throw new ArgumentException("Property Not Found or Can Not Read", property);
            return pi.GetValue(target, null);
        }

        public static void OpenJpgFile(string filePathName)
        {
            if (!filePathName.EndsWith(".jpg", StringComparison.OrdinalIgnoreCase) &&
                !filePathName.EndsWith(".jpge", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show(Resources.File_type_does_not_support);
                return;
            }
            if (!File.Exists(filePathName))
            {
                MessageBox.Show(Resources.Please_refresh_the_list);
                return;
            }
            System.Diagnostics.Process process = new System.Diagnostics.Process();

     
            process.StartInfo.FileName = filePathName;


            process.StartInfo.Arguments = "rundl132.exe C://WINDOWS//system32//shimgvw.dll,ImageView_Fullscreen";


            process.StartInfo.UseShellExecute = true;

            process.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            process.Start();
            process.Close();

        }
    }
}

