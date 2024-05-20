using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AyatGroupTest.Authorization.Accounts.Dto
{
    public class UploadedImageInfo
    {
        /// <summary>
        /// ImageType
        /// </summary>
        public ImageType Type { get; set; }
        /// <summary>
        /// RelativePath
        /// </summary>
        public string RelativePath { get; set; }
        /// <summary>
        /// PathToSave
        /// </summary>
        public string PathToSave { get; set; }
    }
    public enum ImageType : byte
    {
        JPEG = 1,
        PNG = 2,
        JPG = 3
    }

}
