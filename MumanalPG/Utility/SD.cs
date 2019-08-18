using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MumanalPG.Utility
{
    public class SD
    {
        public const string DefaultProductImage = "default_image.png";
        public const string ImageFolder = @"images\ProductImage";

        public const string AdminEndUser = "Admin";
        public const string SuperAdminEndUser = "Super Admin";
        public const string DefaultUser = "Default";
        public const string VentanillaUnicaUser = "Ventanilla Unica";
        public const string SecretariaUser = "Secretaria";
        
        public static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

    }
}
