using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.IO;
using Sgml;
using System.Xml.XPath;

namespace scraping
{
    public static class Class1
    {
        public static IEnumerable<T> XPathEvaluate<T>(this XElement element, string xpath)
        {
            return ((IEnumerable<object>)element.XPathEvaluate(xpath)).Cast<T>();
        }
        public static IEnumerable<T> XPathEvaluate<T>(this XElement element, string xpath, IXmlNamespaceResolver resolver)
        {
            return ((IEnumerable<object>)element.XPathEvaluate(xpath, resolver)).Cast<T>();
        }
        public static IEnumerable<T> XPathEvaluate<T>(this XDocument document, string xpath)
        {
            return ((IEnumerable<object>)document.XPathEvaluate(xpath)).Cast<T>();
        }
        public static IEnumerable<T> XPathEvaluate<T>(this XDocument document, string xpath, IXmlNamespaceResolver resolver)
        {
            return ((IEnumerable<object>)document.XPathEvaluate(xpath, resolver)).Cast<T>();
        }
    }
}
