using Dessin;
namespace jeux_du_pendu;




class Program
{


    static void AfficherMot(string mot, List<char> lettres)
    {

        for (int i = 0; i < mot.Length; i++)
        {

            char lettre = mot[i];
            if (lettres.Contains(lettre))
            {
                Console.Write(lettre + " ");
            }
            else
            {
                Console.Write("_ ");
            }

        }

        Console.WriteLine();
    }

    static bool ToutesLettresDevinees(string mot, List<char> lettres)
    {

        foreach (var lettre in lettres)
        {

            mot = mot.Replace(lettre.ToString(), "");
        }

        if (mot.Length == 0)
        {
            return true;
        }

        return false;

    }


    static char DemanderUneLettre()
    {
        while (true)

        {
            Console.Write("Rentrer une lettre : ");
            string reponse = Console.ReadLine();
            if (reponse.Length == 1)
            {
                reponse = reponse.ToUpper();
                return reponse[0];
            }

            Console.WriteLine("erreur, vous devez rentrer une lettre");
        }

    }

    static void DevinerMot(string mot)
    {

        var lettresDevinees = new List<char>();
        const int NB_Vies = 6;
        int vieRestantes = NB_Vies;


        while (vieRestantes > 0)
        {
            Console.WriteLine(Ascii.PENDU[NB_Vies - vieRestantes]);
            Console.WriteLine();

            AfficherMot(mot, lettresDevinees);
            Console.WriteLine();
            var lettre = DemanderUneLettre();
            Console.Clear();

            if (mot.Contains(lettre))
            {
                Console.WriteLine("cette lettre est dans le mot");
                lettresDevinees.Add(lettre);

                if (ToutesLettresDevinees(mot, lettresDevinees))
                {
                    break;
                }
            }
            else
            {
                Console.WriteLine("Le mot ne contient pas les lettres");
                vieRestantes--;
                Console.WriteLine("Vie restants : " + vieRestantes);
            }

            Console.WriteLine();


        }

        Console.WriteLine(Ascii.PENDU[NB_Vies - vieRestantes]);

        if (vieRestantes == 0)
        {
            Console.WriteLine("PERDU, le mot était : " + mot);
        }
        else
        {
            AfficherMot(mot, lettresDevinees);
            Console.WriteLine();
            Console.WriteLine("GAGNE ! ");
        }

    }


    static string[] Chargerlesmots(string Nomfichier)
    {
        try
        {
            return File.ReadAllLines(Nomfichier);

        }

        catch (Exception except)
        {
            Console.WriteLine("Erreur lecture du fichier" + Nomfichier + except.Message);
        }

        return null;
    }


    static bool DemanderdeRejouer()
    {

        Console.Write("Voulez vous rejouer (o/n)");
        char reponse = DemanderUneLettre();
        if ((reponse == 'o') || (reponse == 'O'))
        {
            return true;
        }
        else if ((reponse == 'n') || (reponse == 'N'))
        {
            return false;
        }
        else

        {
            Console.WriteLine("Erruer : vous devez repodnre o ou n");
            return DemanderdeRejouer();
        }

    }





    static void Main(string[] args)
    {
        var mots = Chargerlesmots("mots.txt");

        if ((mots == null) || (mots.Length == 0))
        {

            Console.WriteLine("la liste de mot est vide");
        }
        else
        {
            while (true)
            {
                Random r = new Random();
                int i = r.Next(mots.Length);
                string mot = mots[1].Trim().ToUpper();
                DevinerMot(mot);

                if (!DemanderdeRejouer())
                {
                    break;
                }
                Console.Clear();
            }
        }

    }
    //char lettre = DemanderUneLettre();
    // AfficherMot(mot, new List<char> { lettre });
}





