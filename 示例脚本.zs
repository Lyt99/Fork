;����һ��ע��
PRINT ���ڼ��ء���
SLEEP 5
CLS
PRINT ���سɹ���


PRINT [0]�µ���Ϸ
PRINT [1]������Ϸ
PRINT [2]�˳�
PRINT [3]�⻹�Ǹ��˳�

SELECT 0,1,2

;�����������ֲ��(python)
;%SELECTION%����SELECT����LOADGAME�����Ľ��
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
