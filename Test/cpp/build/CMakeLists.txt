cmake_minimum_required(VERSION 2.8)
project(img_converter)
add_executable(img_converter img_converter.h img_converter.cpp)

install(TARGETS img_converter /home/deeplearningcv/Desktop/Test/cpp lib{}.so)



