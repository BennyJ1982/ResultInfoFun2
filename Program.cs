using System;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Serialization;

namespace ResultInfoFun
{
    class Program
    {
        static void Main(string[] args)
        {
            var resultInfo = new ResultInfo();
            using (TracingContext.EnterInitialScope("Main", resultInfo))
            {
                MethodA();
            }

            XmlWriterSettings settings = new XmlWriterSettings
            {
                Indent = true,
                IndentChars = "  ",
                NewLineChars = "\r\n",
                NewLineHandling = NewLineHandling.Replace
            };

            using (var writer = XmlWriter.Create(Console.OpenStandardOutput(), settings))
            {
                var serializer = new DataContractSerializer(typeof(ResultInfo));
                serializer.WriteObject(writer, resultInfo);
            }

            Console.ReadKey();
        }

        static void MethodA()
        {
            using (TracingContext.EnterScope("Method A"))
            {
                MethodB();
            }
        }

        static void MethodB()
        {
            using (TracingContext.EnterScope("Method B"))
            {
                using (TracingContext.EnterScope("Calling C methods now"))
                {
                    MethodC();
                    MethodC();
                }
            }
        }

        static void MethodC()
        {
            using (TracingContext.EnterScope("Method C"))
            {
                MethodD();
            }
        }

        static void MethodD()
        {
            using (TracingContext.EnterScope("Method D"))
            {
            }
        }
    }
}
