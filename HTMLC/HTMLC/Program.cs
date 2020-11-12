using System;
using System.Text;
using System.Text.RegularExpressions;

namespace HTMLC
{
    class Program
    {
        static void Main(string[] args)
        {
            string FullHTML = "";
            string text = Console.ReadLine();
            
           text = HTMLGetter.TransformSU(text);
            Console.WriteLine(text);
            ///string secondtext = Console.ReadLine();
            //string[] splittext = HTMLGetter.TransformFont(secondtext);
            string[] splittext = HTMLGetter.TransformFont("FcA Я хочу пиццы\nFcO актоАКТОакто\nFcGКурага_Угувуга\nFcPС плюс минус ?");
            for (int i =0; i < splittext.Length; i++)
            {
                FullHTML += splittext[i];
                Console.WriteLine(splittext[i]);
            }
            FullHTML += text;
            HTMLGetter.GreateHtmlDoc(FullHTML);
        }
    }
}
