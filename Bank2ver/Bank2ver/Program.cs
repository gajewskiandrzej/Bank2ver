using System;
using System.Collections;

namespace Bank2ver
{
    public abstract class Konto
    {
        public string NrKonta { get; set; }
        public double Saldo { get; set; }

        public abstract double Wplac(double kwotaWplaty);
        public abstract void Wyplac(double kwotaWyplaty);

        public override string ToString()
        {
            return String.Format("Numer konta: {0} Saldo: {1}", NrKonta, Saldo);
        }
    }

    interface IOsobista
    {
        bool KontrolaWyplaty(double kwotaWyplaty);
    }

    interface IZysk
    {
        double ObliczZysk(double stopaProcentowa);
    }

    public class KontoOsobiste : Konto, IOsobista
    {
        readonly double MaxWyplata = 1000.00;

        public KontoOsobiste(string nrKonta, double saldo)
        {
            NrKonta = nrKonta;
            Saldo = saldo;
        }

        public bool KontrolaWyplaty(double kwotaWyplaty)
        {
            if (kwotaWyplaty > MaxWyplata)
                return true;
            return false;
        }

        public override double Wplac(double kwotaWplaty)
        {
            return Saldo += kwotaWplaty;
        }

        public override void Wyplac(double kwotaWyplaty)
        {
            if (KontrolaWyplaty(kwotaWyplaty) == true || kwotaWyplaty >= Saldo)
            {
                Console.WriteLine("Brak środków lub przekroczono dzienny limit");
            }
            else
            {
                Saldo -= kwotaWyplaty;   
            }
        }
    }

    public class KontoLokata : Konto, IZysk
    {
        public KontoLokata(string nrKonta, double saldo)
        {
            NrKonta = nrKonta;
            Saldo = saldo;
        }

        public double ObliczZysk(double stopaProcentowa)
        {
            return Saldo * stopaProcentowa;
        }

        public override double Wplac(double kwotaWplaty)
        {
            return Saldo += kwotaWplaty;
        }

        public override void Wyplac(double kwotaWyplaty)
        {
            Saldo -= kwotaWyplaty;
        }
    }

    public class Bank
    {
        public ArrayList kontaBankowe = new ArrayList();

        public void SzukajKonto(string nrKonta)
        {
            foreach (Konto konto in kontaBankowe)
            {
                if (konto.NrKonta == nrKonta)
                {
                    Console.WriteLine(konto);
                }
            }
        }

        public void PokazBank()
        {
            foreach (Konto konto in kontaBankowe)
            {
                Console.WriteLine(konto);
            }
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {
            Bank mojBank = new Bank();

            KontoOsobiste kontoOsobisteA = new KontoOsobiste("1", 100);
            KontoOsobiste kontoOsobisteB = new KontoOsobiste("2", 500);
            KontoOsobiste kontoOsobisteC = new KontoOsobiste("3", 80);

            KontoLokata kontoLokataA = new KontoLokata("5", 5400);
            KontoLokata kontoLokataB = new KontoLokata("6", 6500);
            KontoLokata kontoLokataC = new KontoLokata("7", 3100);

            mojBank.kontaBankowe.Add(kontoLokataA);
            mojBank.kontaBankowe.Add(kontoLokataB);
            mojBank.kontaBankowe.Add(kontoLokataC);

            mojBank.kontaBankowe.Add(kontoOsobisteA);
            mojBank.kontaBankowe.Add(kontoOsobisteB);
            mojBank.kontaBankowe.Add(kontoOsobisteC);

            mojBank.PokazBank();
            mojBank.SzukajKonto("2");

            kontoOsobisteB.Wplac(58.25);
            Console.WriteLine(kontoOsobisteB);

            kontoOsobisteB.Wyplac(1000.00);
            kontoOsobisteB.Wyplac(100.50);

            Console.WriteLine(kontoOsobisteB);

            kontoLokataC.Wplac(2550.00);
            Console.WriteLine(kontoLokataC);
            double zyskKontaLokataC = kontoLokataC.ObliczZysk(0.5);
            Console.WriteLine(zyskKontaLokataC);

            Console.WriteLine(kontoLokataC);

            Console.ReadKey();
        }
    }
}
