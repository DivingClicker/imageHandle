using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MLModel1_ConsoleApp1;

namespace App
{
    internal class Test
    {
        public static void Main(string[] args)
        {
            UsePy py = new UsePy();
            string path = @"E:\Code\imageHandle\dctImage\images\1.bmp";
            string outpath = @"E:\Code\imageHandle\parts_inspect\MLModel1_ConsoleApp1\test\";//注意文件夹最后要加上\
            string enhanpath = @"E:\Code\imageHandle\parts_inspect\MLModel1_ConsoleApp1\enhan\";//文件夹要存在才能运行
            // string res = py.Crop(path, outpath, 256);
            //string res = py.Enhan(outpath, enhanpath);
            //Console.WriteLine(res);
            var imageBytes = File.ReadAllBytes(@"E:\Code\imageHandle\parts_inspect\MLModel1_ConsoleApp1\enhan\1_1.jpg");
            MLModel1.ModelInput sampleData = new MLModel1.ModelInput()
            {
                ImageSource = imageBytes,
            };
            var predictionResult = MLModel1.Predict(sampleData);
            Console.WriteLine($"\n\nPredicted Label value: {predictionResult.PredictedLabel} \nPredicted Label scores: [{String.Join(",", predictionResult.Score)}]\n\n");
            string filepath = py.Com(outpath, @"E:\Code\imageHandle\parts_inspect\MLModel1_ConsoleApp1\com\result.bmp");
            Console.WriteLine(filepath);
            //运行会有警告，但是不影响结果
        }
    }

}
