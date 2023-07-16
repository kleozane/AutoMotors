namespace AutoMotors
{
    public class Makina
    {
        public string Marka;
        public string Modeli;
        public int Viti;
        public string Konsumi;
        public double Motorri;
        public double Kapaciteti;
        public double KapacitetiTotal;
        public double Harxhimi;

        //Ky eshte nje koment tjeter

        public Makina(string marka, string modeli, int viti, string konsumi, double motorri, double kapaciteti, double kapacitetiTotal, double harxhimi)
        {
            Marka = marka;
            Modeli = modeli;
            Viti = viti;
            Konsumi = konsumi;
            Motorri = motorri;
            Kapaciteti = kapaciteti;
            KapacitetiTotal = kapacitetiTotal;
            Harxhimi = harxhimi;
        }

        public void ShfaqOpsionet()
        {
            Console.WriteLine("1. Bej Xhiro        2. Laj Makinen          3. Parko          4. Furnizo           0. Dil");
        }

        public void Specifikimi(Makina makina)
        {
            Console.WriteLine($"Ju zgjodhet {makina.Marka} {makina.Modeli}. Parametrat e makines jane keto:");
            Console.WriteLine($"Viti i Prodhimit: {makina.Viti}");
            Console.WriteLine($"Lloji i Karburantit: {makina.Konsumi}");
            Console.WriteLine($"Motorri: {makina.Motorri}");
        }

        public void Xhiro(Makina makina)
        {
            Console.WriteLine("Ti bere nje xhiro!");

            Random rnd = new Random();
            int km = rnd.Next(1, 200);

            double l = km * makina.Harxhimi;

            if (makina.Kapaciteti > l)
            {
                makina.Kapaciteti -= l;
                double cmimi = Cmimi(makina.Konsumi) * l;

                Console.WriteLine($"Ke bere {km} kilometra dhe jane kosumuar {Math.Round(l, 2)} litra nafte!");
                Console.WriteLine($"Per kete udhetim jane shpenzuar {Math.Round(cmimi, 2)} LEK");
                Console.WriteLine($"Kane mbetur {Math.Round(makina.Kapaciteti, 2)} litra");
            }
            else
            {
                Console.WriteLine("Mbushe!");
            }
        }

        public void Laje()
        {
            Console.WriteLine("Ti sapo lave makinen!");
        }

        public void Parko()
        {
            Console.WriteLine("Ti parkove makinen!");
        }

        public void Furnizo(Makina makina)
        {
            Console.WriteLine("Sa LEK do ta furnizoni mjetin tuaj?");
            double lek = Convert.ToInt32(Console.ReadLine());


            double l = lek / Cmimi(makina.Konsumi);

            if (makina.Kapaciteti < makina.KapacitetiTotal)
            {
                makina  .Kapaciteti += l;

                if (makina.Kapaciteti > makina.KapacitetiTotal)
                {
                    double teprica = makina.Kapaciteti - makina.KapacitetiTotal;
                    double kusuri = teprica * Cmimi(makina.Konsumi);

                    makina.Kapaciteti = makina.KapacitetiTotal;

                    double km = makina.Kapaciteti / makina.Harxhimi;

                    double furnizimi = (lek - kusuri) / Cmimi(makina.Konsumi);

                    Console.WriteLine($"U shtuan {Math.Round(furnizimi, 2)} litra nafte!");
                    Console.WriteLine($"Kusuri: {Math.Round(kusuri, 2)} LEK!");
                    Console.WriteLine($"{Math.Round(makina.Kapaciteti, 2)} litra te mbetura!");
                    Console.WriteLine($"{Math.Round(km)} kilometra te mbetura!");
                }
                else
                {
                    double km = makina.Kapaciteti / makina.Harxhimi;

                    Console.WriteLine($"U shtuan {Math.Round(l, 2)} litra nafte!");
                    Console.WriteLine($"{Math.Round(makina.Kapaciteti, 2)} litra te mbetura!");
                    Console.WriteLine($"{Math.Round(km)} kilometra te mbetura!");
                }
            }
            else
            {
                Console.WriteLine("Makina eshte e furnizuar!");
            }
        }

        private int Cmimi(string lloji)
        {
            int cmimi = lloji == "Nafte" ? 176 : 179;
            return cmimi;
        }
    }
}
