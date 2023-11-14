from PIL import Image

Image.MAX_IMAGE_PIXELS = 200000000 # to avoid DecompressionBombError

def crop_bmp_image(image_path, output_path, crop_size):
    original_image = Image.open(image_path)
    width, height = original_image.size

    x = 0
    y = 0
    count = 1

    while y + crop_size <= height:
        while x + crop_size <= width:
            crop = original_image.crop((x, y, x + crop_size, y + crop_size))
            crop.save(output_path + f"image_{count}.bmp")
            count += 1
            x += crop_size
        x = 0
        y += crop_size

image_path = "images/1.bmp"
output_path = "output_images/"
crop_size = 256

crop_bmp_image(image_path, output_path, crop_size)
