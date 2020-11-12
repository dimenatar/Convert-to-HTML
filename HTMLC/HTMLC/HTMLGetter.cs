using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


namespace HTMLC
{
    static class HTMLGetter
    {
        static private string text;
        static public string Text
        {
            get { return text; }
            set { text = value; }
        }
        static public string TransformSU(string Text)
        {

            Regex regex = new Regex("^su | su$|\\ssu\\s|^su\\b| su\\b");
            bool First = true;

            while (regex.IsMatch(Text))
                    if (First)
                    {
                        Text = regex.Replace(Text, "<sub>", 1);
                        First = false;

                    }
                    else
                    {
                            First = true;
                            Text = regex.Replace(Text, "</sub>", 1);
                    }

            return Text;
        }

        static public string[] TransformFont(string Text)
        {
            string[] splitText = Text.Split('\n');
            string Temp = "";
            Regex regex = new Regex("^Fc\\w{1}");
            for (int i =0; i < splitText.Length; i ++)
            {
                if (regex.IsMatch(splitText[i]))
                {
                    
                    Temp = splitText[i];
                    if (Temp[2] == 'A')
                    {
                        splitText[i] = regex.Replace(splitText[i], "<font color= Aqua>");
                        splitText[i] += "</font>\n";
                    }
                    else if (Temp[2] == 'P')
                    {
                        splitText[i] = regex.Replace(splitText[i], "<font color= Purple>");
                        splitText[i] += "</font>\n";
                    }
                    else if (Temp[2] == 'G')
                    {
                        splitText[i] = regex.Replace(splitText[i], "<font color= Gold>");
                        splitText[i] += "</font>\n";
                    }
                    else if (Temp[2] == 'O')
                    {
                        splitText[i] = regex.Replace(splitText[i], "<font color= Orange>");
                        splitText[i] += "</font>\n";
                    }
                    else
                    {
                        splitText[i] = regex.Replace(splitText[i], "<font color= Pink>");
                        splitText[i] += "</font>\n";
                    }
                }
            }
            return splitText;
        }
        public static void GreateHtmlDoc(string TextInBody)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("<html >");
            sb.Append("<head >");
            string meta = @"<meta charset=""UTF-8"">";
            sb.Append(meta);
            sb.Append("<title >");
            sb.Append("</title >");
            sb.Append("</head >");
            sb.Append("<body >");
            sb.Append(TextInBody);
            sb.Append("</body >");
            sb.Append("</html >");
            using (StreamWriter sw = new StreamWriter("MyHtml.html"))
            {
                sw.Write(sb.ToString());
                sw.Close();
                Console.WriteLine("Файл создан успешно!");
            }
        }

    }
}
