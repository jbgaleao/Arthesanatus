using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace Arthesanatus.Util
{
    public class FilesHelper
    {
        public static byte[] UploadPhoto(HttpPostedFileBase file)
        {
                string pic = Path.GetFileName(file.FileName);
                using(MemoryStream ms = new MemoryStream())
                {
                    file.InputStream.CopyTo(ms);
                    byte[] array = ms.GetBuffer();
                    return array;
                }
        }
    }
}