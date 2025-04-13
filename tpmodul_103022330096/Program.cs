// See https://aka.ms/new-console-template for more informationConsole.WriteLine("Hello, World!");
using tpmodul_103022330096;

class Program
{
    static void Main(string[] args)
    {
        double suhu;
        int demam;
        bool suhuValid = false;

        CovidConfig config = CovidConfig.LoadConfig();

        config.ubahSatuan();

        Console.Write($"Berapa suhu badan anda saat ini? Dalam Nilai {config.satuan_suhu}: ");
        suhu = Convert.ToDouble(Console.ReadLine());

        Console.Write($"Berapa hari yang lalu (perkiraan) anda terakhir memiliki gejala demam? ");
        demam = Convert.ToInt32(Console.ReadLine());

        if (config.satuan_suhu == "celsius")
        {
            suhuValid = suhu >= 36.5 && suhu <= 37.5;
        } else if (config.satuan_suhu == "fahrenheit") {
            suhuValid = suhu >= 97.7 && suhu <= 99.5;
        }

        if (suhuValid && demam < config.batas_hari_demam)
        {
            Console.WriteLine(config.pesan_diterima);
        } else
        {
            Console.WriteLine(config.pesan_ditolak);
        }
    }
}