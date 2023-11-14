import cv2
import numpy as np

image = cv2.imread('output_images/image_596.bmp', cv2.IMREAD_GRAYSCALE)


# 进行离散余弦变换
dct_image = cv2.dct(np.float32(image) / 255.0)

# 设定阈值以保留异常损伤部分（低频）
low_freq_threshold = 10
dct_low_freq = dct_image * (np.abs(dct_image) < low_freq_threshold)

# 设定阈值以去除或削弱横向纹理（高频）
high_freq_threshold = 17.5
dct_high_freq_filtered = dct_image * (np.abs(dct_image) < high_freq_threshold)

# 对低频部分进行增强
enhanced_low_freq = cv2.idct(dct_low_freq) * 255.0

# 对经过滤波的高频部分进行处理，可以置零或者进一步减小其幅值
dct_high_freq_filtered = dct_high_freq_filtered * (np.abs(dct_high_freq_filtered) > 0.1 * np.max(dct_high_freq_filtered))

# 对高频部分进行增强
enhanced_high_freq = cv2.idct(dct_high_freq_filtered) * 255.0

# 合并低频和高频部分
enhanced_image = enhanced_low_freq + enhanced_high_freq

# 显示原始图像和增强后的图像
cv2.imshow('Original', image)
cv2.imshow('Enhanced', enhanced_image.astype(np.uint8))
cv2.waitKey(0)
cv2.destroyAllWindows()

