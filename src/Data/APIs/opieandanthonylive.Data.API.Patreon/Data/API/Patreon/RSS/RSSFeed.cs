using System;
using System.Collections.Generic;
using System.ServiceModel.Syndication;
using System.Text;
using System.Xml;

namespace opieandanthonylive.Data.API.Patreon.RSS
{
//	/// <summary>
//	///		Feed object which maps to 'channel' property on Feed.Serialize()
//	/// </summary>
//	public class RSSFeed
//	{
//		public string Description { get; set; }

//		public Uri Link { get; set; }

//		public string Title { get; set; }

//		public string Copyright { get; set; }

//		public ICollection<Item> Items { get; set; } = new List<Item>();


//		/// <summary>Produces well-formatted rss-compatible xml string.</summary>
//		public string Serialize()
//		{
//			var defaultOption = new SerializeOption()
//			{
//				Encoding = Encoding.Unicode
//			};
//			return Serialize(defaultOption);
//		}

//		/// <summary>Produces well-formatted rss-compatible xml string.</summary>
//		public string Serialize(SerializeOption option)
//		{
//			var feed = new SyndicationFeed(
//				"Feed Title",
//				"Feed Description",
//				new Uri("http://Feed/Alternate/Link"),
//				"FeedID",
//				DateTime.Now);

//			// Add a custom attribute.
//			var xqName = new XmlQualifiedName("CustomAttribute");
//			feed.AttributeExtensions.Add(xqName, "Value");

//			var sp = new SyndicationPerson("jesper@contoso.com", "Jesper Aaberg", "http://Jesper/Aaberg");
//			feed.Authors.Add(sp);

//			SyndicationCategory category = new SyndicationCategory("FeedCategory", "CategoryScheme", "CategoryLabel");
//			feed.Categories.Add(category);

//			feed.Contributors.Add(new SyndicationPerson("lene@contoso.com", "Lene Aaling", "http://lene/aaling"));
//			feed.Copyright = new TextSyndicationContent("Copyright 2007");
//			feed.Description = new TextSyndicationContent("This is a sample feed");

//			// Add a custom element.
//			XmlDocument doc = new XmlDocument();
//			XmlElement feedElement = doc.CreateElement("CustomElement");
//			feedElement.InnerText = "Some text";
//			feed.ElementExtensions.Add(feedElement);

//			feed.Generator = "Sample Code";
//			feed.Id = "FeedID";
//			feed.ImageUrl = new Uri("http://server/image.jpg");

//			TextSyndicationContent textContent = new TextSyndicationContent("Some text content");
//			SyndicationItem item = new SyndicationItem("Item Title", textContent, new Uri("http://server/items"), "ItemID", DateTime.Now);

//			List<SyndicationItem> items = new List<SyndicationItem>();
//			items.Add(item);
//			feed.Items = items;

//			feed.Language = "en-us";
//			feed.LastUpdatedTime = DateTime.Now;

//			SyndicationLink link = new SyndicationLink(new Uri("http://server/link"), "alternate", "Link Title", "text/html", 1000);
//			feed.Links.Add(link);

//			XmlWriter atomWriter = XmlWriter.Create("atom.xml");
//			Atom10FeedFormatter atomFormatter = new Atom10FeedFormatter(feed);
//			atomFormatter.WriteTo(atomWriter);
//			atomWriter.Close();

//			XmlWriter rssWriter = XmlWriter.Create("rss.xml");
//			Rss20FeedFormatter rssFormatter = new Rss20FeedFormatter(feed);
//			rssFormatter.WriteTo(rssWriter);
//			rssWriter.Close();

//			//var doc = new XDocument(new XElement("rss"));
//			//doc.Root.Add(new XAttribute("version", "2.0"));

//			//var channel = new XElement("channel");
//			//channel.Add(new XElement("title", Title));
//			//if (Link != null)
//			//	channel.Add(new XElement("link", Link.AbsoluteUri));
//			//channel.Add(new XElement("description", Description));
//			//channel.Add(new XElement("copyright", Copyright));
//			//doc.Root.Add(channel);

//			//foreach (var item in Items)
//			//{
//			//	var itemElement = new XElement("item");
//			//	itemElement.Add(new XElement("title", item.Title));
//			//	if (item.Link != null)
//			//		itemElement.Add(new XElement("link", item.Link.AbsoluteUri));
//			//	itemElement.Add(new XElement("description", item.Body));
//			//	if (item.Author != null)
//			//		itemElement.Add(new XElement("author", $"{item.Author.Email} ({item.Author.Name})"));
//			//	foreach (var c in item.Categories)
//			//		itemElement.Add(new XElement("category", c));
//			//	if (item.Comments != null)
//			//		itemElement.Add(new XElement("comments", item.Comments.AbsoluteUri));
//			//	if (!string.IsNullOrWhiteSpace(item.Permalink))
//			//		itemElement.Add(new XElement("guid", item.Permalink));
//			//	var dateFmt = item.PublishDate.ToString("r");
//			//	if (item.PublishDate != DateTime.MinValue)
//			//		itemElement.Add(new XElement("pubDate", dateFmt));
//			//	if (item.Enclosures != null && item.Enclosures.Any())
//			//	{
//			//		foreach (var enclosure in item.Enclosures)
//			//		{
//			//			var enclosureElement = new XElement("enclosure");
//			//			foreach (var key in enclosure.Values.AllKeys)
//			//			{
//			//				enclosureElement.Add(new XAttribute(key, enclosure.Values[key]));
//			//			}
//			//			itemElement.Add(enclosureElement);
//			//		}

//			//	}
//			//	channel.Add(itemElement);
//			//}

//			//return doc.ToStringWithDeclaration(option);
//		}
//	}
}
