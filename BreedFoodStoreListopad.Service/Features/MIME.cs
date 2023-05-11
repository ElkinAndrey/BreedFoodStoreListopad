namespace BreedFoodStoreListopad.Service.Features
{
    /// <summary>
    /// Работа с MIME (стандарт, описывающий передачу различных типов данных по 
    /// электронной почте, а также, в общем случае, спецификация для кодирования 
    /// информации и форматирования сообщений таким образом, чтобы их можно было 
    /// пересылать по Интернету)
    /// </summary>
    public static class MIME
    {
        public static class MIMETypes
        {
            public static string ApplicationOctetStream { get; } = "application/octet-stream";
        }

        /// <summary>
        /// Проверить, является ли MIME формат картинкой
        /// </summary>
        /// <param name="contentType"></param>
        /// <returns></returns>
        public static bool IsImage(string contentType)
        {
            /*
            Все виды картинок
            image/gif: GIF (RFC 2045 и RFC 2046)
            image/jpeg: JPEG (RFC 2045 и RFC 2046)
            image/pjpeg: JPEG[9]
            image/png: Portable Network Graphics[10](RFC 2083)
            image/svg+xml: SVG[11]
            image/tiff: TIFF (RFC 3302)
            image/vnd.microsoft.icon: ICO[12]
            image/vnd.wap.wbmp: WBMP
            image/webp: WebP 
            */

            string image = "image/";

            for (int i = 0; i < image.Length; i++)
                if (contentType[i] != image[i])
                    return false;
            return true;
        }

        /// <summary>
        /// Получить MIME формат по расширению файла
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static string GetContentType(string fileName)
        {
            /*
            Все виды картинок
            image/gif: GIF (RFC 2045 и RFC 2046)
            image/jpeg: JPEG (RFC 2045 и RFC 2046)
            image/pjpeg: JPEG[9]
            image/png: Portable Network Graphics[10](RFC 2083)
            image/svg+xml: SVG[11]
            image/tiff: TIFF (RFC 3302)
            image/vnd.microsoft.icon: ICO[12]
            image/vnd.wap.wbmp: WBMP
            image/webp: WebP 
            */

            string fileExtension = Path.GetExtension(fileName);

            switch (fileExtension)
            {
                case ".gif":
                    return "image/gif";
                case ".jpeg":
                    return "image/jpeg";
                case ".jpg":
                    return "image/jpeg";
                case ".pjpeg":
                    return "image/jpeg";
                case ".png":
                    return "image/png";
                case ".svg":
                    return "image/svg+xml";
                case ".tif":
                    return "image/tiff";
                case ".tiff":
                    return "image/tiff";
                case ".ico":
                    return "image/vnd.microsoft.icon";
                case ".wbmp":
                    return "image/vnd.wap.wbmp";
                case ".webp":
                    return "image/webp";
                default:
                    return "application/octet-stream";
            }
        }
    }
}
