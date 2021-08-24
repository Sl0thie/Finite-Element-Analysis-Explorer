namespace CSWindowsStoreAppSaveCollection
{
    using System.IO;
    using System.Text;
    using System.Xml;
    using System.Xml.Serialization;

    /// <summary>
    /// ObjectSerializer class.
    /// </summary>
    /// <typeparam name="T">The generic type.</typeparam>
    internal static class ObjectSerializer<T>
    {
        /// <summary>
        /// Serialize to XML.
        /// </summary>
        /// <param name="value">The object to convert.</param>
        /// <returns>The serialized object.</returns>
        public static string ToXml(T value)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            StringBuilder stringBuilder = new StringBuilder();
            XmlWriterSettings settings = new XmlWriterSettings()
            {
                Indent = true,
                OmitXmlDeclaration = true,
            };

            using (XmlWriter xmlWriter = XmlWriter.Create(stringBuilder, settings))
            {
                serializer.Serialize(xmlWriter, value);
            }

            return stringBuilder.ToString();
        }

        /// <summary>
        /// De-serialize from XML.
        /// </summary>
        /// <param name="xml">The XML containing the object.</param>
        /// <returns>A generic object.</returns>
        public static T FromXml(string xml)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(T));
            T value;
            using (StringReader stringReader = new StringReader(xml))
            {
                object deserialized = serializer.Deserialize(stringReader);
                value = (T)deserialized;
            }

            return value;
        }
    }
}
