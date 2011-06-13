using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Xml;

namespace MPUrlEncoding.Models
{
    public class Mapping
    {
        private List<KeyValuePair<string, string>> _encodingCharacterMap;
        private string _path;


        public List<KeyValuePair<string, string>> GetCharacterMap()
        {
            return _encodingCharacterMap;
        }


        public void ReadXml(string path)
        {
            var serializer = new DataContractSerializer((typeof(List<KeyValuePair<string, string>>)));
            _encodingCharacterMap = serializer.ReadObject(XmlReader.Create(path)) as List<KeyValuePair<string, string>>;
        }

        public void WriteXml()
        {
            var dataContractSerializer = new DataContractSerializer(typeof(List<KeyValuePair<string, string>>));

            using (var writer = XmlWriter.Create((_path)))
            {
                dataContractSerializer.WriteObject(writer, GetCharacterMap());
            }
        }


        public Mapping(string path)
        {
            _path = path;

            _encodingCharacterMap = new List<KeyValuePair<string, string>>
            {

#region Mapping

new KeyValuePair<string, string>("100", "Continue"),
new KeyValuePair<string, string>("101", "Switching Protocols"),
new KeyValuePair<string, string>("200", "OK"),
new KeyValuePair<string, string>("201", "Created"),
new KeyValuePair<string, string>("202", "Accepted"),
new KeyValuePair<string, string>("203", "Non-Authoritative Information"),
new KeyValuePair<string, string>("204", "No Content"),
new KeyValuePair<string, string>("205", "Reset Content"),
new KeyValuePair<string, string>("206", "Partial Content"),
new KeyValuePair<string, string>("300", "Multiple Choices"),
new KeyValuePair<string, string>("301", "Moved Permanently"),
new KeyValuePair<string, string>("302", "Moved Temporarily"),
new KeyValuePair<string, string>("303", "See Other"),
new KeyValuePair<string, string>("304", "Not Modified"),
new KeyValuePair<string, string>("305", "Use Proxy"),
new KeyValuePair<string, string>("306", "[Unused]"),
new KeyValuePair<string, string>("307", "Temporary Redirect"),
new KeyValuePair<string, string>("400", "Bad Request"),
new KeyValuePair<string, string>("401", "Unauthorized"),
new KeyValuePair<string, string>("402", "Payment Required"),
new KeyValuePair<string, string>("403", "Forbidden"),
new KeyValuePair<string, string>("404", "Not Found"),
new KeyValuePair<string, string>("405", "Method Not Allowed"),
new KeyValuePair<string, string>("406", "Not Acceptable"),
new KeyValuePair<string, string>("407", "Proxy Authentication Required"),
new KeyValuePair<string, string>("408", "Request Timeout"),
new KeyValuePair<string, string>("409", "Conflict"),
new KeyValuePair<string, string>("410", "Gone"),
new KeyValuePair<string, string>("411", "Length Required"),
new KeyValuePair<string, string>("412", "Precondition Failed"),
new KeyValuePair<string, string>("413", "Request Entity Too Large"),
new KeyValuePair<string, string>("414", "Request-URL Too Long"),
new KeyValuePair<string, string>("415", "Unsupported Media Type"),
new KeyValuePair<string, string>("416", "Requested Range Not Satisfiable"),
new KeyValuePair<string, string>("417", "Expectation Failed"),
new KeyValuePair<string, string>("500", "Internal Server Error"),
new KeyValuePair<string, string>("501", "Not Implemented"),
new KeyValuePair<string, string>("502", "Bad Gateway"),
new KeyValuePair<string, string>("503", "Service Unavailable"),
new KeyValuePair<string, string>("504", "Gateway Timeout"),
new KeyValuePair<string, string>("505", "HTTP Version Not Supported"),


#endregion
            };
        }
    }
}
