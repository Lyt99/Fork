using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectFork.Enum
{
    enum CommandType
    {
        //PRINT
        PRINT,//不换行
        PRINTCOLOR,
        PRINTEACH,
        PRINTL,//换行
        //赋值、添加、删除、查询
        SET,
        LISTADD,
        LISTDEL,
        LISTCONTAIN,
        //双关键词字典
        DICTGET,
        DICTSET,
        //我也不知道叫什么
        FOR,
        SWITCH,
        IF,
        //其它
        SETCOLOR,
        PLAYMUSIC,
        STOPMUSIC,
        RAND
    }
}
