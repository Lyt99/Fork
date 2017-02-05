;这是一行注释
PRINT 正在加载……
SLEEP 5
CLS
PRINT 加载成功。


PRINT [0]新的游戏
PRINT [1]加载游戏
PRINT [2]退出
PRINT [3]这还是个退出

SELECT 0,1,2

;利用缩进来分层次(python)
;%SELECTION%保存SELECT或者LOADGAME处理后的结果
SWITCH %SELECTION%
	CASE 0
		SET %FLAG:gamestart% true
		RUN Newgame.zs
	CASE 1
		LOADGAME Loadgame.zs
		BIF %SELECTION%
			SET %FLAG:gamestart% true
	CASE 2,3
		EXIT
