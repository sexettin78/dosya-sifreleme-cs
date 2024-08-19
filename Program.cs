
Console.ForegroundColor = ConsoleColor.DarkMagenta;
Console.WriteLine("Programa giriş için şifre giriniz:");
string girilensifre = Console.ReadLine();
if (girilensifre == "leafyet")
{
    Console.Clear();
    Console.WriteLine("Özel Şifre Programına Hoşgeldiniz");
    while (true)
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.WriteLine("Seçenekler:");
        Console.WriteLine("[1]-Şifre Kaydet");
        Console.WriteLine("[2]-Şifre Listele");
        Console.WriteLine("[3]-Şifre Sil");
        Console.WriteLine("[4]-Rastgele Şifre Oluştur");
        Console.Write("Seçiminiz > ");
        int girdi = Convert.ToInt32(Console.ReadLine());
        string sifredosya = "sifredosya.txt";

        if (girdi == 1)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("Şifrenizi giriniz:");
            string sifre = Console.ReadLine();

            for (int i = 0; i < sifre.Length; i++)
            {
                char karakter = sifre[i];
                if (char.IsLetter(karakter))
                {
                    if (char.IsLower(karakter))
                    {
                        karakter = (char)(((karakter - 'a' + 4) % 26) + 'a');
                    }
                    else if (char.IsUpper(karakter))
                    {
                        karakter = (char)(((karakter - 'A' + 4) % 26) + 'A');
                    }
                }
                File.AppendAllText(sifredosya, karakter.ToString());
            }

            File.AppendAllText(sifredosya, "\n");
            Console.WriteLine("Şifre başarıyla kayıt edildi");
        }
        if (girdi == 2)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("İşte şifreleriniz:");
            string sifre = File.ReadAllText(sifredosya);

            for (int i = 0; i < sifre.Length; i++)
            {
                char karakter = sifre[i];
                if (char.IsLetter(karakter))
                {
                    if (char.IsLower(karakter))
                    {
                        karakter = (char)(((karakter - 'a' - 4 + 26) % 26) + 'a');
                    }
                    else if (char.IsUpper(karakter))
                    {
                        karakter = (char)(((karakter - 'A' - 4 + 26) % 26) + 'A');
                    }
                }
                Console.Write(karakter.ToString());
            }
            Console.WriteLine();
        }

        if (girdi == 3)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Silinecek Satır Numarası: ");
            int satirno = Convert.ToInt32(Console.ReadLine()) - 1;
            string[] satirlar = File.ReadAllLines(sifredosya);
            if (satirno >= 0 && satirno < satirlar.Length)
            {
                string[] yeniSatirlar = new string[satirlar.Length - 1];
                int yeniIndex = 0;
                for (int i = 0; i < satirlar.Length; i++)
                {
                    if (i != satirno)
                    {
                        yeniSatirlar[yeniIndex] = satirlar[i];
                        yeniIndex++;
                    }
                }
                File.WriteAllLines(sifredosya, yeniSatirlar);
                Console.WriteLine("Satır başarıyla silindi.");
            }
            else
            {
                Console.WriteLine("Belirtilen satır numarası hatalı.");
            }
        }
        if (girdi == 4)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("Hane sayısını giriniz: ");
            int hanesayisi = Convert.ToInt32(Console.ReadLine());

            string karakterler = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";

            Random random = new Random();
            string sifre = "";
            for (int i = 0; i < hanesayisi; i++)
            {
                int index = random.Next(karakterler.Length);
                sifre += karakterler[index];
            }
            Console.WriteLine($"Oluşturulan rastgele şifre: \n{sifre}");
        }
    }
}
else
{
    Console.WriteLine("Şifre yanlış. Giriş Başarısız.");
}