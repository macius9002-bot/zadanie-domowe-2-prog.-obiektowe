
using System;

class KontoBankowe
{
    private string wlasciciel;
    private decimal saldo;

    public KontoBankowe(string wlasciciel, decimal saldoPoczatkowe)
    {
        this.wlasciciel = wlasciciel;
        saldo = saldoPoczatkowe >= 0 ? saldoPoczatkowe : 0;
    }

    public void PokazSaldo()
    {
        Console.WriteLine($"{wlasciciel}: {saldo} zł");
    }

    public void PokazInformacje()
    {
        Console.WriteLine($"Właściciel: {wlasciciel} | Aktualne saldo: {saldo} zł");
    }

    public void Wplac(decimal kwota)
    {
        if (kwota <= 0)
        {
            Console.WriteLine("Nieprawidłowa kwota");
            return;
        }

        saldo += kwota;
        Console.WriteLine($"Wpłacono: {kwota} zł");
    }

    public void Wyplac(decimal kwota)
    {
        if (kwota <= 0 || kwota > saldo)
        {
            Console.WriteLine("Nie można wypłacić tej kwoty");
            return;
        }

        saldo -= kwota;
        Console.WriteLine($"Wypłacono: {kwota} zł");
    }

    public bool CzyStacMnie(decimal kwota)
    {
        return kwota > 0 && saldo >= kwota;
    }

    // Metoda dla chętnych
    public void Przelew(KontoBankowe odbiorca, decimal kwota)
    {
        if (kwota <= 0 || kwota > saldo)
        {
            Console.WriteLine("Nie można wykonać przelewu");
            return;
        }

        saldo -= kwota;
        odbiorca.saldo += kwota;

        Console.WriteLine($"Przelano {kwota} zł");
    }
}

class Program
{
    static void Main()
    {
        // Tworzenie trzech kont
        KontoBankowe konto1 = new KontoBankowe("Jan", 1000);
        KontoBankowe konto2 = new KontoBankowe("Anna", 2000);
        KontoBankowe konto3 = new KontoBankowe("Piotr", 500);

        // Wyświetlanie informacji o kontach
        konto1.PokazInformacje();
        konto2.PokazInformacje();
        konto3.PokazInformacje();

        Console.WriteLine();

        // Wpłata na pierwsze konto
        konto1.Wplac(500);
        konto1.PokazSaldo();

        Console.WriteLine();

        // Wypłata z drugiego konta
        konto2.Wyplac(300);
        konto2.PokazSaldo();

        Console.WriteLine();

        // Próba wypłaty kwoty większej niż saldo
        konto3.Wyplac(1000);
        konto3.PokazSaldo();

        Console.WriteLine();

        // Sprawdzanie, czy stać nas na wydatek
        Console.WriteLine(konto1.CzyStacMnie(200));
        Console.WriteLine(konto3.CzyStacMnie(1000));

        Console.WriteLine();

        // Przelew z pierwszego konta na drugie
        konto1.Przelew(konto2, 200);

        // Wyświetlanie aktualnych informacji
        konto1.PokazInformacje();
        konto2.PokazInformacje();
        konto3.PokazInformacje();
    }
}
