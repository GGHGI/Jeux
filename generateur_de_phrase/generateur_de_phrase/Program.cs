namespace generateur_de_phrase
{
    class program
    {

        static string ObtenirUnElementAléatoire(string[] t)
        {
            Random r = new Random();
            int i = r.Next(t.Length);
            return t[i];
        }


        static void Main(string[] args)
        {

            var sujets = new string[]
            {
                "Un lapin",
                "un chien" ,
                "un chat" ,
                "une grand-mère",
                "un enfant",
                "une fée",
                "un magicien",
            };

            var verbes = new string[]
         {
                "mange",
                "vomit" ,
                "lit" ,
                "attrape",
                "observe",
                "se bat avec",
                "s'accorche à",
         };

            var complements = new string[]
     {
                "le soleil",
                "un livre" ,
                "un crapaud" ,
                "une girafe",
                "la lune",
                "une carte",
                "une piscine",
     };

            const int NB_Phrases = 100;
            var phrasesUniques = new List<string>();
            int doublonEvites = 0;


            while (phrasesUniques.Count < NB_Phrases)
            {
                var sujet = ObtenirUnElementAléatoire(sujets);
                var verbe = ObtenirUnElementAléatoire(verbes);
                var complement = ObtenirUnElementAléatoire(complements);
                var phrase = sujet + " " + verbe + " " + complement;

                phrase = phrase.Replace("a le", "au");

                if (!phrasesUniques.Contains(phrase))
                {
                    phrasesUniques.Add(phrase);
                }
                else
                {
                    doublonEvites++;
                }
            }


            foreach (var phrase in phrasesUniques)
            {
                Console.WriteLine(phrase);
            }

            Console.WriteLine();
            Console.WriteLine("Nombre de phrases uniques : " + phrasesUniques.Count);
            Console.WriteLine("Nombre de doublons évités : " + doublonEvites);




        }
    }


}