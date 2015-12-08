#pragma once

#include <string>
#include <vector>
#include <Windows.h>

#define API __declspec(dllexport)

extern "C"{
	struct API AppHandle
	{
		void* process;
		HWND window;
		unsigned long pid;
		bool valid;
	};

	BOOL CALLBACK EnumWindowsProc(HWND hwnd, LPARAM lParam);

	API bool MSCreateProcess(char* path, AppHandle* handle);
	API bool MSGetWindowHandle(AppHandle* handle);
	API bool MSMinimize(AppHandle* handle);
	API bool MSRestore(AppHandle* handle);
	API bool MSTerminate(AppHandle* handle);
}