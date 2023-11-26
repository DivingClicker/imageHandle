from PIL import Image
import numpy as np
import os
import random

width = 256
height = 256

def random_horizontal_shift(image, max_shift):
    # 将图像转换为NumPy数组
    img_array = np.array(image)

    # 生成随机平移距离
    shift_distance = random.randint(-max_shift, max_shift)

    # 如果是向右平移，将左侧填补到右侧
    if shift_distance >= 0:
        shifted_array = np.roll(img_array, shift_distance, axis=1)
        shifted_array[:, shift_distance:, :] = img_array[:, :width - shift_distance, :]
    # 如果是向左平移，将右侧填补到左侧
    else:
        shifted_array = np.roll(img_array, shift_distance, axis=1)
        shifted_array[:, :width + shift_distance, :] = img_array[:, -shift_distance:, :]

    # 将NumPy数组转换回图像
    shifted_image = Image.fromarray(shifted_array)

    return shifted_image

def generate_shifted_images(input_folder, output_folder, max_shift):
    # 创建输出文件夹
    os.makedirs(output_folder, exist_ok=True)

    # 遍历输入文件夹中的所有图像文件
    for filename in os.listdir(input_folder):
        if filename.endswith('.jpg'):
            # 读取图像
            input_path = os.path.join(input_folder, filename)
            image = Image.open(input_path)

            # 随机水平平移
            shifted_image = random_horizontal_shift(image, max_shift)

            # 保存平移后的图像
            output_path = os.path.join(output_folder, f"s_{filename}")
            shifted_image.save(output_path)

if __name__ == "__main__":
    # 输入文件夹路径和输出文件夹路径
    input_folder_path = "assets_2/W"
    output_folder_path = "assets_2/W"

    # 设置最大平移距离
    max_shift_distance = 250  # 调整为你希望的最大平移距离

    # 执行平移操作
    generate_shifted_images(input_folder_path, output_folder_path, max_shift_distance)
