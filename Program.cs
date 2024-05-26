using System;

class SayaTubeVideo
{
    // A. Naming convention
    // Private attributes
    private int _id;
    private string _title;
    private int _playCount;

    // Constants
    private const int MaxTitleLength = 100;
    private const int MaxPlayCountIncrement = 10000000;

    // Constructor
    public SayaTubeVideo(string title)
    {
        // Validasi judul video
        if (string.IsNullOrEmpty(title) || title.Length > MaxTitleLength)
        {
            throw new ArgumentException("Judul video harus memiliki panjang maksimal 100 karakter dan tidak boleh NULL");
        }

        _id = GenerateRandomId();
        _title = title;
        _playCount = 0;
    }

    // B. Method / Function / Procedure
    // Method untuk menghasilkan ID acak
    private int GenerateRandomId()
    {
        Random rnd = new Random();
        return rnd.Next(10000, 99999);
    }

    // Method untuk menambah jumlah play count
    public void IncreasePlayCount(int count)
    {
        // Validasi input count
        if (count < 0 || count > MaxPlayCountIncrement)
        {
            throw new ArgumentOutOfRangeException("Input penambahan play count harus antara 0 dan 10.000.000");
        }

        try
        {
            checked
            {
                _playCount += count;
            }
        }
        catch (OverflowException ex)
        {
            Console.WriteLine("Terjadi overflow saat menambahkan play count: " + ex.Message);
        }
    }

    // Method untuk mencetak detail video
    public void PrintVideoDetails()
    {
        Console.WriteLine("Video Details:");
        Console.WriteLine("ID: " + _id);
        Console.WriteLine("Title: " + _title);
        Console.WriteLine("Play Count: " + _playCount);
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Nama praktikan
        string namaPraktikan = "Jeremy Mathew Fabian Sitepu";

        // Coba membuat video dengan judul null untuk menangani error
        try
        {
            SayaTubeVideo invalidVideo = new SayaTubeVideo(null);
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine("Terjadi kesalahan saat membuat video: " + ex.Message);
        }

        // Membuat instance video dengan judul valid
        SayaTubeVideo video = new SayaTubeVideo("Tutorial Design By Contract – " + namaPraktikan);

        // Menambah play count 10 kali dengan nilai 1.000.000
        for (int i = 0; i < 10; i++)
        {
            try
            {
                video.IncreasePlayCount(1000000);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("Terjadi kesalahan saat menambahkan play count: " + ex.Message);
            }
        }

        // Mencetak detail video
        video.PrintVideoDetails();
    }
}
