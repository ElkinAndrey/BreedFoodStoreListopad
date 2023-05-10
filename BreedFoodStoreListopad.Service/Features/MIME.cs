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
    }
}
