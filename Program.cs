namespace VCS_mintaZH
{
    internal class Program
      
    {
        struct Kutya
        {
            public string fajta;
            public string szín;
            public double súly;
            public int kor;
            
        }
        static void adatbazisGeneralas(Kutya[] kutyaTomb)
        {
            string[] fajtak = new string[] {"Berni pásztorkutya", "Dobermann", "Husky", "Komondor",
            "Németjuhász", "Samoyed" };
            string[] szinek = new string[] {"Fekete", "Barna", "Homokszínű", "Fehér",
            "Szürke"};
            Random random = new Random();
            for (int i = 0; i < kutyaTomb.Length; i++) 
            {
                kutyaTomb[i].fajta = fajtak[random.Next(fajtak.Length)];
                kutyaTomb[i].szín = szinek[random.Next(szinek.Length)];
                kutyaTomb[i].súly = random.Next(26, 45);
                kutyaTomb[i].kor = random.Next(1, 4);
            }

            
        }
        static void szures(Kutya[] kutyaTomb, string fajtaInput, string szinInput)
            
        {
            bool voltTalalat = false;
            for (int i = 0; i < kutyaTomb.Length; i++)
            {
                if (kutyaTomb[i].fajta == fajtaInput && kutyaTomb[i].szín == szinInput)
                //amugy tudom h lehetne ugyanaz a nevuk, csak idegesit
                {
                    kiiras(kutyaTomb[i]);
                    voltTalalat = true;
                }
               
            }
            if (!voltTalalat)

            {
                Console.WriteLine("nics ):");
            }
        }
        static void statisztika(Kutya[] kutyaTomb)
        {
            string[] fajtak = new string[] {"Berni pásztorkutya", "Dobermann", "Husky", "Komondor",
"Németjuhász", "Samoyed" };
            foreach (string fajta in fajtak)
            {
                int darabSzam = 0;
                double súlyOsszeg = 0; 
                
                foreach (Kutya kutya in kutyaTomb)
                {
                    if (kutya.fajta == fajta)
                    {
                        darabSzam++;
                        súlyOsszeg = súlyOsszeg + kutya.súly;
                    }
                }
                Console.WriteLine(fajta + " darabszáma: " + darabSzam + "\tátlagos súlyuk: " + súlyOsszeg / darabSzam);
            }
        }

        static void sorbarendez(Kutya[] kutyaTomb)
        {
            for (int j = 0; j < kutyaTomb.Length - 1; j++)
            {
                bool voltCsere = false;
                for (int i = 0; i < kutyaTomb.Length - 1; i++)
                {
                    if (kutyaTomb[i].súly > kutyaTomb[i + 1].súly)
                    {
                        Kutya segedvaltozo = kutyaTomb[i];
                        kutyaTomb[i] = kutyaTomb[i + 1];
                        kutyaTomb[i + 1] = segedvaltozo;
                        voltCsere = true;
                    }
                }
                if (!voltCsere)
                {
                    break;
                }
            }
            /*for (int j = 0; j < kutyaTomb.Length; j++)
            {
                kiiras(kutyaTomb[j]);
            } 
            */
            foreach (Kutya kutya in kutyaTomb)
            {
                kiiras(kutya);  
            }
        }
        static void kiiras(Kutya egyKutya)
        {
            Console.WriteLine("Fajta: " + egyKutya.fajta + "\tSúly: "  + egyKutya.súly + "\tKor: " + egyKutya.kor + "\tSzín: " + egyKutya.szín);
        }
        static void Main(string[] args)
        {

            Kutya[] kutyaTomb = new Kutya[50];
            adatbazisGeneralas(kutyaTomb);

            Console.WriteLine("Statisztikak: \n");
            statisztika(kutyaTomb);

            Console.WriteLine("sorbarakva : ");
            sorbarendez(kutyaTomb);



            Console.WriteLine("Adjal meg egy szint (Fekete, Barna, Homokszínű, Fehér, Szürke): ");
            string szinInput = Console.ReadLine();
            Console.WriteLine("Adjal meg egy fajtat (Berni pásztorkutya, Dobermann, Husky, Komondor,Németjuhász, Samoyed): ");
            string fajtaInput = Console.ReadLine();
            szures(kutyaTomb, fajtaInput, szinInput);





        }

    }
}
