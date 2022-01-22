using System;
using System.Reflection;
using System.Xml.Linq;
using solution_softhouse.Enums;
using solution_softhouse.Interfaces.RowEntities;
using solution_softhouse.RowEntities;
using solution_softhouse.TranslatorEngine.Interfaces;

namespace solution_softhouse.TranslatorEngine
{
    /*
    * Ruleset and structure in this XML Translator implementation:
    *  P|firstname|lastname        -> person
    *  T|mobile|landline           -> phone
    *  A|street|city|zipcode       -> address
    *  F|name|born                 -> family
    *  P can be followed by T, A and F
    *  F can be followed by T and A
    *  The root element is always people
    *  P is a list of people.
    *  F is a listitem of family members .
    */
    public class XmlTranslatorEngine : ITranslatorEngine
    {
        private readonly XDocument _xDocument;
        private readonly char _delimiter = '|';
        private XElement _parentElement;
        private XElement _objElement;
        private XElement _newElement;

        public XmlTranslatorEngine()
        {
            XElement root = new XElement("people");
            _xDocument = new XDocument(root);
            _parentElement = _xDocument.Root;
            _objElement = _xDocument.Root;
            _newElement = _xDocument.Root;
        }

        public XmlTranslatorEngine(char delimiter)
        {
            // alternative crt for splitting at custom delimiter
            XElement root = new XElement("people");
            _xDocument = new XDocument(root);
            _parentElement = _xDocument.Root;
            _objElement = _xDocument.Root;
            _newElement = _xDocument.Root;
            _delimiter = delimiter;
        }

        public string DoTranslation(string input)
        {
            string[] rows = input.Split(Environment.NewLine);
            BaseRow row = new BaseRow();

            for (int i = 0; i < rows.Length; i++)
            {
                char prefix = rows[i][0];
                char delimiter = rows[i][1];

                if (delimiter != _delimiter) continue;
   
                if (prefix == 'P')
                {
                    row = new PersonRow(XmlElementType.xmlList, rows[i]);
                    _newElement = new XElement("person");
                    MapAndSetValues(row);
                    _objElement = _newElement;
                    _parentElement = _newElement;
                    _xDocument.Root?.Add(_newElement);
                }

                else if (prefix == 'T')
                {
                    row = new TelephoneRow(XmlElementType.xmlElement, rows[i]);
                    _newElement = new XElement("phone");
                    MapAndSetValues(row);
                    _parentElement?.Add(_newElement);
                }

                else if (prefix  == 'A')
                {
                    row = new AdressRow(XmlElementType.xmlElement, rows[i]);
                    _newElement = new XElement("address");
                    MapAndSetValues(row);
                    _parentElement?.Add(_newElement);
                }

                else if (prefix == 'F')
                {
                    row = new FamilyRow(XmlElementType.xmlList, rows[i]);
                    _newElement = new XElement("family");
                    _parentElement = _newElement;
                    MapAndSetValues(row);
                    _objElement?.Add(_newElement);
                }
            }
            return _xDocument.ToString();
        }

        private void MapAndSetValues(IBaseRow baseRow)
        {
            // using reflection of our row objects to build the XML structure.
            Type type = baseRow.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = type.GetProperties(flags);

            foreach (PropertyInfo property in properties)
            {
                if (property.GetValue(baseRow, null).GetType() == typeof(XmlElementType))
                {
                    continue;
                }
                _newElement.Add(new XElement(property.Name, property.GetValue(baseRow, null)));
            }
        }
    }
}
