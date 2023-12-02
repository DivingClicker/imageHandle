using NumSharp.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Python.Runtime;
using System.Drawing;


namespace App
{
    public class UsePy: IDisposable
    {
        public UsePy()
        {   //根据自己dctimage项目的python环境路径修改,python代码里的包要在python环境里下好，比如numpy之类
            string pathToVirtualEnv =
                @"E:\anaconda3\envs\dctImage";
                //@"C:\Users\admin\anaconda3\envs\dctImage";
            Runtime.PythonDLL = Path.Combine(pathToVirtualEnv, "python39.dll");//需要用3.9版本的python
            PythonEngine.PythonHome = Path.Combine(pathToVirtualEnv, "python.exe");
            //python代码路径，统一放在项目pySrc文件夹
            PythonEngine.PythonPath =
                $"E:\\Code\\"
                //$"E:\\"
                +
                $"imageHandle\\parts_inspect\\pySrc;{pathToVirtualEnv}\\Lib\\site-packages;{pathToVirtualEnv}\\Lib";
            PythonEngine.Initialize();
        }

        ~UsePy()
        {
            Dispose(false);
        }

        //切割
        public string Crop(string filePath, string outfoldPath, int size)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("imageSplit2");
                string respath = np.crop_bmp_image(filePath, outfoldPath, size);
                //Console.WriteLine(respath);
                return respath;
            }
        }
        //组合
        public string Com(string oriFoldPath, string comFilePath)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("combpic");
                string respath = np.combin(oriFoldPath, comFilePath);
                // Console.WriteLine(respath);
                return respath;
            }
        }
        //增强
        public string Enhan(string oriFoldPath, string enhanFoldPath)
        {
            using (Py.GIL())
            {
                dynamic np = Py.Import("enhanceImg");
                string respath = np.do_enhance(oriFoldPath, enhanFoldPath);
                //Console.WriteLine(respath);
                bmpTojpg(respath);
                return respath;
            }

        }

        private void bmpTojpg(string folderPath)
        {
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

        // 实现 IDisposable 接口
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // 释放资源的方法
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                // 在这里释放托管资源（如果有的话）
            }

            // 释放非托管资源
            PythonEngine.Shutdown();
        }
    }
















}
