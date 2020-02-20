
## To Execute:

	* To create a .so file:

	1) g++ -fPIC -c -Wall img_converter.cpp
	2) g++ -shared img_converter.o -o libimg_converter.so

	* Copy .so file to bin/Debug/netcoreapp2.2/

	* To run .net proj in linux:

	1) dotnet build Test.csproj
	2) dotnet bin/Debug/netcoreapp2.2/Test.dll 