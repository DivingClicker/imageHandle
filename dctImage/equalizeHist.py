import numpy as np
import cv2
from matplotlib import pyplot as plt
# 1. 直接以灰度图的方式读入
# 194 322 121 122 158 148
img = cv2.imread('output_images/image_148.bmp', cv2.IMREAD_GRAYSCALE)
# 2. 均衡化处理
# dst = cv2.equalizeHist(img)

# 2.1. 自适应直方图均衡处理
# clahe = cv2.createCLAHE(clipLimit=2.0 ,tileGridSize=(8,8))
# dst = clahe.apply((img))

# 2.2. 提取轮廓的处理
# # 使用Canny边缘检测算法找到图像的边缘
# edges = cv2.Canny(img, 200, 400)  # 这里的30和100是Canny算法的阈值，你可以根据需要调整
#
# # 找到轮廓
# contours, _ = cv2.findContours(edges, cv2.RETR_EXTERNAL, cv2.CHAIN_APPROX_SIMPLE)
#
# # 创建一个黑色背景
# dst = np.zeros_like(img)
#
# # 绘制轮廓
# cv2.drawContours(dst, contours, -1, (255, 255, 255), 1)
# # 这里的(255, 255, 255)是轮廓的颜色，2是线条宽度

# 2.3. 从左到右的扫描
variance_image = np.zeros(img.shape, dtype=np.float32)
for y in range(1, img.shape[0] - 1):
    for x in range(1, img.shape[1] - 1):
        variance = np.var([img[y, x-1], img[y, x], img[y, x+1]])
        variance_image[y, x] = variance
dst = cv2.normalize(variance_image, None, 0, 400, cv2.NORM_MINMAX, dtype=cv2.CV_8U)
print(img.shape[0]-1,img.shape[1]-1)
cv2.imshow('Original', img)
cv2.imshow('Enhanced', dst.astype(np.uint8))
cv2.waitKey(0)
cv2.destroyAllWindows()