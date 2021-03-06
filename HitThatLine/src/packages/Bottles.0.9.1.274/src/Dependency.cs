using System.Xml.Serialization;
using FubuCore;

namespace Bottles
{
    [XmlType("dependency")]
    public class Dependency
    {
        public static Dependency Optional(string name)
        {
            return new Dependency(){Name = name};
        }

        public static Dependency Mandatory(string name)
        {
            return new Dependency(){
                                       IsMandatory = true,
                                       Name = name
                                   };
        }
        

        [XmlAttribute("name")]
        public string Name { get; set; }
        
        [XmlAttribute("mandatory")]
        public bool IsMandatory { get; set; }

        public bool Equals(Dependency other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;
            return Equals(other.Name, Name) && other.IsMandatory.Equals(IsMandatory);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != typeof (Dependency)) return false;
            return Equals((Dependency) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return ((Name != null ? Name.GetHashCode() : 0)*397) ^ IsMandatory.GetHashCode();
            }
        }

        public override string ToString()
        {
            var description = IsMandatory ? "{0} (Mandatory)" : "{0} (Optional)";
            return description.ToFormat(Name);
        }
    }
}