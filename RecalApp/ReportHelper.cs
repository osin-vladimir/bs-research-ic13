using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;

namespace RecallApp
{
    public class ReportHelper
    {
        //fonts
        Font HeaderFont;
        Font SubtitleFont;
        Font ArticleFont;

        public ReportHelper()
        {
            //create different fonts from basefont(with russian language support)
            string newfont = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Fonts), "Arial.ttf");

            BaseFont Arial = BaseFont.CreateFont(newfont, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);
            HeaderFont = new iTextSharp.text.Font(Arial, 14, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            SubtitleFont = new iTextSharp.text.Font(Arial, 12, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
            ArticleFont = new iTextSharp.text.Font(Arial, 12, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);
        }

        public void CreateReport(string filepath, int scene_number, EyeX.Person person)
        {
            var doc = new Document();

            // Set the page size
            doc.SetPageSize(PageSize.A4.Rotate());
            string fullpath= Path.Combine(filepath, "report.pdf");
            PdfWriter.GetInstance(doc, new FileStream(fullpath, FileMode.Create));

            doc.Open();

            // add personal info
            List<Phrase> phrases = new List<Phrase>();
            phrases.Add(new Phrase(Properties.Settings.Default.id + "\n", HeaderFont));
            phrases.Add(new Phrase("Персональная информация \n", HeaderFont));
            phrases.Add(new Phrase("Возраст: " + person.age + "\n", ArticleFont));
            phrases.Add(new Phrase("Пол: " + person.sex.ToString() + "\n", ArticleFont));
            phrases.Add(new Phrase("Дата: " + DateTime.Now.ToString() + "\n", ArticleFont));
            phrases.Add(new Phrase("\n", ArticleFont));

            foreach (var phrase in phrases)
                doc.Add(phrase);
            phrases.Clear();

            for (int i = 0; i < scene_number; i++)
            {
                Image img = Image.GetInstance(filepath + "\\img\\" + i + ".jpeg");
                
                img.ScalePercent(50);
                img.Alignment = Element.ALIGN_CENTER;
                doc.Add(img);
            }

            doc.Close();
            Process.Start(filepath);
        }
    }
}
