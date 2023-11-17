import cv2
import numpy as np

def adjust_brightness_contrast(image, alpha=1.5, beta=30):
    adjusted_image = np.uint8(np.clip(alpha*image + beta, 0, 255))
    return adjusted_image

def enhance_abnormal_region(image, threshold=30):
    # 进行离散余弦变换
    dct_image = cv2.dct(np.float32(image)/255.0)

    # 将低频部分置零
    dct_image[:threshold, :threshold] = 0

    # 逆离散余弦变换
    enhanced_image = cv2.idct(dct_image) * 255.0
    enhanced_image = np.uint8(enhanced_image)

    return enhanced_image

# 读取原始图像
original_image = cv2.imread('output_images/image_522.bmp', cv2.IMREAD_GRAYSCALE)

# 调整亮度和对比度
adjusted_image = adjust_brightness_contrast(original_image)

# 使用高斯滤波去噪
blurred_image = cv2.GaussianBlur(adjusted_image, (5, 5), 0)

# 直方图均衡化
equalized_image = cv2.equalizeHist(blurred_image)

# 突出异常部分
enhanced_abnormal_region_image = enhance_abnormal_region(equalized_image)

# 可视化结果
cv2.imshow('Original Image', original_image)
cv2.imshow('Adjusted Image', adjusted_image)
cv2.imshow('Blurred Image', blurred_image)
cv2.imshow('Enhanced Abnormal Region', enhanced_abnormal_region_image)
cv2.waitKey(0)
cv2.destroyAllWindows()
