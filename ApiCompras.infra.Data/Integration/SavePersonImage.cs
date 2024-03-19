using ApiCompras.Domain.Integration;

namespace ApiCompras.Infra.Data.Integration;

public class SavePersonImage : ISavePersonImage
{
    private readonly string _filePath;

    public SavePersonImage()
    {
        _filePath = "/temp";
    }
    public string Save(string imagemBase64)
    {       
        var base64Vode = imagemBase64
            .Substring(imagemBase64.IndexOf(",") + 1);        

        var imgByte = Convert.FromBase64String(base64Vode);
        var fileExt = ImageExtension(imgByte);

        var fileName = Guid.NewGuid().ToString() + "." + fileExt;
        using (var imageFile = new FileStream
              (_filePath + "/" + fileName, FileMode.Create))
        {
            imageFile.Write(imgByte, 0, imgByte.Length);
            imageFile.Flush();
        }
        return _filePath + "/" + fileName;
    }

    private string ImageExtension(byte[] photo)
    {
        if (photo[0] == 0xFF && photo[1] == 0xD8 && photo[2] == 0xFF)
        {
            return "jpg";
        }

        if (photo[0] == 0x89 && photo[1] == 0x50 && photo[2] == 0x4E && photo[3] == 0x47)
        {
            return "png";
        }
        return "jpg";
    }
    //public string Save(string imageBase64)
    //{
    //    var fileExt = imageBase64.Substring(imageBase64.IndexOf('/') + 1, imageBase64.IndexOf(';') - imageBase64.IndexOf('/') - 1);
    //    var base64Code = imageBase64.Substring(imageBase64.IndexOf(',') + 1);
    //    var img = Convert.FromBase64String(base64Code);
    //    var fileName = Guid.NewGuid().ToString() + "." + fileExt;
    //    using (var imageFile = new FileStream(_filePath + "/" + fileName, FileMode.Create))
    //    {
    //        imageFile.Write(img, 0, img.Length);
    //        imageFile.Flush();
    //    }
    //    return _filePath + "/" + fileName;
    //}
}
