from PIL import Image
import os

def flip_images(input_folder, output_folder):
    # 创建输出文件夹
    os.makedirs(output_folder, exist_ok=True)

    # 遍历输入文件夹中的所有图像文件
    for filename in os.listdir(input_folder):
        if filename.endswith(('.jpg')):
            # 读取图像
            input_path = os.path.join(input_folder, filename)
            image = Image.open(input_path)

            # 水平翻转
            horizontal_flipped_image = image.transpose(Image.FLIP_LEFT_RIGHT)
            horizontal_output_path = os.path.join(output_folder, f"h_{filename}")
            horizontal_flipped_image.save(horizontal_output_path)

            # 垂直翻转
            vertical_flipped_image = image.transpose(Image.FLIP_TOP_BOTTOM)
            vertical_output_path = os.path.join(output_folder, f"v_{filename}")
            vertical_flipped_image.save(vertical_output_path)

if __name__ == "__main__":
    # 输入文件夹路径和输出文件夹路径
    input_folder_path = "assets/W"
    output_folder_path = "assets/W"

    # 执行翻转操作
    flip_images(input_folder_path, output_folder_path)
