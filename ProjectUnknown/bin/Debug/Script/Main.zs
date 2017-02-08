TITLE Fork游戏引擎Demo{VAR:version}

PRINTL
PRINTM
==============================================================
			欢迎使用Fork引擎！
		  这是一个文字冒险游戏引擎
		运行输出该段文字的文件为Main.zs
	  下方输入 Meow/喵呜 命令来尝试一下ಠ౪ಠ
==============================================================
ENDPRINTM
PRINTV 程序版本: {VAR:version}
PRINTL
PRINTV {DICT:MESSAGE1}
PRINTL

SETFLAG go True

INPUT a

STOPBGM