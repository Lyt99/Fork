PRINTL 这是Test.zs文件！
SLEEP 1
PRINTL 我跳过来了！
PRINTL 测试变量
SLEEP 1
SETVAR a 1
SETVAR b 2
SETVAR c 3
PRINTL 设置a = 1, b = 2, c = 3
SLEEP 1
SETVAR c (%VAR:a% + %VAR:b%) == %VAR:c%
PRINTVARS %VAR:c%
PRINTL  


;Main.zs测试版
;注释大概可以用了2333


COLOR Yellow
PRINT 请输入:
COLOR Red
INPUT a
COLOR Green
SWITCH %LOCAL:a%
	CASE wa2
		PRINTL wa2
	DEFAULT
		PRINTL wwwwwwwwa
ENDSWITCH
COLOR Gray






EXIT

LISTADD a wa
LISTADD a wa
LISTADD a wa2
FOR i a
	PRINTVARS 你遇到了 %LOCAL:i%
	PRINTL
	PRINTL
	IF "%LOCAL:i%" == "wa"
		PRINTL 他可能要EXIT
		EXIT
	ENDIF
	SLEEP 0.5
ENDFOR
PRINTL 你死了




EXIT

PRINT Hello, World!
PRINT  但是这句话不换行
PRINTL 
SETVAR a 2
SETVAR b 1
IF %VAR:a% == 1
	PRINTL a == 1!
	IF %VAR:b% == 1
		PRINTL wa
	ENDIF
ELSE
	PRINT a != 1
ENDIF

SLEEP 0.5
PRINTL 这才是
SLEEP 2
PRINTL 能换行的2333

RUN Test.zs
PRINTL 我好像又回来了23333

PRINTMULTI
	==================================================
	多行文本
	测试
	试试看
	行不行
	==================================================
PRINTMULTIEND


PRINT 回来