#include "WinAPIWrapper.hpp"
#include <iostream>
using namespace std;

AppHandle* g_app = nullptr;

BOOL CALLBACK EnumWindowsProc(HWND hwnd, LPARAM lParam)
{
	DWORD processID;
	GetWindowThreadProcessId(hwnd, &processID);
	if(processID == (DWORD)lParam)
	{
		g_app->window = hwnd;

		SetLastError(ERROR_SUCCESS);
		return FALSE;
	}
	return TRUE;
}

bool MSCreateProcess(char* path, AppHandle* handle)
{
	PROCESS_INFORMATION info;
	STARTUPINFO startInfo;
	ZeroMemory(&startInfo, sizeof(startInfo));
	startInfo.cb = sizeof(startInfo);

	auto res = CreateProcess(path,NULL, NULL, NULL, true, NORMAL_PRIORITY_CLASS,
		NULL, NULL, &startInfo, &info);

	if(res == 0)
		return false;

	if(!handle)
		handle = new AppHandle();

	handle->valid = true;
	handle->process = info.hProcess;
	handle->pid = info.dwProcessId;
	handle->window = nullptr;

	Sleep(500);
	return true;
}

bool MSMinimize(AppHandle* handle)
{
	if(!handle)
		return false;
	bool res = ShowWindow(handle->window,SW_MINIMIZE);
	return res;
}

bool MSGetWindowHandle(AppHandle* handle)
{
	if(!handle)
		return false;

	if(!handle->valid)
		return false;

	g_app = handle;

	while(EnumWindows(EnumWindowsProc, handle->pid)){
		Sleep(100);
	}

	if(GetLastError() == ERROR_SUCCESS){
		handle->window = g_app->window;
		return true;
	}
	handle->window = nullptr;
	return false;
}

bool MSRestore(AppHandle* handle)
{
	if(!handle)
		return false;
	bool res = ShowWindow(handle->window,SW_RESTORE);
	return res;
}

bool MSTerminate(AppHandle* handle)
{
	if(!handle)
		return false;
	bool res = TerminateProcess(handle->process,0);
	return res;
}