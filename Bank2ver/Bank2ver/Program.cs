using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bank2ver
{
    public abstract class Konto
    {
        string NrKonta;
        double Saldo;

        public abstract double Wplac(double kwotaWplaty);
        public abstract double Wyplac(double kwotaWyplaty);
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
        string NrKonta;
        double Saldo;
        readonly double MaxWyplata = 1000.00;

        public KontoOsobiste(string nrKonta, double saldo)
        {
            nrKonta = NrKonta;
            saldo = Saldo;
        }

        public bool KontrolaWyplaty(double kwotaWyplaty)
        {
            if (kwotaWyplaty > MaxWyplata)
                return false;
            return true;
        }

        public override double Wplac(double kwotaWplaty)
        {
            return Saldo += kwotaWplaty;
        }

        public override double Wyplac(double kwotaWyplaty)
        {
            if (KontrolaWyplaty(kwotaWyplaty))
                return Saldo -= kwotaWyplaty;
            return -1;
        }
    }

    public class KontoLokata : Konto, IZysk
    {
        string NrKonta;
        double Saldo;

        public KontoLokata(string nrKonta, double saldo)
        {
            NrKonta = nrKonta;
            Saldo = saldo;
        }

        public double ObliczZysk(double stopaProcentowa)
        {
            return Saldo += Saldo * stopaProcentowa;
        }

        public override double Wplac(double kwotaWplaty)
        {
            return Saldo += kwotaWplaty;
        }

        public override double Wyplac(double kwotaWyplaty)
        {
            return Saldo -= kwotaWyplaty;
        }
    }

    public class Bank
    {
        KontoLokata KontoLokata;
        KontoOsobiste KontoOsobiste;

        public Bank(KontoLokata kontoLokata, KontoOsobiste kontoOsobiste)
        {
            kontoLokata = KontoLokata;
            kontoOsobiste = KontoOsobiste;
        }

        public ArrayList kontaBankowe = new ArrayList();

        public void SzukajKonto(string nrKonta)
        {
            foreach (Konto konta in kontaBankowe)
            {
                if (konta.)
                {

                }
            }
        }
            
    }

    class Program
    {
        static void Main(string[] args)
        {

        }
    }
}
