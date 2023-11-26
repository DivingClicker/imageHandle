using System;
using System.Drawing;
using System.IO;
using Parts_inspect;
class Program
{
    //将bmp格式的图像转换为jpg格式
    static void Main(string[] args)
    {
        // 指定需要转换的文件夹路径
        string folderPath = "../../../test";

        // 获取文件夹中的所有BMP图像文件
        string[] bmpFiles = Directory.GetFiles(folderPath, "*.bmp");

        // 循环处理每个BMP图像文件
        foreach (string bmpFile in bmpFiles)
        {
            // 读取BMP图像文件
            using (Bitmap bmp = new Bitmap(bmpFile))
            {
                // 构造目标JPG文件路径
                string jpgFile = Path.ChangeExtension(bmpFile, "jpg");

                // 将BMP图像保存为JPG格式
                bmp.Save(jpgFile, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            File.Delete(bmpFile);
        }

        Console.WriteLine("转换完成");

    }
}


