using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Microsoft.AspNetCore.Http;

namespace HanaSpa.Common.Helper
{
    public static class FormFileToByteConverter
    {
        public static byte[] Convert(IFormFile file)
        {
            using (var memoryStream = new MemoryStream())
            {
                file.CopyToAsync(memoryStream);
                return memoryStream.ToArray();
            }
        }
    }
}
