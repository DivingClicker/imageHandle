from distutils.core import setup
from Cython.Build import cythonize
setup(
name = "testName",
ext_modules = cythonize("enhanceImg.py"),
)()