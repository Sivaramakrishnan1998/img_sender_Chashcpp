#ifdef __cplusplus
extern "C"{
#endif
#ifdef _WIN32
	#ifdef MODULE_API_EXPORTS
	#define MODULE_API __declspec(dllexport)
	#else
	#define MODULE_API __declspec(dllimport)
	#endif
#else
	#define MODULE_API
	#endif
struct ImageInfo
{
	unsigned char *data;
	int size;
};

MODULE_API bool ReleaseMemoryFromC(unsigned char*);
MODULE_API void imagePassChashtoCpp(unsigned char* , int , ImageInfo);


#ifdef __cplusplus
}
#endif
