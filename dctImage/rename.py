import os


def rename_files(path):
    # 检查路径是否存在
    if not os.path.isdir(path):
        print("指定路径不存在")
        return

    # 获取路径下所有文件和文件夹
    files = os.listdir(path)

    # 遍历文件
    for file in files:
        # 构建旧文件名和新文件名的路径
        old_name = os.path.join(path, file)
        new_name = os.path.join(path, "3_" + file)

        # 检查文件是否是普通文件
        if os.path.isfile(old_name):
            # 重命名文件
            os.rename(old_name, new_name)


# 指定需要重命名的文件夹路径
path = "assets_3/w/"

# 调用重命名函数
rename_files(path)
