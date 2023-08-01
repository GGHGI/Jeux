namespace jeux_de_maths
{

    class program

    {
        static bool poserlaQuestion(int min, int max)
        {
            Random rand = new Random();
            int reponseI = 0;
            while (true)
            {
                int a = rand.Next(min, max + 1);
                int b = rand.Next(min, max + 1);

                Console.WriteLine(a + "+" + b + "=");
                string reponse = Console.ReadLine();
                try
                {
                    reponseI = int.Parse(reponse);
                    if (reponseI == a + b)
                    {
                        return true;
                    }
                    return false;
                }
                catch
                {
                    Console.WriteLine("erreur vous devez rentrer un nomre");
                }
            }
        }
        static void Main(string[] args)
        {
            const int nombre_min = 1;
            const int nombre_max = 10;
            const int nombredequestion = 5;
            int nombredepoints = 0;
            int moyenne = nombredequestion / 2;



            for (int i = 0; i < nombredequestion; i++)
            {
                Console.WriteLine("question numero " + (i + 1) + "/" + nombredequestion);
                bool bonneReponse = poserlaQuestion(nombre_min, nombre_max); /* là cest les paramettre*/
                if (bonneReponse)
                {
                    Console.WriteLine("bonne reponse");
                    nombredepoints++;
                }
                else
                {
                    Console.WriteLine("mauvaise reponse");
                }

                Console.WriteLine("vous avez" + nombredepoints + "/" + nombredequestion);

                if (nombredepoints == nombredequestion)
                {
                    Console.WriteLine("Exellent");
                }
                else if (nombredepoints == 0)
                {
                    Console.WriteLine("Révisez");
                }
                else if (nombredepoints > moyenne)
                {
                    Console.WriteLine("pas mal");
                }
                else
                {
                    Console.WriteLine("peut mieux faire");
                }

            }


        }
    }
}