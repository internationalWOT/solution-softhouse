using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using solution_softhouse.TranslatorEngine.Interfaces;
using solution_softhouse.XmlTranslatorEngine;

namespace solution_softhouseTest
{
    [TestClass]
    public class TranslateTextFileTest
    {
        private static readonly string
            RawTextData =
                  "P|Carl Gustaf|Bernadotte" + Environment.NewLine
                + "T|0768-101801|08-101801" + Environment.NewLine
                + "A|Drottningholms slott|Stockholm|10001" + Environment.NewLine
                + "F|Victoria|1977" + Environment.NewLine
                + "A|Haga Slott|Stockholm|10002" + Environment.NewLine
                + "this line is not correct" + Environment.NewLine
                + "F|Carl Philip|1979" + Environment.NewLine
                + "T|0768-101802|08-101802" + Environment.NewLine
                + "A|Haga Slott|Stockholm|10002" + Environment.NewLine
                + "P|Barack|Obama" + Environment.NewLine
                + "A|1600 Pennsylvania Avenue|Washington, D.C" + Environment.NewLine
                + "T|0768-101802|08-101802",
            ExpectedTranslatedXmlData = 
                $@"<people>
                      <person>
                        <firstname>Carl Gustaf</firstname>
                        <lastname>Bernadotte</lastname>
                        <phone>
                          <mobile>0768-101801</mobile>
                          <landline>0768-101801</landline>
                        </phone>
                        <address>
                          <street>Drottningholms slott</street>
                          <city>Stockholm</city>
                          <zipcode>10001</zipcode>
                        </address>
                        <family>
                          <name>Victoria</name>
                          <born>1977</born>
                          <address>
                            <street>Haga Slott</street>
                            <city>Stockholm</city>
                            <zipcode>10002</zipcode>
                          </address>
                        </family>
                        <family>
                          <name>Carl Philip</name>
                          <born>1979</born>
                          <phone>
                            <mobile>0768-101802</mobile>
                            <landline>0768-101802</landline>
                          </phone>
                          <address>
                            <street>Haga Slott</street>
                            <city>Stockholm</city>
                            <zipcode>10002</zipcode>
                          </address>
                        </family>
                      </person>
                      <person>
                        <firstname>Barack</firstname>
                        <lastname>Obama</lastname>
                        <address>
                          <street>1600 Pennsylvania Avenue</street>
                          <city>Washington, D.C</city>
                          <zipcode></zipcode>
                        </address>
                        <phone>
                          <mobile>0768-101802</mobile>
                          <landline>0768-101802</landline>
                        </phone>
                      </person>
                    </people>";


        [TestMethod]
        public void XmlTranslatorEngineTest()
        {
            ITranslatorEngine translator = new XmlTranslatorEngine();
            string xml = translator.DoTranslation(RawTextData);


            /*
            * Trim the result for easier comparison. I do not validate the structure of
            * the XML since I can be sure it will at least a parsable object since I
            * am using the XDocument Library
            */
            string[] expected = ExpectedTranslatedXmlData.Split(Environment.NewLine)
                .Select(p => p.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToArray();
            
            string[] res = xml.Split(Environment.NewLine)
                .Select(p => p.Trim())
                .Where(p => !string.IsNullOrWhiteSpace(p))
                .ToArray();


            for (int i = 0; i < expected.Length; ++i)
            {
                Assert.IsTrue(expected[i] == res[i]);
            }
        }
    }
}
