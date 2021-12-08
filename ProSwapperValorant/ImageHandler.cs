using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ProSwapperValorant
{
    public class ImageHandler
    {
        public static Image ItemIcon(string url)
        {
            if (url.StartsWith("https://media.valorant-api.com/"))
            {
                //Fetch with fortnite api
                string path = Program.ProSwapperFolder + @"Images\" + url.Remove(0, "https://".Length).Replace("/","");
                //Downloads image if doesnt exists
                if (!File.Exists(path))
                    return SaveImage(url, path, ImageFormat.Png);
                else
                {
                    return Image.FromStream(File.Open(path, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite));
                    //return Image.FromFile(path);
                }
            }
            {
                throw new Exception("That's not a trusted image url!");
            }
        }

        private static Image SaveImage(string imageUrl, string filename, ImageFormat format)
        {
            using (WebClient web = new WebClient())
            {
                Stream stream = web.OpenRead(imageUrl);
                Bitmap bitmap = new Bitmap(stream);

                if (bitmap != null)
                    bitmap.Save(filename, format);

                stream.Flush();
                stream.Close();
                return bitmap;
            }
        }
    }
}
