using SinemaBiletSatışOtomasyonu.Enums;
using SinemaBiletSatışOtomasyonu.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SinemaBiletSatışOtomasyonu.Helpers
{
    public class Helper
    {
        public static List<Movie> CreateMovies()
        {
            string basePath = "C:/Users/Ali Onur/source/repos/SinemaBiletSatışOtomasyonu/SinemaBiletSatışOtomasyonu/Pictures/";
            return new List<Movie>()
            {
                new Movie()
                {
                     movieName="Yıldızlararası",
                     category=Category.bilim_kurgu,
                     minute="2 saat 49 dakika",
                     price=50,
                     picturePath=basePath+"interstellar.jpg"
                },
                new Movie()
                {
                     movieName="Nefesini Tut",
                     category=Category.gerilim,
                     minute="1 saat 28 dakika",
                     price=40,
                     picturePath=basePath+"dontbreath.jpg"
                },
                new Movie()
                {
                     movieName="Ace Adventura",
                     category=Category.komedi,
                     minute="1 saat 15 dakika",
                     price=30,
                     picturePath=basePath+"aceadventura.jpg"
                },
                new Movie()
                {
                     movieName="Jurassic Park",
                     category=Category.fantastik,
                     minute="2 saat 10 dakika",
                     price=50,
                     picturePath=basePath+"jurassicpark.jpg"
                },
                new Movie()
                {
                     movieName="Yüzüklerin Efendisi",
                     category=Category.fantastik,
                     minute="3 saat 25 dakika",
                     price=60,
                     picturePath=basePath+"LOTR.jpg"
                },
                new Movie()
                {
                     movieName="Uncharted",
                     category=Category.macera,
                     minute="2 saat 20 dakika",
                     price=50,
                     picturePath=basePath+"uncharted.jpg"
                },
            };
        }
    }
}
