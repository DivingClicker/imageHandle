import cv2
import numpy as np

image = cv2.imread('output_images/image_194.bmp', cv2.IMREAD_GRAYSCALE)

# 使用高斯滤波去噪
blurred_image = cv2.GaussianBlur(image, (5, 5), 0)
# 进行离散余弦变换
dct_image = cv2.dct(np.float32(blurred_image) / 255.0)


# dct_image = cv2.dct(np.float32(image) / 255.0)
# 设定阈值以保留异常损伤部分（低频）
low_freq_threshold = 0.08#0.01~0.08
dct_low_freq = dct_image * (np.abs(dct_image) < low_freq_threshold)

# 设定阈值以去除或削弱横向纹理（高频）
high_freq_threshold = 1.6#1~1.8
dct_high_freq_filtered = dct_image * (np.abs(dct_image) < high_freq_threshold)

# 对低频部分进行增强
enhanced_low_freq = cv2.idct(dct_low_freq) * 255.0

# 对经过滤波的高频部分进行处理，可以置零或者进一步减小其幅值
dct_high_freq_filtered = dct_high_freq_filtered * (np.abs(dct_high_freq_filtered) > 0.1 * np.max(dct_high_freq_filtered))

# 对高频部分进行增强
enhanced_high_freq = cv2.idct(dct_high_freq_filtered) * 255.0

# 合并低频和高频部分
enhanced_image = enhanced_low_freq + enhanced_high_freq


# # 将原本的白色和黑色都设为白色
# enhanced_image[np.logical_or(enhanced_image < 32, enhanced_image == 255)] = 255
#
# # 将灰色设为黑色
# enhanced_image[enhanced_image < 192] = 0


# 显示原始图像和增强后的图像
cv2.imshow('Original', image)
cv2.imshow('Enhanced', enhanced_image.astype(np.uint8))

image2 = enhanced_image

# 将原本的白色和黑色都设为白色
image2[np.logical_or(image2 < 32, image2 >= 185)] = 255

# 将灰色设为黑色
image2[image2 < 185] = 0

#想要设置小黑点为0，但是连通件检测不出来，也许是太小了
num_labels, labels, stats, centroids = cv2.connectedComponentsWithStats(image2.astype(np.uint8), connectivity=8)
# 设置阈值，筛选面积较小的区域
threshold_area = 100  # 根据需要调整阈值
print(num_labels)
# 根据面积筛选区域
for i in range(1, num_labels):
    if stats[i, cv2.CC_STAT_AREA] > threshold_area:
        # 保留面积较大的区域
        image2[labels == i] = 255
    else:
        # 去除面积较小的区域
        image2[labels == i] = 0



cv2.imshow('Enhanced2', image2.astype(np.uint8))

cv2.waitKey(0)
cv2.destroyAllWindows()

