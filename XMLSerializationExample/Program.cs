// Sample Serialization
using System.Text;
using System.Xml.Serialization;
using System.Xml;

var serializer0 = new XmlSerializer(typeof(Root));
using (var reader = new StringReader(File.ReadAllText("Sample.xml"))) {
  var obj = (Root)serializer0.Deserialize(reader);
}


var root = new Root {
  Level1 = new Level1 {
    Attr1 = "value1",
    Attr2 = "value2",
    Level2 = new Level2 {
      Attr3 = "value3",
      Level3 = new Level3 {
        Attr4 = "value4",
        Attr5 = "value5",
        Content = "Content"
      }
    }
  }
};

var serializer = new XmlSerializer(typeof(Root));
var sb = new StringBuilder();

using (var writer = XmlWriter.Create(sb)) {
  serializer.Serialize(writer, root);
}

var xml = sb.ToString();
Console.WriteLine(xml);

// Sample Class
[XmlRoot("root")]
public class Root {
  [XmlElement("level1")]
  public Level1 Level1 { get; set; }
}

public class Level1 {
  [XmlAttribute("attr1")]
  public string Attr1 { get; set; }

  [XmlAttribute("attr2")]
  public string Attr2 { get; set; }

  [XmlElement("level2")]
  public Level2 Level2 { get; set; }
}

public class Level2 {
  [XmlAttribute("attr3")]
  public string Attr3 { get; set; }

  [XmlElement("level3")]
  public Level3 Level3 { get; set; }
}

public class Level3 {
  [XmlAttribute("attr4")]
  public string Attr4 { get; set; }

  [XmlAttribute("attr5")]
  public string Attr5 { get; set; }

  [XmlText]
  public string Content { get; set; }
}