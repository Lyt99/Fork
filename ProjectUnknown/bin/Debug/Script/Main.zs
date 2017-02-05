;Main.zs测试版
;注释大概可以用了2333



LISTADD a hjydalao
LISTADD a hjyzs
LISTADD a lytzz
FOR i a
	PRINTVARS 你遇到了 %LOCAL:i%
	PRINTL
	SLEEP 0.5
FOREND
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