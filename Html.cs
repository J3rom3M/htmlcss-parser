using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ConvertToZendesk
{
    public class Html
    {

        public bool CreateHtml()
        {
            // Cet exemple de code montre comment créer un document HTML.

            // Créer un document HTML vide
            var document = new HTMLDocument();

            // Ajouter un titre
            // 1. Créer un élément de titre
            var h2 = (HTMLHeadingElement)document.CreateElement("h2");

            // 2. Créer un élément de texte
            var text = document.CreateTextNode("This is Sample Heading!");

            // 3. ajouter un élément de texte au titre
            h2.AppendChild(text);

            // 4. Ajouter un titre to the document
            document.Body.AppendChild(h2);

            // Ajouter un paragraphe
            // 1. Créer un élément de paragraphe
            var p = (HTMLParagraphElement)document.CreateElement("p");

            // 2. Définir un attribut personnalisé
            p.SetAttribute("id", "first-paragraph");

            // 3. Créer un nœud de texte
            var paraText = document.CreateTextNode("This is first paragraph. ");

            // 4. Ajoutez le texte au paragraphe
            p.AppendChild(paraText);

            // 5. Joindre un paragraphe au corps du document 
            document.Body.AppendChild(p);

            // Ajouter une liste ordonnée
            // Créer un élément de paragraphe
            var list = (HTMLOListElement)document.CreateElement("ol");

            // Ajouter l'élément 1
            var item1 = (HTMLLIElement)document.CreateElement("li");
            item1.AppendChild(document.CreateTextNode("First list item."));

            // Ajouter l'élément 2
            var item2 = (HTMLLIElement)document.CreateElement("li");
            item2.AppendChild(document.CreateTextNode("Second list item."));

            // Ajouter des éléments li à la liste
            list.AppendChild(item1);
            list.AppendChild(item2);

            // Joindre la liste au corps du document 
            document.Body.AppendChild(list);

            // Enregistrer le document HTML dans un fichier 
            document.Save(@"C:\scripts\ConvertToZendesk\OUT\create-new-document.html");            
        }

        public bool ReadHtml() 
        {
            if (webBrowser1.Document != null)
            {
                string documentPath = @"C:\scripts\ConvertToZendesk\IN\index.htm";
                // Charger un fichier HTML
                var document = new HTMLDocument(documentPath);
                Console.WriteLine(document.DocumentElement.OuterHTML);
            }
            return true;
        }

        public bool EditHtml() 
        {
            if (webBrowser1.Document != null)
            {
                // HtmlDocument doc = webBrowser1.Document;
                // Cet exemple de code montre comment modifier le contenu sortant d'un fichier HTML.
                // Préparer un chemin de sortie pour l'enregistrement d'un document
                string documentPath = @"C:\scripts\ConvertToZendesk\OUT\create-new-document.html";

                // Créer une instance d'un document HTML
                var document = new HTMLDocument(documentPath);

                // Créer un nœud de texte
                var oldParaText = document.CreateTextNode("This is old first paragraph.");

                // Obtenir l'élément du premier paragraphe
                var p = (HTMLParagraphElement)document.GetElementsByTagName("p").First();
                p.AppendChild(oldParaText);

                // Enregistrer le document HTML dans un fichier 
                document.Save(@"C:\scripts\ConvertToZendesk\OUT\modify.html");                
            }
            return true;
        }
    }
}