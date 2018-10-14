﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GXTY_CSharp
{
    class Program
    {

        [STAThread]
        static void Main(string[] args)
        {
            WriteTitle();

            RunJSON runJSON = new RunJSON(new RunJSON.Position(30.8669741312, 121.9183560969));
            runJSON.AutoAddPosition(new RunJSON.Position(0.0001f, 0f), new Random().Next(290, 330), 4f);

            Console.Write("新功能:是否打开路径鼠标绘画工具?(y/n)");
            if (Console.ReadLine() == "y")
                Application.Run(new MainForm());

            Console.Write("是否导入当前路径的map.gpx?(y/n)");
            if (Console.ReadLine() == "y")
            {
                if (!File.Exists("map.gpx")) Console.WriteLine("map.gpx不存在!");
                else runJSON.LoadGPX("map.gpx");
            }


            Console.Write("手机号:");
            string mobile = Console.ReadLine();
            Console.Write("密码:");
            string pass = Console.ReadLine();
            Console.WriteLine("登陆中...");
            Network.Login(mobile, pass);
            Console.WriteLine("登陆成功!请求开始体育锻炼中...");
            Network.ExecRun();
            Console.WriteLine("上传体育锻炼结果中...");
            string rtn = Network.SaveExecRun(runJSON);
            Console.WriteLine("上传完成!以下是服务器返回值↓");
            Console.WriteLine(rtn);
            Console.WriteLine("按回车键退出");
            Console.ReadLine();
        }


        private static void WriteTitle()
        {
            Console.WriteLine(@"                                                                          ");
            Console.WriteLine(@"                                    ]/O[[[[[[[@\`                         ");
            Console.WriteLine(@"                               ,/[              *\@@@\]                   ");
            Console.WriteLine(@"                            ]/                     * **,\O`               ");
            Console.WriteLine(@"                          /`    ]  *]/                  **\@`             ");
            Console.WriteLine(@"                        =`   ,/  =[`   ]^  ,`**      *  ***,O\            ");
            Console.WriteLine(@"                       /    /  ,`/  ,/    / *  *,*** ******`=O@`          ");
            Console.WriteLine(@"                     ,/   ,^  O/` ,/    ,`    ,\@ =**,******OOO@          ");
            Console.WriteLine(@"                     / ,*O` /OO**OO*,]/O^^* *,O`/ =  *^*=*=OoOOO@         ");
            Console.WriteLine(@"                    / =,O^*/OOOOO\]]]oO@`*`*,O^ O*/`  O*=\/OOOOOO^        ");
            Console.WriteLine(@"                   =^=`O^*OO@@/[[`     [OOOOO^ =OOOO**OooOoOOoOOO@        ");
            Console.WriteLine(@"                   @ ^o/*/oO^\/@@@@@@/         \\/OoOOOOOOO\OooOO@        ");
            Console.WriteLine(@"                  =^=oO*=OO^         [^           ,\OO@OO^   OoOO@        ");
            Console.WriteLine(@"                  O /o^*Oo@                   ,]]],\  \@O@OOOOO@O@        ");
            Console.WriteLine(@"                 ,^ OO`=OOO             ^        [@@\  =@OOO@OO@OO        ");
            Console.WriteLine(@"               ,O\^=OO*=O@^                        ,@O =@OOO@OO@O^        ");
            Console.WriteLine(@"      ,/Ooo[[`,/OO^=o@`=oOO         ,]                 @@OoOOOOOO`        ");
            Console.WriteLine(@"        ,\\]]OO@@@O=O@^=O@/       /@@@\]  ^           /@OooOOO@OO         ");
            Console.WriteLine(@"               /`o@=O@^/OOO^     /@@@@@@@@@          /\OO^OOOO@O^         ");
            Console.WriteLine(@"   =\`     ]O[**oO@OO@@/O@O@\[^  OOOOOOO@@@        ,@O@OOo@OO@O@          ");
            Console.WriteLine(@"    O\***     /OOO@@O@OOOOOO^,^ /*OOOOOOO/^       =O/@OO/@OOO@O@          ");
            Console.WriteLine(@"     ,\/[[OOOOOO/ /o@OOOOOO^ OO/ =` [@/@[^^    ,/@O@@O/\@OO=@OOO^         ");
            Console.WriteLine(@"           [`    /`OO@O/@O^ =O/ /@`/ ,@`,^\]@@OOOOO@@\o@O@oO@OOOO`        ");
            Console.WriteLine(@"               ,/]OO@@@\/^ =@^ //=` /@@O**=@@@@@@@@/\OO@@oO@@@OOOOO]    ] ");
            Console.WriteLine(@"         ,,,]OO[oO@O@@@@@@@@@@@@/  //`,^**/@@@@@///@OO@@\O@OO ,[OOOOO/[   ");
            Console.WriteLine(@"             [`  /@@@@@@@@@@@@@@@/\` /***/@@@Oo/@@O@@@O=@OO@OO            ");
            Console.WriteLine(@"                /@@@@@@@@@@@@@@@@@,O*]]//OoO@@@@@@@@oO@@OO@OO@O@]    ` ,` ");
            Console.WriteLine(@"              ,@@@@@@@@@@@@@@@@@@@@@@@@\ *[o@@@@@@@@@@@@^[\oOOOO@OO@OO/`  ");
            Console.WriteLine(@"       ,@@@@@@@@@@@@@@@@@@@@@@@@@@O@^=@@` ,oo@O@@@@@@@@@     [[[          ");
            Console.WriteLine(@"      /@@@@@@@@@@@@@@@@@@@@@@@@@@OO@@@@O\]@@@@@@@@@@@@@ooO`               ");
            Console.WriteLine(@"     @@@@@@@@OoOO@@@@@@@@@@@@@@O@@@@o@@OO@\OO@@@@@@@@OOoooO@@\`           ");
            Console.WriteLine(@"    /@@@@@@@@@@@@@OO@@@@@@@@@@@@@@@@O@O@@@@@@@@@@@@@@\\oooo@@@@@\         ");
            Console.WriteLine(@"   =@@@@@@@@@@@OO@@@@O@@@@@Oo  ,@O@@@@@@OOOOO@@@@@@@@@/Oooo@@@@@@^        ");
            Console.WriteLine(@"   @@@@@@@@@@@@@@@OO@@@O@@@/  =/O@@@@@@OO,Oo@@@@@@@@@@^\oooO@@@@@O        ");
            Console.WriteLine(@"  /@@@@@@@@@@@@@@@@@O@@@@@o  ,OO/@@/\@OOO^ =@@@@@@@@@@@=oooo@@@@@@        ");
            Console.WriteLine(@" @@@@@@@@@@@@@@@@@@@@@@@@@O  Oo/ @@@@@O@\O =@@@@@@@@@@@oOooo@@@@@@        ");
            Console.WriteLine(@" @@@@@@@@@@@@@@@@@@@@@@@@@O O]@ ,@@@@@O=o@^@@@@@@@@@@@@OOooo@@@@@@        ");
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("--------------------高校体育APP 一键自动体育锻炼工具-----------------------");
            Console.WriteLine("---------------------------------制作:留白---------------------------------");
            Console.WriteLine("-------------------------https://github.com/RyuBAI-------------------------");
            Console.WriteLine("---------------------------------------------------------------------------");
        }
    }
}
